using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour, IInteractable
{
    private StateMachine m_stateMachine;
    public CookState @CookState { get; set; } = CookState.Raw;
    public HashSet<Ingredient> Ingredients { get; } = new();

    private void Awake()
    {
        m_stateMachine = new StateMachine();
        var rawState = new RawState(this);
        var cookedState = new CookedState(this);
        var friedState = new FriedState(this);
        var burntState = new BurntState(this);
        m_stateMachine.AddTransition(rawState, cookedState, new CompareCondition<CookState>(CookState.Cooked));
        m_stateMachine.AddTransition(rawState, friedState, new CompareCondition<CookState>(CookState.Fried));
        m_stateMachine.AddTransition(cookedState, burntState, new CompareCondition<CookState>(CookState.Cooked));
        m_stateMachine.AddTransition(cookedState, burntState, new CompareCondition<CookState>(CookState.Fried));
        m_stateMachine.AddTransition(friedState, burntState, new CompareCondition<CookState>(CookState.Cooked));
        m_stateMachine.AddTransition(friedState, burntState, new CompareCondition<CookState>(CookState.Fried));
        m_stateMachine.SetState(rawState);
    }

    public void Interact() => EventBus<PassEvent<Tray>>.Raise(new PassEvent<Tray>(this));
    public void AddToTray(Ingredient ingredient) => Ingredients.Add(ingredient);
    public void Cook(CookState state) => m_stateMachine.Compare(state);
}