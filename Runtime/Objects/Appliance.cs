using System.Collections.Generic;

namespace CookingSystem
{
    public class Appliance
    {
        private readonly FoodState _foodState;
        private readonly HashSet<Ingredient> _ingredientMap = new();

        public Appliance(FoodState foodState)
        {
            _foodState = foodState;
        }

        public void Add(Ingredient ingredient)
        {
            _ingredientMap.Add(ingredient);
        }

        public void Clear()
        {
            _ingredientMap.Clear();
        }
        
        public Dish Cook()
        {
            foreach (var ingredient in _ingredientMap) ingredient.ChangeState(_foodState);
            return new Dish(_ingredientMap);
        }
    }   
}