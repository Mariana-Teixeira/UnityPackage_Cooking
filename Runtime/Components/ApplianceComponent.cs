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
        private ApplianceData _applianceData;
        
        protected IObjectPool<DishComponent> _dishPool;
        [SerializeField] private GameObject _dishPrefab;
        [SerializeField] private int _maxSize = 20;
        [SerializeField] private int _defaultSize = 10;
            
        protected ApplianceState CurrentState => _currentState;
        

        protected virtual void Awake()
        {
            _currentState = ApplianceState.Empty;
            _applianceData = new ApplianceData(_foodState);
            _dishPool = new ObjectPool<DishComponent>(InstantiateDish, GetDish, ReleaseDish, DestroyDish, true, _defaultSize, _maxSize);
        }

        protected virtual void Add(IngredientComponent ingredientComponent)
        {
            EventBus<AddIngredient>.Raise(new AddIngredient());
            
            _currentState = ApplianceState.Fill;
            _applianceData.Add(ingredientComponent.GetIngredientData);
        }

        protected virtual void Clear()
        {
            _currentState = ApplianceState.Empty;
            _applianceData.Clear();
        }

        protected virtual void StartCook()
        {
            EventBus<BeginCookingEvent>.Raise(new BeginCookingEvent());
            
            _currentState = ApplianceState.Cooking;
            _applianceData.Cook();
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
            var data = new DishData(_applianceData.IngredientMap);
            var dish = Instantiate(_dishPrefab).AddComponent<DishComponent>().Add(data, _dishPool);
            return dish;
        }

        private void GetDish(DishComponent dishComponent)
        {
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