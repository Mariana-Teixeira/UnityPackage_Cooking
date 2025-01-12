using System.Collections.Generic;
using CookingSystem.State;

namespace CookingSystem.Data
{
    internal class Appliance
    {
        private readonly FoodState _foodState;
        private readonly HashSet<Ingredient> _ingredientMap = new();
        internal HashSet<Ingredient> IngredientMap => _ingredientMap;

        internal Appliance(FoodState foodState) => _foodState = foodState;
        internal void Add(Ingredient ingredient) => _ingredientMap.Add(ingredient);
        internal void Clear() => _ingredientMap.Clear();
        internal void Cook() { foreach (var ingredient in _ingredientMap) ingredient.Cook(_foodState); }
    }
}