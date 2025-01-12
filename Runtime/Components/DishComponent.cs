using UnityEngine;
using UnityEngine.Pool;

namespace CookingSystem.Data
{
    public class DishComponent : MonoBehaviour
    {
        private Dish _dish;
        private IObjectPool<DishComponent> _dishPool;
        internal Dish GetDish => _dish;
        protected RecipeSO GetRecipe => _dish.MatchingRecipe;
        protected bool HasMatch => _dish.FoundMatch;

        internal DishComponent SetPool(IObjectPool<DishComponent> dishPool)
        {
            _dishPool = dishPool;
            return this;
        }

        internal DishComponent SetDish(Dish dish)
        {
            _dish = dish;
            Setup();
            return this;
        }

        protected virtual void Setup()
        { }

        protected void OverrideRecipe(RecipeSO recipe) => GetDish.MatchingRecipe = recipe;
        public void ReleaseSelf() => _dishPool.Release(this);
    }
}