namespace CookingSystem.Data
{
     internal class Delivery
     {
         private RecipeSO _requestedRecipeSO;
         private Dish _deliveredDish;

         internal RecipeSO RequestRecipe => _requestedRecipeSO;
         internal Dish DeliveredDish => _deliveredDish;
         
         internal Delivery() { }

         internal void Set(RecipeSO requestRecipe) => _requestedRecipeSO = requestRecipe;
         internal void Set(Dish deliveredDish) => _deliveredDish = deliveredDish;
         internal void Clear() { _requestedRecipeSO = null; _deliveredDish = null; }
     }
}