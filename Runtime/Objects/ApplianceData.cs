using System.Collections.Generic;
using CookingSystem.State;

namespace CookingSystem.Data
{
    internal class ApplianceData
    {
        private readonly FoodState _foodState;
        private readonly HashSet<IngredientData> _ingredientMap = new();
        internal HashSet<IngredientData> IngredientMap => _ingredientMap;

        public ApplianceData(FoodState foodState) => _foodState = foodState;
        public void Add(IngredientData ingredientData) => _ingredientMap.Add(ingredientData);
        public void Clear() => _ingredientMap.Clear();
        public void Cook() { foreach (var ingredient in _ingredientMap) ingredient.Cook(_foodState); }
    }
}