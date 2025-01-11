using UnityEngine;

namespace CookingSystem.Data
{
    public class DeliveryComponent : MonoBehaviour
    {
        private DeliveryData _deliveryData;
        private bool Compare => Loader.Compare(_deliveryData.DeliveredDish, _deliveryData.RequestRecipe);

        protected virtual void Awake()
        {
            _deliveryData = new DeliveryData();
        }
        
        protected virtual void Set(RecipeSO recipe)
        {
            _deliveryData.Set(recipe);
        }

        protected virtual void Set(DishComponent dish)
        {
            _deliveryData.Set(dish.GetDishData);
        }

        protected virtual void Clear()
        {
            _deliveryData.Clear();
        }

        protected void Deliver()
        {
            if (Compare) SuccessfulDelivery();
            else FailedDelivery();
        }

        protected virtual void SuccessfulDelivery()
        {
            
        }

        protected virtual void FailedDelivery()
        {
            
        }
    }
}