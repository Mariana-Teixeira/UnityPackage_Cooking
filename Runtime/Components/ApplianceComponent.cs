using System.Collections;
using CookingSystem.Data;
using CookingSystem.State;
using UnityEngine;

namespace CookingSystem.Components
{
    public class ApplianceComponent : MonoBehaviour
    {
        [SerializeField] private FoodState _foodState;
        private ApplianceData _applianceData;

        protected virtual void Awake()
        {
            _applianceData = new ApplianceData(_foodState);
        }

        protected virtual void Add(IngredientComponent ingredientComponent)
        {
            _applianceData.Add(ingredientComponent.GetIngredientData);
        }

        protected virtual void Clear()
        {
            _applianceData.Clear();
        }
        
        protected virtual IEnumerator Cook(float time)
        {
            yield return new WaitForSeconds(time);
            _applianceData.Cook();
        }

        protected DishComponent InstantiateDish(GameObject @object, Transform parent)
        {
            var dish = new DishData(_applianceData.IngredientMap);
            return Instantiate(@object, parent).AddComponent<DishComponent>().Add(dish);
        }
    }
}