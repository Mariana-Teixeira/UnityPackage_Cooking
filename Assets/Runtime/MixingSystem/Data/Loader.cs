using System.Collections.Generic;
using UnityEngine;

public static class Loader
{
    private static Dictionary<string, SO_Ingredient> m_ingredients = new Dictionary<string, SO_Ingredient>();
    private static Dictionary<string, SO_Effect> m_effects = new Dictionary<string, SO_Effect>();
    private static List<SO_Recipe> m_recipes = new List<SO_Recipe>();
    private static bool m_complete = false;

    public static Dictionary<string, SO_Ingredient> Ingredients
    {
        get
        {
            if (!m_complete) Load();
            return m_ingredients;
        }
    }
    public static Dictionary<string, SO_Effect> Effects
    {
        get
        {
            if (!m_complete) Load();
            return m_effects;
        }
    }
    public static List<SO_Recipe> Recipes
    {
        get
        {
            if (!m_complete) Load();
            return m_recipes;
        }
    }

    private static void Load()
    {
        var ingList = Resources.LoadAll<SO_Ingredient>("Ingredients");
        foreach (var item in ingList)  m_ingredients.Add(item.name, item);

        var effList = Resources.LoadAll<SO_Effect>("Effects");
        foreach (var item in effList) m_effects.Add(item.name, item);

        var recList = Resources.LoadAll<SO_Recipe>("Recipes");
        foreach (var item in recList) m_recipes.Add(item);

        m_complete = true;
    }
}