namespace CookingSystem
{
     public class Delivery
     {
         private RecipeSO _requestedRecipeSO;

         public bool Deliver(Dish deliveredDish) => Loader.Compare(deliveredDish, _requestedRecipeSO);
         private void RequestRandom() => _requestedRecipeSO = Loader.GetRandomRecipe();
         public void Request(RecipeSO requestRecipe) => _requestedRecipeSO = requestRecipe;
     }
}