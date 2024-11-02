using UnityEngine;

public class CookingManager : MonoBehaviour
{
    private EventBinding<StorageEvent> m_storageEvent;
    private EventBinding<ContainerEvent> m_containerEvent;
    
    private Ingredient m_holdingIngredient;
    private Container m_container;

    private void Awake()
    {
        m_storageEvent = new EventBinding<StorageEvent>(GetFromStorage);
        m_containerEvent = new EventBinding<ContainerEvent>(SetFromContainer);
    }

    private void OnEnable()
    {
        EventBus<StorageEvent>.Register(m_storageEvent);
        EventBus<ContainerEvent>.Register(m_containerEvent);
    }

    private void OnDisable()
    {
        EventBus<StorageEvent>.Deregister(m_storageEvent);
        EventBus<ContainerEvent>.Deregister(m_containerEvent);
    }

    private void GetFromStorage(StorageEvent @event)
    {
        Debug.Log("Got: " + @event.ingredientData.name);
        m_holdingIngredient = new Ingredient(@event.ingredientData.name, @event.ingredientData.Category);
    }

    private void SetFromContainer(ContainerEvent @event)
    {
        Debug.Log("Set: " + m_holdingIngredient);
        @event.Container.AddToContainer(m_holdingIngredient);
        Debug.Log("Select: " + @event.Container.name);
        m_container = @event.Container;
    }

    private void CookFromCooker(CookEvent @event)
    {
        @event.Appliance.Cook(m_container);
        m_container = null;
    }
}