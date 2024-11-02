using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour, IInteractable
{
    public CookState @CookState { get; private set; } = CookState.Raw;
    public HashSet<Ingredient> Ingredients { get; } = new();
    public void Interact() => EventBus<ContainerEvent>.Raise(new ContainerEvent(this));
    public void AddToTray(Ingredient ingredient) => Ingredients.Add(ingredient);
    public void Cook(CookState state) => @CookState = state;

}