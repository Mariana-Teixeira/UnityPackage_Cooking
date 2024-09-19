using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class FoodDelivery : MonoBehaviour
{
    private int m_money = 0;
    private int m_reputation = 0;

    private List<SO_Ingredient> m_chosenIngredients = new List<SO_Ingredient>();

    private MixManager m_mixManager;

    private void Awake()
    {
        m_mixManager = FindAnyObjectByType<MixManager>();
    }

    private void GainIngredientValue(Food food)
    {
        var add = SumPoints(food);
        m_money += add;
    }

    public void RecoverStrength(Food food)
    {
        var add = food.FoodEffect.EffectValue;
        m_reputation += add;
    }

    public void GrabIngredient(string ingredientName)
    {
        var ingredient = Loader.Ingredients[ingredientName];
        m_chosenIngredients.Add(ingredient);
    }

    public void Trash()
    {
        m_chosenIngredients.Clear();
    }

    public Food CreateFood()
    {
        var result = m_mixManager.Mix(m_chosenIngredients, out Food food);
        if (result == true) return food;
        else { Debug.LogError("Unable to Create Food"); return null; }
    }

    public bool DeliverFood()
    {
        var food = CreateFood();
        var request = RequestManager.GetCurrentRequest.Invoke();

        if (food.RecipeCreated != request.RequestRecipe) { Debug.LogWarning("Recipes don't match."); return false; }

        GainIngredientValue(food);
        food.ApplyEffect();
        return true;
    }

    private int SumPoints(Food food)
    {
        var pointsToAdd = 0;
        foreach (var ingredient in food.IngredientsUsed) pointsToAdd += ingredient.IngredientValue;
        return pointsToAdd;
    }
}