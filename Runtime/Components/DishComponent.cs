using UnityEngine;

namespace CookingSystem.Data
{
    public class DishComponent : MonoBehaviour
    {
        private DishData _dishData;
        internal DishData GetDishData => _dishData;

        internal DishComponent Add(DishData dishData)
        {
            _dishData = dishData;
            return this;
        }
    }
}