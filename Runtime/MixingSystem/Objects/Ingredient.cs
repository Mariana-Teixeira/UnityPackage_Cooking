namespace CookingSystem
{
    public class Ingredient : IProduct
    { 
        private readonly IngredientSO _ingredientSO;
        public IngredientSO GetIngredient => _ingredientSO;

        public Ingredient(IngredientSO ingredientSo)
        {
            _ingredientSO = ingredientSo;
        }
    }
}