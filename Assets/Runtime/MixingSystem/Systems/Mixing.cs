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

        if (orderedRecipes.Count() > 0)
        {
            UnityEngine.Debug.Log(orderedRecipes.First());
            return orderedRecipes.First();
        }
        else
        {
            return null;
        }
    }

    public static SO_Effect RetrieveEffect(List<SO_Ingredient> ingredients)
    {
        var possibleEffects = ingredients.Where(ingredient =>
            ingredient.HasEffect).Select(ingredient =>
            ingredient.Effect);

        if (possibleEffects.Count() < 0) return null;

        var groupingEffects = possibleEffects.GroupBy(effect =>
            effect);

        if (groupingEffects.Count() == 1)
        {
            UnityEngine.Debug.Log(Loader.Effects[possibleEffects.First()]);
            return Loader.Effects[possibleEffects.First()];
        }
        else
        {
            return null;
        }
    }
}