public readonly struct StorageEvent : IEvent
{
    public IngredientData ingredientData { get; }

    public StorageEvent(IngredientData ingredientData)
    {
        this.ingredientData = ingredientData;
    }
}

public struct ContainerEvent : IEvent
{
    public Container @Container { get; }

    public ContainerEvent(Container container)
    {
        @Container = container;
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

public struct DeliverEvent : IEvent
{
    public DeliverEvent(int i) { }
}