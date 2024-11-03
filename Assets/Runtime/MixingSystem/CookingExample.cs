using UnityEngine;

public class CookingExample : MonoBehaviour
{
    private EventBinding<PassEvent<Ingredient>> m_storageEvent;
    private EventBinding<PassEvent<Tray>> m_trayEvent;
    private EventBinding<PassEvent<Appliance>> m_cookEvent;
    private EventBinding<PassEvent<Plate>> m_plateEvent;
    private EventBinding<PassEvent<DeliveryDriver>> m_deliverEvent;
    
    public Ingredient m_holdingIngredient;
    private Tray m_holdingTray;
    private Plate m_holdingPlate;

    private void Awake()
    {
        m_storageEvent = new EventBinding<PassEvent<Ingredient>>(GetFromStorage);
        m_trayEvent = new EventBinding<PassEvent<Tray>>(SetOnTray);
        m_cookEvent = new EventBinding<PassEvent<Appliance>>(CookFromTray);
        m_plateEvent = new EventBinding<PassEvent<Plate>>(PlateFood);
        m_deliverEvent = new EventBinding<PassEvent<DeliveryDriver>>(DeliverFood);
    }

    private void OnEnable()
    {
        EventBus<PassEvent<Ingredient>>.Register(m_storageEvent);
        EventBus<PassEvent<Tray>>.Register(m_trayEvent);
        EventBus<PassEvent<Appliance>>.Register(m_cookEvent);
        EventBus<PassEvent<Plate>>.Register(m_plateEvent);
        EventBus<PassEvent<DeliveryDriver>>.Register(m_deliverEvent);
    }

    private void OnDisable()
    {
        EventBus<PassEvent<Ingredient>>.Deregister(m_storageEvent);
        EventBus<PassEvent<Tray>>.Deregister(m_trayEvent);
        EventBus<PassEvent<Appliance>>.Deregister(m_cookEvent);
        EventBus<PassEvent<Plate>>.Deregister(m_plateEvent);
        EventBus<PassEvent<DeliveryDriver>>.Deregister(m_deliverEvent);
    }
    
    private void GetFromStorage(PassEvent<Ingredient> @event)
    {
        m_holdingIngredient = @event.TargetObject;
        Debug.Log("Got: " + @event.TargetObject.name);
    }
    
    private void SetOnTray(PassEvent<Tray> @event)
    {
        @event.TargetObject.AddToTray(m_holdingIngredient);
        m_holdingTray = @event.TargetObject;
        Debug.Log("Place: " + m_holdingIngredient.name + " in " + @event.TargetObject.name);
        Debug.Log("Select: " + @event.TargetObject.name);
    }
    
    private void CookFromTray(PassEvent<Appliance> @event)
    {
        @event.TargetObject.Cook(m_holdingTray);
        Debug.Log("Cook: " + m_holdingTray.name + " in " + @event.TargetObject.name);
    }
    
    private void PlateFood(PassEvent<Plate> @event)
    {
        @event.TargetObject.AddToPlate(m_holdingTray);
        m_holdingPlate = @event.TargetObject;
        Debug.Log("Plate: " + @event.TargetObject.name + " with " + m_holdingTray.name);
        Debug.Log("Select: " + @event.TargetObject.name);
    }
    
    private void DeliverFood(PassEvent<DeliveryDriver> @event)
    {
        bool successful = @event.TargetObject.Deliver(m_holdingPlate);
        if (successful) @event.TargetObject.Request();
        Debug.Log("Deliver: " + m_holdingPlate);
        Debug.Log("The delivery was: " + successful);
    }
}