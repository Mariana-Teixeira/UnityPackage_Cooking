using System.Collections.Generic;
using Codice.Client.ChangeTrackerService.Serialization;
using UnityEngine;

public enum CookType
{
    Cooking,
    Frying,
    Saucing,
}

public class Appliance : MonoBehaviour, IInteractable
{
    [SerializeField] private CookType m_cookType;
    public void Interact() => EventBus<CookEvent>.Raise(new CookEvent(this));

    public bool Cook(Container container)
    {
        Food cookedFood = container.Food;
        ChangeCookStatus(cookedFood.Ingredients);
        return false;
    }

    private void ChangeCookStatus(HashSet<Ingredient> ingredients)
    {
        foreach (var ingredient in ingredients)
        {
            ingredient.ChangeState(m_cookType);
        }
    }
}