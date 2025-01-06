using UnityEngine;

namespace CookingSystem.Data
{
    public class DeliveryComponent : MonoBehaviour
    {
        private DeliveryData _deliveryData;

        protected virtual void Awake()
        {
            _deliveryData = new DeliveryData();
        }

        protected bool Deliver(DishComponent dish) => _deliveryData.Deliver(dish.GetDishData);
        protected virtual void Order(RecipeSO recipe) => _deliveryData.Request(recipe);
    }
}