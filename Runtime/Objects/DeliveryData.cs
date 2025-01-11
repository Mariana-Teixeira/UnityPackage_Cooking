namespace CookingSystem.Data
{
     internal class DeliveryData
     {
         private RecipeSO _requestedRecipeSO;
         private DishData _deliveredDish;

         internal RecipeSO RequestRecipe => _requestedRecipeSO;
         internal DishData DeliveredDish => _deliveredDish;
         
         internal DeliveryData() { }

         internal void Set(RecipeSO requestRecipe) => _requestedRecipeSO = requestRecipe;
         internal void Set(DishData deliveredDishData) => _deliveredDish = deliveredDishData;
         internal void Clear() { _requestedRecipeSO = null; _deliveredDish = null; }
     }
}