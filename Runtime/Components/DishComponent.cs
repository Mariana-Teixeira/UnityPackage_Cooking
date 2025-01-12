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

        internal DishComponent Make(Dish dish, IObjectPool<DishComponent> dishPool)
        {
            _dish = dish;
            _dishPool = dishPool;
            Setup();
            return this;
        }

        protected virtual void Setup() { }

        public void ReleaseSelf() => _dishPool.Release(this);
    }
}