using System;
using CookingSystem.State;

namespace CookingSystem.Data
{
    [Serializable]
    public struct IngredientData
    {
        public FoodState State;
        public IngredientSO Object;
    }
}