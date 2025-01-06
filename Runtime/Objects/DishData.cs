using System.Collections.Generic;
using CookingSystem.State;

namespace CookingSystem.Data
{ 
    internal class DishData
    {
        private readonly Dictionary<FoodState, HashSet<IngredientSO>> _ingredientMap = new();
        public Dictionary<FoodState, HashSet<IngredientSO>> IngredientMap => _ingredientMap;

        public DishData(HashSet<IngredientData> ingredientMap)
        {
            foreach (var data in ingredientMap)
            {
                GetMap(data.GetFoodState).Add(data.GetIngredientData);
            }
        }
        
        private HashSet<IngredientSO> GetMap(FoodState state)
        {
            if (!_ingredientMap.ContainsKey(state)) _ingredientMap.Add(state, new HashSet<IngredientSO>());
            return _ingredientMap[state];
        }
    }
}
