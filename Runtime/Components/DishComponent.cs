using UnityEngine;
using UnityEngine.Pool;

namespace CookingSystem.Data
{
    public class DishComponent : MonoBehaviour
    {
        private DishData _dishData;
        private IObjectPool<DishComponent> _dishPool;
        internal DishData GetDishData => _dishData;

        internal DishComponent Add(DishData dishData, IObjectPool<DishComponent> dishPool)
        {
            _dishData = dishData;
            _dishPool = dishPool;
            return this;
        }

        public void ReleaseSelf() => _dishPool.Release(this);
    }
}