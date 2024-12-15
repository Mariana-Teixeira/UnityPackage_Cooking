using System.Collections.Generic;

namespace CookingSystem
{ 
    public class Dish : IContainer, IProduct
    {
        public Dictionary<CookState, HashSet<IngredientSO>> IngredientMap { get; } = new();

        private void Add(IProduct product)
        {
            if (product is Ingredient ingredient) Add(ingredient);
            else if (product is Tray tray) Add(tray);
        }

        private void Add(Ingredient ingredient)
        {
            GetMap(CookState.Raw).Add(ingredient.GetIngredient);
        }
        
        private void Add(Tray tray)
        {
            GetMap(tray.CurrentState).UnionWith(tray.IngredientMap);
        }

        private void Clear()
        {
            IngredientMap.Clear();
        }
        
        private HashSet<IngredientSO> GetMap(CookState state)
        {
            if (!IngredientMap.ContainsKey(state)) IngredientMap.Add(state, new HashSet<IngredientSO>());
            return IngredientMap[state];
        }

        #region Interface Functions
        public void Empty() => Clear();
        public void Store(IProduct product) => Add(product);
        #endregion
    }
}
