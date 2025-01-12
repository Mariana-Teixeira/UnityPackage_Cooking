using CookingSystem.State;

namespace CookingSystem.Data
{
    internal class Ingredient
    {
        private FoodState GetFoodState { get; set; } = FoodState.Raw;
        private IngredientSO GetIngredientSO { get; }
        internal IngredientData GetIngredientData => new IngredientData()
        {
            State = GetFoodState,
            Object = GetIngredientSO
        };
        

        internal Ingredient(IngredientSO ingredientSo) =>  GetIngredientSO = ingredientSo;
        internal void Cook(FoodState newState) => GetFoodState = newState;
    }
}