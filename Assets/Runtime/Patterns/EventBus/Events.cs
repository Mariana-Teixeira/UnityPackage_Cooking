public struct GrabObject<T> : IEvent
{
    public readonly T TargetObject;

    public GrabObject(T targetObject)
    {
          TargetObject = targetObject;
    }
}

public struct DropOnObject<T1, T2> : IEvent
{
    public readonly T2 TargetObject;

    public DropOnObject(T2 targetObject)
    {
        TargetObject = targetObject;
    }
}