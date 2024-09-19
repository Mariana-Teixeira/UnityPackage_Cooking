using System;
using UnityEngine;

public class RequestManager : MonoBehaviour
{
    private SO_Recipe[] m_allRecipes;
    private Request m_currentRequest;

    public static Func<Food, bool> CompareFoodAndRecipe;
    public static Action PoolRequest;

    private void Awake()
    {
        m_allRecipes = Loader.Recipes.ToArray();
    }

    private void OnEnable()
    {
        CompareFoodAndRecipe += OnCompareFoodAndRecipe;
        PoolRequest += OnPoolRequest;
    }

    private void OnDisable()
    {
        CompareFoodAndRecipe -= OnCompareFoodAndRecipe;
        PoolRequest -= OnPoolRequest;
    }

    private bool OnCompareFoodAndRecipe(Food food)
    {
        if (food.RecipeCreated == null) { Debug.LogError("OnCompare: Food Recipe is null"); return false; }

        if (food.RecipeCreated == m_currentRequest.RequestRecipe) return true;
        else return false;
    }

    private void OnPoolRequest()
    {
        var randomIndex = UnityEngine.Random.Range(0, m_allRecipes.Length);
        m_currentRequest = new Request(m_allRecipes[randomIndex]);

        if (m_allRecipes[randomIndex] == null) Debug.LogError("OnPoolRequest: Can't find recipe.");
        else RequestDisplay.SendDisplayText.Invoke(m_currentRequest);
    }
}
