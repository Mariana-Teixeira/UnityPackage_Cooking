using UnityEngine;

public static class Loader
{
    private static Recipe[] m_recipes;
    private static bool m_hasLoaded = false;

    private static void Load()
    {
        m_recipes = Resources.LoadAll<Recipe>("Recipes");
        m_hasLoaded = true;
    }

    public static Recipe GetRandomRecipe()
    {
        if (!m_hasLoaded) Load();
        int index = Random.Range(0, m_recipes.Length);
        return m_recipes[index];
    }
}