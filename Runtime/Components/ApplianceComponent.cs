using System.Collections;
using CookingSystem.Data;
using CookingSystem.Events;
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
            EventBus<AddIngredient>.Raise(new AddIngredient());
            _applianceData.Add(ingredientComponent.GetIngredientData);
        }

        protected virtual void Clear()
        {
            _applianceData.Clear();
        }

        protected virtual void Cook()
        {
            _applianceData.Cook();
        }
        
        protected IEnumerator StartCookTimer(float time)
        {
            EventBus<BeginCookingEvent>.Raise(new BeginCookingEvent());
            yield return new WaitForSeconds(time); Cook();
            EventBus<EndCookingEvent>.Raise(new EndCookingEvent());
        }

        protected DishComponent InstantiateDish(GameObject @object, Transform parent)
        {
            var dish = new DishData(_applianceData.IngredientMap);
            return Instantiate(@object, parent).AddComponent<DishComponent>().Add(dish);
        }
    }
}