using UnityEngine;

public class CookingExample : MonoBehaviour
{
    // private EventBinding<StorageEvent> m_storageEvent;
    // private EventBinding<TrayEvent> m_trayEvent;
    // private EventBinding<CookEvent> m_cookEvent;
    // private EventBinding<PlateEvent> m_plateEvent;
    // private EventBinding<DeliverEvent> m_deliverEvent;

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
        // m_storageEvent = new EventBinding<StorageEvent>(GetFromStorage);
        // m_trayEvent = new EventBinding<TrayEvent>(SetOnTray);
        // m_cookEvent = new EventBinding<CookEvent>(CookFromTray);
        // m_plateEvent = new EventBinding<PlateEvent>(PlateFood);
        // m_deliverEvent = new EventBinding<DeliverEvent>(DeliverFood);
        
        m_storageEvent = new EventBinding<PassObjectEvent<Ingredient>>(GetFromStorage);
        m_trayEvent = new EventBinding<PassObjectEvent<Tray>>(SetOnTray);
        m_cookEvent = new EventBinding<PassObjectEvent<Appliance>>(CookFromTray);
        m_plateEvent = new EventBinding<PassObjectEvent<Plate>>(PlateFood);
        m_deliverEvent = new EventBinding<PassObjectEvent<DeliveryDriver>>(DeliverFood);
    }

    private void OnEnable()
    {
        // EventBus<StorageEvent>.Register(m_storageEvent);
        // EventBus<TrayEvent>.Register(m_trayEvent);
        // EventBus<CookEvent>.Register(m_cookEvent);
        // EventBus<PlateEvent>.Register(m_plateEvent);
        // EventBus<DeliverEvent>.Register(m_deliverEvent);
    }

    private void OnDisable()
    {
        // EventBus<StorageEvent>.Deregister(m_storageEvent);
        // EventBus<TrayEvent>.Deregister(m_trayEvent);
        // EventBus<CookEvent>.Deregister(m_cookEvent);
        // EventBus<PlateEvent>.Deregister(m_plateEvent);
        // EventBus<DeliverEvent>.Deregister(m_deliverEvent);
    }

    // private void GetFromStorage(StorageEvent @event)
    // {
    //     m_holdingIngredient = @event.@Ingredient;
    //     
    //     Debug.Log("Got: " + @event.@Ingredient.name);
    // }
    
    // private void SetOnTray(TrayEvent @event)
    // {
    //     @event.@Tray.AddToTray(m_holdingIngredient);
    //     m_holdingTray = @event.@Tray;
    //     
    //     Debug.Log("Place: " + m_holdingIngredient.name + " in " + @event.Tray.name);
    //     Debug.Log("Select: " + @event.@Tray.name);
    // }
    
    // private void CookFromTray(CookEvent @event)
    // {
    //     @event.Appliance.Cook(m_holdingTray);
    //     
    //     Debug.Log("Cook: " + m_holdingTray.name + " in " + @event.Appliance.name);
    // }
    
    // private void PlateFood(PlateEvent @event)
    // {
    //     @event.Plate.AddToPlate(m_holdingTray);
    //     m_holdingPlate = @event.Plate;
    //     
    //     Debug.Log("Plate: " + @event.Plate.name + " with " + m_holdingTray.name);
    //     Debug.Log("Select: " + @event.Plate.name);
    // }
    
    // private void DeliverFood(DeliverEvent @event)
    // {
    //     bool successful = @event.Driver.Deliver(m_holdingPlate);
    //     if (successful) @event.Driver.Request();
    //     
    //     Debug.Log("Deliver: " + m_holdingPlate);
    //     Debug.Log("The delivery was: " + successful);
    // }
    
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