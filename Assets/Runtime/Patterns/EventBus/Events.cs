public struct GrabEvent<T> : IEvent where T : IGrab
{
    public readonly T TargetObject;

    public GrabEvent(T targetObject)
    {
          TargetObject = targetObject;
    }
}

public struct DropEvent<T> : IEvent where T : IGrab
{
    public readonly T TargetObject;

    public DropEvent(T targetObject)
    {
        TargetObject = targetObject;
    }
}

public struct UseEvent<T> : IEvent where T : IUse
{
    public readonly T TargetObject;

    public UseEvent(T targetObject)
    {
        TargetObject = targetObject;
    }
}