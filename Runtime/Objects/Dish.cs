using System;
using System.Collections.Generic;

namespace CookingSystem.Data
{ 
    [Serializable]
    internal class Dish
    {
        private RecipeSO _matchingRecipe;
        private readonly HashSet<IngredientData> _ingredientMap = new();
        internal HashSet<IngredientData> IngredientMap => _ingredientMap;
        internal RecipeSO MatchingRecipe
        {
            get => _matchingRecipe;
            set => _matchingRecipe = value;
        }

        internal bool FoundMatch { get; private set; }
        internal Dish(HashSet<Ingredient> ingredientMap)
        {
            foreach (var data in ingredientMap) _ingredientMap.Add(data.GetIngredientData);
            FoundMatch = RecipeLoader.MatchDish(this, out _matchingRecipe);
        }
    }
}
