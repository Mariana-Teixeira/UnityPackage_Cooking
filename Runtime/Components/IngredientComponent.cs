using CookingSystem.Data;
using CookingSystem.State;
using UnityEngine;

namespace CookingSystem.Components
{
    public class IngredientComponent : MonoBehaviour
    {
        [SerializeField] private IngredientSO _ingredientSO;
        private IngredientData _ingredientData;
        internal IngredientData GetIngredientData => _ingredientData;

        protected virtual void Awake()
        {
            _ingredientData = new IngredientData(_ingredientSO);
        }

        protected virtual void CookIngredient(FoodState newState)
        {
            _ingredientData.Cook(newState);
        }
    }
}