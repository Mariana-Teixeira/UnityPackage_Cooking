namespace CookingSystem.Data
{
     internal class DeliveryData
     {
         private RecipeSO _requestedRecipeSO;
         
         public DeliveryData() { } 

         internal bool Deliver(DishData deliveredDishData) => Loader.Compare(deliveredDishData, _requestedRecipeSO);
         internal void Request(RecipeSO requestRecipe) => _requestedRecipeSO = requestRecipe;
     }
}