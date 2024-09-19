using System.Collections.Generic;
using System.Linq;

public static class Mixing
{
    public static bool Mix(List<SO_Ingredient> chosenIngredients, out Food createdFood)
    {
        var recipe = MixingIngredients(chosenIngredients);
        var effect = RetrieveEffect(chosenIngredients);

        if (recipe == null)
        {
            createdFood = null;
            return false;
        }
        else
        {
            createdFood = new Food(recipe, chosenIngredients, effect);
            return true;
        }
    }

    public static SO_Recipe MixingIngredients(List<SO_Ingredient> inventory)
    {
        var matchingRecipes = Loader.
            Recipes.Where(recipe =>
            recipe.RequiredIngredients.All(ing =>
            inventory.Contains(ing)));

        var orderedRecipes = matchingRecipes.OrderByDescending(recipe =>
            recipe.RequiredIngredients.Count(ing =>
            inventory.Contains(ing)));

        if (orderedRecipes.Count() > 0) return orderedRecipes.First();
        else return null;
    }

    public static SO_Effect RetrieveEffect(List<SO_Ingredient> ingredients)
    {
        var possibleEffects = ingredients.Where(ingredient =>
            ingredient.HasEffect).Select(ingredient =>
            ingredient.Effect);

        if (possibleEffects.Count() < 0) return null;

        var groupingEffects = possibleEffects.GroupBy(effect =>
            effect);

        if (groupingEffects.Count() == 1) return Loader.Effects[possibleEffects.First()];
        else return null;
    }

    public static int GetPoints(Food food)
    {
        var pointsToAdd = 0;
        foreach (var ingredient in food.IngredientsUsed) pointsToAdd += ingredient.IngredientValue;
        return pointsToAdd;
    }
}