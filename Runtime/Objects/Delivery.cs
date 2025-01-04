using UnityEngine;

namespace CookingSystem
{
     public class Delivery
     {
         private RecipeSO _requestedRecipeSO;

         public void Deliver(Dish deliveredDish)
         {
             var delivery = Loader.Compare(deliveredDish, _requestedRecipeSO);
             Debug.Log($"Delivery: {delivery}");
         }
         
         private void RequestRandom()
         {
             _requestedRecipeSO = Loader.GetRandomRecipe();
             Debug.Log(_requestedRecipeSO.name);
         }

         public void Request(RecipeSO requestRecipe)
         {
             _requestedRecipeSO = requestRecipe;
         }
     }
}