using CookingSystem.Data;
using CookingSystem.State;
using UnityEngine;

namespace CookingSystem.Components
{
    public class IngredientComponent : MonoBehaviour
    {
        [SerializeField] private IngredientSO _ingredientSO;
        private Ingredient _ingredient;
        internal Ingredient getIngredient => _ingredient;

        protected virtual void Awake()
        {
            _ingredient = new Ingredient(_ingredientSO);
        }

        protected virtual void Cook(FoodState newState)
        {
            _ingredient.Cook(newState);
        }
    }
}