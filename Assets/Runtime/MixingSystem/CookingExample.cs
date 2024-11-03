using UnityEngine;

public class CookingExample : MonoBehaviour
{
    private EventBinding<PassObjectEvent<Ingredient>> m_storageEvent;
    private EventBinding<PassObjectEvent<Tray>> m_trayEvent;
    private EventBinding<PassObjectEvent<Appliance>> m_cookEvent;
    private EventBinding<PassObjectEvent<Plate>> m_plateEvent;
    private EventBinding<PassObjectEvent<DeliveryDriver>> m_deliverEvent;
    
    public Ingredient m_holdingIngredient;
    private Tray m_holdingTray;
    private Plate m_holdingPlate;

    private void Awake()
    {
        m_storageEvent = new EventBinding<PassObjectEvent<Ingredient>>(GetFromStorage);
        m_trayEvent = new EventBinding<PassObjectEvent<Tray>>(SetOnTray);
        m_cookEvent = new EventBinding<PassObjectEvent<Appliance>>(CookFromTray);
        m_plateEvent = new EventBinding<PassObjectEvent<Plate>>(PlateFood);
        m_deliverEvent = new EventBinding<PassObjectEvent<DeliveryDriver>>(DeliverFood);
    }

    private void OnEnable()
    {
        EventBus<PassObjectEvent<Ingredient>>.Register(m_storageEvent);
        EventBus<PassObjectEvent<Tray>>.Register(m_trayEvent);
        EventBus<PassObjectEvent<Appliance>>.Register(m_cookEvent);
        EventBus<PassObjectEvent<Plate>>.Register(m_plateEvent);
        EventBus<PassObjectEvent<DeliveryDriver>>.Register(m_deliverEvent);
    }

    private void OnDisable()
    {
        EventBus<PassObjectEvent<Ingredient>>.Deregister(m_storageEvent);
        EventBus<PassObjectEvent<Tray>>.Deregister(m_trayEvent);
        EventBus<PassObjectEvent<Appliance>>.Deregister(m_cookEvent);
        EventBus<PassObjectEvent<Plate>>.Deregister(m_plateEvent);
        EventBus<PassObjectEvent<DeliveryDriver>>.Deregister(m_deliverEvent);
    }
    
    private void GetFromStorage(PassObjectEvent<Ingredient> @event)
    {
        m_holdingIngredient = @event.TargetObject;
        Debug.Log("Got: " + @event.TargetObject.name);
    }
    
    private void SetOnTray(PassObjectEvent<Tray> @event)
    {
        @event.TargetObject.AddToTray(m_holdingIngredient);
        m_holdingTray = @event.TargetObject;
        Debug.Log("Place: " + m_holdingIngredient.name + " in " + @event.TargetObject.name);
        Debug.Log("Select: " + @event.TargetObject.name);
    }
    
    private void CookFromTray(PassObjectEvent<Appliance> @event)
    {
        @event.TargetObject.Cook(m_holdingTray);
        Debug.Log("Cook: " + m_holdingTray.name + " in " + @event.TargetObject.name);
    }
    
    private void PlateFood(PassObjectEvent<Plate> @event)
    {
        @event.TargetObject.AddToPlate(m_holdingTray);
        m_holdingPlate = @event.TargetObject;
        Debug.Log("Plate: " + @event.TargetObject.name + " with " + m_holdingTray.name);
        Debug.Log("Select: " + @event.TargetObject.name);
    }
    
    private void DeliverFood(PassObjectEvent<DeliveryDriver> @event)
    {
        bool successful = @event.TargetObject.Deliver(m_holdingPlate);
        if (successful) @event.TargetObject.Request();
        Debug.Log("Deliver: " + m_holdingPlate);
        Debug.Log("The delivery was: " + successful);
    }
}