using System.Collections.Generic;
using UnityEngine;

public class DeliveryDriver : MonoBehaviour, IInteractable
{
    private Recipe m_requestedRecipe;

    private void Start() => Request();

    public void Interact() => EventBus<DeliverEvent>.Raise(new DeliverEvent(this));

    public void Request()
    {
        m_requestedRecipe = Loader.GetRandomRecipe();
        Debug.Log("Requested: " + m_requestedRecipe.name);
    }

    public bool Deliver(Plate plate)
    {
        var requested = m_requestedRecipe.m_dish;
        var delivered = plate.IngredientMap;

        foreach (var requirement in requested)
        {
            CookState requestedState = requirement.State;
            var requestedIngredients = new HashSet<Ingredient>(requirement.Ingredients);

            if (!delivered.TryGetValue(requestedState, out var deliveredIngredients)) return false;
            if (!deliveredIngredients.SetEquals(requestedIngredients)) return false;
        }

        return true;
    }
}
