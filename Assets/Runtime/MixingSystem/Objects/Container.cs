using UnityEngine;

public class Container : MonoBehaviour, IInteractable
{
    public Food @Food { get; } = new();

    public void Interact() => EventBus<ContainerEvent>.Raise(new ContainerEvent(this));

    public void AddToContainer(Ingredient ingredient)
    {
        Food.AddIngredient(ingredient);
    }
}