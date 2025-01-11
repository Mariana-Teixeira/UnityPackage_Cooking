using System.Collections.Generic;
using CookingSystem.State;

namespace CookingSystem.Data
{
    internal class ApplianceData
    {
        private readonly FoodState _foodState;
        private readonly HashSet<IngredientData> _ingredientMap = new();
        internal HashSet<IngredientData> IngredientMap => _ingredientMap;

        internal ApplianceData(FoodState foodState) => _foodState = foodState;
        internal void Add(IngredientData ingredientData) => _ingredientMap.Add(ingredientData);
        internal void Clear() => _ingredientMap.Clear();
        internal void Cook() { foreach (var ingredient in _ingredientMap) ingredient.Cook(_foodState); }
    }
}