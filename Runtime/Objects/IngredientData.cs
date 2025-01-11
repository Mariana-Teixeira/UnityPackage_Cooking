using CookingSystem.State;

namespace CookingSystem.Data
{
    internal class IngredientData
    {
        internal FoodState GetFoodState { get; private set; } = FoodState.Raw;
        internal IngredientSO GetIngredientData { get; }

        internal IngredientData(IngredientSO ingredientSo) =>  GetIngredientData = ingredientSo;
        internal void Cook(FoodState newState) => GetFoodState = newState;
    }
}