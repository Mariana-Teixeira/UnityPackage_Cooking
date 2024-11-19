using UnityEngine;

public static class Loader
{
    private static Recipe[] _recipes;
    private static bool _hasLoaded = false;

    private static void Load()
    {
        _recipes = Resources.LoadAll<Recipe>("Recipes");
        _hasLoaded = true;
    }

    public static Recipe GetRandomRecipe()
    {
        if (!_hasLoaded) Load();
        int index = Random.Range(0, _recipes.Length);
        return _recipes[index];
    }
}