using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CookingSystem.Data
{
    internal static class RecipeLoader
    {
        private static RecipeSO[] _recipes;
        private static bool _hasLoaded = false;

        private static void Load()
        {
            _recipes = Resources.LoadAll<RecipeSO>("Recipes");
            _hasLoaded = true;
        }

        internal static RecipeSO GetRandomRecipe()
        {
            if (!_hasLoaded) Load();
            var index = Random.Range(0, _recipes.Length);
            return _recipes[index];
        }

        internal static bool MatchDish(Dish dish, out RecipeSO recipe)
        {
            if (!_hasLoaded) Load();
            var matchingCount = _recipes.Where(x => x.Data.Length == dish.IngredientMap.Count);
            foreach (var value in matchingCount)
            {
                var map = new HashSet<IngredientData>(value.Data);
                if (!map.SetEquals(dish.IngredientMap)) continue;
                Debug.Log("Match Found");
                recipe = value;
                return true;
            }
            Debug.Log("No Match Found");
            recipe = null;
            return false;
        }

        internal static bool CompareDish(Dish dish, RecipeSO recipe)
        {
            return dish.MatchingRecipe == recipe;
        }
    }
}