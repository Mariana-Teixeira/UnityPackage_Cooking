using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour, IInteractable
{
    private StateMachine _stateMachine;
    public CookState @CookState { get; set; } = CookState.Raw;
    public HashSet<Ingredient> Ingredients { get; } = new();

    private void Awake()
    {
        #region StateMachine
        _stateMachine = new StateMachine();
        var rawState = new RawState(this);
        var cookedState = new CookedState(this);
        var friedState = new FriedState(this);
        var burntState = new BurntState(this);
        _stateMachine.AddTransition(rawState, cookedState, new CompareCondition<CookState>(CookState.Cooked));
        _stateMachine.AddTransition(rawState, friedState, new CompareCondition<CookState>(CookState.Fried));
        _stateMachine.AddTransition(cookedState, burntState, new CompareCondition<CookState>(CookState.Cooked));
        _stateMachine.AddTransition(cookedState, burntState, new CompareCondition<CookState>(CookState.Fried));
        _stateMachine.AddTransition(friedState, burntState, new CompareCondition<CookState>(CookState.Cooked));
        _stateMachine.AddTransition(friedState, burntState, new CompareCondition<CookState>(CookState.Fried));
        _stateMachine.SetState(rawState);
        #endregion
    }

    public void Grab() => EventBus<GrabObject<Tray>>.Raise(new GrabObject<Tray>(this));
    public void DropOn<T>() => EventBus<DropOnObject<T, Tray>>.Raise(new DropOnObject<T, Tray>(this));
    public void Add(Ingredient ingredient) => Ingredients.Add(ingredient);
    public void Cook(CookState state) => _stateMachine.Compare(state);
}