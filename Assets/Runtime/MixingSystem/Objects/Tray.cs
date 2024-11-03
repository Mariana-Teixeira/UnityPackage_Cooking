using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour, IInteractable
{
    private StateMachine m_stateMachine;
    public CookState @CookState { get; private set; } = CookState.Raw;
    public HashSet<Ingredient> Ingredients { get; } = new();

    private void Awake()
    {
        m_stateMachine = new StateMachine();
        var rawState = new RawState();
        var cookedState = new CookedState();
        m_stateMachine.AddTransition(rawState, cookedState, new CompareCondition<CookState>(CookState.Cooked));
        m_stateMachine.SetState(rawState);
    }

    private void Update()
    {
        m_stateMachine.Update();
    }

    public void Interact() => EventBus<PassObjectEvent<Tray>>.Raise(new PassObjectEvent<Tray>(this));
    public void AddToTray(Ingredient ingredient) => Ingredients.Add(ingredient);

    public void Cook(CookState state) =>
        EventBus<PassObjectEvent<CookState>>.Raise(new PassObjectEvent<CookState>(state));
}

public class RawState : IState
{
    public void OnEnter()
    {
        Debug.Log("Enter Raw State");
    }

    public void OnExit()
    {
    }
}

public class CookedState : IState
{
    public void OnEnter()
    {
        Debug.Log("Enter Cooked State");
    }

    public void OnExit()
    {
    }
}

public class FriedState : IState
{
    public void OnEnter()
    {
        Debug.Log("Enter Fried State");
    }

    public void OnExit()
    {
    }
}

public class CompareCondition<T> : ICondition
{
    private readonly EventBinding<PassObjectEvent<T>> m_conditionEvent;
    private bool m_condition = false;

    public CompareCondition(T targetObject)
    {
        m_conditionEvent = new EventBinding<PassObjectEvent<T>>(context =>
            m_condition = context.TargetObject.Equals(targetObject));
        EventBus<PassObjectEvent<T>>.Register(m_conditionEvent);
    }

    ~CompareCondition()
    {
        EventBus<PassObjectEvent<T>>.Deregister(m_conditionEvent);
    }
    
    public bool Evaluate() => m_condition;
}