using System.Collections.Generic;

namespace CookingSystem
{ 
    public class Dish
    {
        public Dictionary<FoodState, HashSet<IngredientSO>> IngredientMap { get; } = new();

        public Dish(HashSet<Ingredient> ingredients)
        {
            Add(ingredients);
        }

        private void Add(Ingredient ingredient)
        {
            GetMap(ingredient.GetFoodState).Add(ingredient.GetIngredientData);
        }
        
        private void Add(HashSet<Ingredient> ingredients)
        {
            foreach (var ingredient in ingredients)
            {
                GetMap(ingredient.GetFoodState).Add(ingredient.GetIngredientData);
            }
        }

        private void Clear()
        {
            IngredientMap.Clear();
        }
        
        private HashSet<IngredientSO> GetMap(FoodState state)
        {
            if (!IngredientMap.ContainsKey(state)) IngredientMap.Add(state, new HashSet<IngredientSO>());
            return IngredientMap[state];
        }
    }
}
