using System.Collections;
using CookingSystem.Data;
using CookingSystem.Events;
using CookingSystem.State;
using UnityEngine;
using UnityEngine.Pool;

namespace CookingSystem.Components
{
    public class ApplianceComponent : MonoBehaviour
    {
        [SerializeField] private FoodState _foodState;
        private ApplianceState _currentState;
        private Appliance _appliance;
        
        protected IObjectPool<DishComponent> _dishPool;
        [SerializeField] private GameObject _dishPrefab;
        [SerializeField] private int _maxSize = 20;
        [SerializeField] private int _defaultSize = 10;
            
        protected ApplianceState CurrentState => _currentState;
        

        protected virtual void Awake()
        {
            _currentState = ApplianceState.Empty;
            _appliance = new Appliance(_foodState);
            _dishPool = new ObjectPool<DishComponent>(InstantiateDish, GetDish, ReleaseDish, DestroyDish, true, _defaultSize, _maxSize);
        }

        protected virtual void Add(IngredientComponent ingredientComponent)
        {
            EventBus<AddIngredient>.Raise(new AddIngredient());
            
            _currentState = ApplianceState.Fill;
            _appliance.Add(ingredientComponent.getIngredient);
        }

        protected virtual void Clear()
        {
            _currentState = ApplianceState.Empty;
            _appliance.Clear();
        }

        protected virtual void StartCook()
        {
            EventBus<BeginCookingEvent>.Raise(new BeginCookingEvent());
            
            _currentState = ApplianceState.Cooking;
            _appliance.Cook();
        }

        protected virtual void EndCook()
        {
            EventBus<EndCookingEvent>.Raise(new EndCookingEvent());
        }
        
        protected IEnumerator Cook(float time)
        {
            StartCook();
            yield return new WaitForSeconds(time);
            EndCook();
        }
        
        private DishComponent InstantiateDish()
        {
            var dish = Instantiate(_dishPrefab).GetComponent<DishComponent>().SetPool(_dishPool);
            return dish;
        }

        private void GetDish(DishComponent dishComponent)
        {
            var data = new Dish(_appliance.IngredientMap);
            dishComponent.SetDish(data);
            dishComponent.gameObject.SetActive(true);
        }

        private void ReleaseDish(DishComponent dishComponent)
        {
            dishComponent.gameObject.SetActive(false);
        }

        private void DestroyDish(DishComponent dishComponent)
        {
            Destroy(dishComponent.gameObject);
        }
    }
}