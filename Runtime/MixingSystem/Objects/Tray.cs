using System.Collections.Generic;

namespace CookingSystem
{
    public class Tray : IContainer, IProduct
    {
        public CookState CurrentState { get; private set; } = CookState.Raw;
        public HashSet<IngredientSO> IngredientMap { get; } = new();

        private void Add(IProduct product)
        {
            if (product is Ingredient ingredient) Add(ingredient);
        }
        
        private void Add(Ingredient ingredient)
        {
            IngredientMap.Add(ingredient.GetIngredient);
        }
        
        private void Clear()
        {
            IngredientMap.Clear();
            CurrentState = CookState.Raw;
        }

        public void ChangeState(CookState state)
        {
            CurrentState = state;   
        }
        
        #region Interface Functions
        public void Empty() => Clear();
        public void Store(IProduct product) => Add(product);
        #endregion
    }
}