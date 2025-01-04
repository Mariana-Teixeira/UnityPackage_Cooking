namespace CookingSystem
{
    public class Ingredient
    {
        private FoodState _foodState = FoodState.Raw;
        private readonly IngredientSO _ingredientData;
        
        public FoodState GetFoodState => _foodState;
        public IngredientSO GetIngredientData => _ingredientData;

        public Ingredient(IngredientSO ingredientSo)
        {
            _ingredientData = ingredientSo;
        }

        public void ChangeState(FoodState newState)
        {
            _foodState = newState;
        }
    }
}