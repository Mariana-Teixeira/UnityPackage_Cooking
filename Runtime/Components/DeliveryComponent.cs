using UnityEngine;

namespace CookingSystem.Data
{
    public class DeliveryComponent : MonoBehaviour
    {
        private Delivery _delivery;
        private bool Compare => RecipeLoader.CompareDish(_delivery.DeliveredDish, _delivery.RequestRecipe);

        protected virtual void Awake()
        {
            _delivery = new Delivery();
        }
        
        protected virtual void Set(RecipeSO recipe)
        {
            _delivery.Set(recipe);
        }

        protected virtual void Set(DishComponent dish)
        {
            _delivery.Set(dish.GetDish);
        }

        protected virtual void Clear()
        {
            _delivery.Clear();
        }

        protected void Deliver()
        {
            if (Compare) SuccessfulDelivery();
            else FailedDelivery();
        }

        protected virtual void SuccessfulDelivery() { }

        protected virtual void FailedDelivery() { }
    }
}