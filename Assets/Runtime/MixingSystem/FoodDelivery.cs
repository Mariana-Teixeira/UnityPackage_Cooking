using System.Collections.Generic;
using UnityEngine;

public class FoodDelivery : MonoBehaviour
{
    private int m_money = 0;
    private int m_reputation = 0;

    [SerializeField]
    private InventoryDisplay m_inventoryDisplay;
    private List<SO_Ingredient> m_chosenIngredients = new List<SO_Ingredient>();

    private void Start()
    {
        RequestManager.PoolRequest.Invoke();
    }

    private void GainIngredientValue(Food food)
    {
        var add = SumPoints(food);
        m_money += add;
    }

    public void GrabIngredient(string ingredientName)
    {
        var ingredient = Loader.Ingredients[ingredientName];
        m_chosenIngredients.Add(ingredient);
        m_inventoryDisplay.UpdateText(m_chosenIngredients);
    }

    public void DeliverAndRequestFood()
    {
        var food = CreateFood();
        var success = Deliver(food);
        if (success) { ApplyFoodEffect(food); Trash(); Request(); }
        else { Debug.LogWarning("Requested Food and Delivered Food do not match."); }
    }

    private bool Deliver(Food food)
    {
        var success = RequestManager.Compare(food);
        return success;
    }

    private void Request()
    {
        RequestManager.PoolRequest.Invoke();
    }

    public void Trash()
    {
        m_chosenIngredients.Clear();
        m_inventoryDisplay.UpdateText(m_chosenIngredients);
    }

    private Food CreateFood()
    {
        var result = Mixing.Mix(m_chosenIngredients, out Food food);
        if (result == true) return food;
        else { Debug.LogError("Unable to Create Food"); return null; }
    }

    private void ApplyFoodEffect(Food food)
    {
        GainIngredientValue(food);
        food.ApplyEffect();
    }

    private int SumPoints(Food food)
    {
        var pointsToAdd = 0;
        foreach (var ingredient in food.IngredientsUsed) pointsToAdd += ingredient.IngredientValue;
        return pointsToAdd;
    }

    // TODO: Move to a different class.
    public void RecoverStrength(Food food)
    {
        var add = food.FoodEffect.EffectValue;
        m_reputation += add;
    }
}