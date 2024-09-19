using System;
using UnityEngine;

public class RequestManager : MonoBehaviour
{
    /// <summary>
    /// Return whether the recipe of the food is the same as the recipe required in the current request.
    /// </summary>
    public static Func<Food, bool> Compare;
    public static Action PoolRequest;

    private RequestDisplay m_requestDisplay;
    private SO_Recipe[] m_allRecipes;
    private Request m_currentRequest;

    private void Awake()
    {
        m_requestDisplay = GetComponentInChildren<RequestDisplay>();
        m_allRecipes = Loader.Recipes.ToArray();
    }

    private void OnEnable()
    {
        Compare += OnCompare;
        PoolRequest += OnPoolRequest;
    }

    private void OnDisable()
    {
        Compare -= OnCompare;
        PoolRequest -= OnPoolRequest;
    }

    private bool OnCompare(Food food)
    {
        if (food.RecipeCreated == null) Debug.LogError("OnCompare: Food Recipe is null");

        if (food.RecipeCreated == m_currentRequest.RequestRecipe) return true;
        else return false;
    }

    private void OnPoolRequest()
    {
        var randomIndex = UnityEngine.Random.Range(0, m_allRecipes.Length);
        m_currentRequest = new Request(m_allRecipes[randomIndex]);

        if (m_allRecipes[randomIndex] == null) Debug.LogError("Can't find recipe.");
        else m_requestDisplay.UpdateDisplay(m_currentRequest);
    }
}
