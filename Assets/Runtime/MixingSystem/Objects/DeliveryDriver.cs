using System.Collections.Generic;
using UnityEngine;

public class DeliveryDriver : MonoBehaviour, IInteractable
{
    private Recipe _requestedRecipe;

    private void Start() => Request();

    public void Grab() { }
    public void DropOn<T>() => EventBus<DropOnObject<T, DeliveryDriver>>.Raise(new DropOnObject<T, DeliveryDriver>(this));

    private void Request()
    {
        _requestedRecipe = Loader.GetRandomRecipe();
        // Debug.Log("Requested: " + m_requestedRecipe.name);
    }

    public bool Deliver(Plate plate)
    {
        var requested = _requestedRecipe._dish;
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
