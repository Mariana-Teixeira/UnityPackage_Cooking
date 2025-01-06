using System.Collections.Generic;
using CookingSystem.State;
using UnityEngine;

namespace CookingSystem.Data
{
    internal static class Loader
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
        
        internal static bool Compare(DishData dishData, RecipeSO recipe)
        {
            var requested = recipe.Instructions;
            var delivered = dishData.IngredientMap;
     
            foreach (var requirement in requested)
            {
                FoodState requestedState = requirement.State;
                var requestedIngredients = new HashSet<IngredientSO>(requirement.Ingredients);
     
                if (!delivered.TryGetValue(requestedState, out var deliveredIngredients)) return false;
                if (!deliveredIngredients.SetEquals(requestedIngredients)) return false;
            }
     
            return true;
        }
    }
}