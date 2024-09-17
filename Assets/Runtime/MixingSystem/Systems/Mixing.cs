using System.Collections.Generic;
using System.Linq;

public static class Mixing
{
    public static SO_Recipe MixingIngredients(List<SO_Ingredient> inventory)
    {
        var matchingRecipes = Loader.
            Recipes.Where(recipe =>
            recipe.RequiredIngredients.All(ing =>
            inventory.Contains(ing)));

        var orderedRecipes = matchingRecipes.OrderByDescending(recipe =>
            recipe.RequiredIngredients.Count(ing =>
            inventory.Contains(ing)));

        foreach (var item in orderedRecipes)
        {
            UnityEngine.Debug.Log(item.name);
        }

        return orderedRecipes.First();
    }
}