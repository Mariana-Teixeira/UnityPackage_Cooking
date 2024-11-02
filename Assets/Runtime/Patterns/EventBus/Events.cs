public readonly struct StorageEvent : IEvent
{
    public Ingredient @Ingredient { get; }

    public StorageEvent(Ingredient ingredient)
    {
        @Ingredient = ingredient;
    }
}

public struct ContainerEvent : IEvent
{
    public Tray @Tray { get; }

    public ContainerEvent(Tray tray)
    {
        @Tray = tray;
    }
}

public struct CookEvent : IEvent
{
    public Appliance @Appliance { get; }

    public CookEvent(Appliance appliance)
    {
        @Appliance = appliance;
    }
}

public struct PlateEvent : IEvent
{
    public Plate @Plate { get; }

    public PlateEvent(Plate plate)
    {
        @Plate = plate;
    }
}

public struct DeliverEvent : IEvent
{
    public DeliveryDriver Driver { get; }

    public DeliverEvent(DeliveryDriver driver)
    {
        Driver = driver;
    }
}