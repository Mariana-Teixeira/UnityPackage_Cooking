using UnityEngine;

namespace CookingSystem
{
     public class Delivery : IContainer, ITool
     {
         private RecipeSO _requestedRecipeSO;
         private Dish _deliveredDish;
     
         private void Start()
         {
             Request();
         }

         private void Add(IProduct product)
         {
             if (product is Dish dish) Add(dish);
         }
     
         private void Add(Dish dish)
         {
             _deliveredDish = dish;
         }
     
         private void Clear()
         {
             _deliveredDish = null;
         }

         private void Deliver()
         {
             var delivery = Loader.Compare(_deliveredDish, _requestedRecipeSO);
             Debug.Log($"Delivery: {delivery}");
         }
         
         public void Request()
         {
             _requestedRecipeSO = Loader.GetRandomRecipe();
             Debug.Log(_requestedRecipeSO.name);
         }
         
         #region Interface Functions
         public void Empty() => Clear();
         public void Store(IProduct product) => Add(product);
         public void Use() => Deliver();
         #endregion
     }
}