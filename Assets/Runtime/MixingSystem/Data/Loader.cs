using UnityEngine;

public static class Loader
{
    private static RecipeData[] m_recipes;
    private static bool m_hasLoaded = false;

    public static void Load()
    {
        m_recipes = Resources.LoadAll<RecipeData>("Recipes");
        m_hasLoaded = true;
    }

    public static RecipeData GetRecipe()
    {
        return null;
    }
}