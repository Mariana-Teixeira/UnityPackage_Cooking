public struct PassEvent<T> : IEvent
{
    public readonly T TargetObject;

    public PassEvent(T targetObject)
    {
          TargetObject = targetObject;
    }
}