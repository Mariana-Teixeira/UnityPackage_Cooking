using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

public class RecipeTests
{
    [Test]
    public void IngredientsHaveRecipes()
    {
        var allIngredients = Loader.Ingredients.Values.ToList();
        foreach (var ingredient in allIngredients)
        {
            var singleIngredientList = new List<SO_Ingredient> { ingredient };
            var result = Mixing.MixingIngredients(singleIngredientList);
            Assert.NotNull(result, $"{ingredient} isn't able to use only itself in a recipe.");
        }
    }
}
