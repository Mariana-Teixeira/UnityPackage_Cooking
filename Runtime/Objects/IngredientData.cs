using CookingSystem.State;

namespace CookingSystem.Data
{
    internal class IngredientData
    {
        public FoodState GetFoodState { get; private set; } = FoodState.Raw;
        public IngredientSO GetIngredientData { get; }

        public IngredientData(IngredientSO ingredientSo) =>  GetIngredientData = ingredientSo;
        public void Cook(FoodState newState) => GetFoodState = newState;
    }
}