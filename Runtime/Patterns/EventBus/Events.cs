namespace CookingSystem
{
    public struct StoreEvent<T> : IEvent where T : IContainer
    {
        public readonly T TargetObject;

        public StoreEvent(T targetObject)
        {
            TargetObject = targetObject;
        }
    }

    public struct EmptyEvent<T> : IEvent where T : IContainer
    {
        public readonly T TargetObject;

        public EmptyEvent(T targetObject)
        {
            TargetObject = targetObject;
        }
    }

    public struct DeliverEvent<T> : IEvent where T : IContainer
    {
        public readonly T TargetObject;

        public DeliverEvent(T targetObject)
        {
            TargetObject = targetObject;
        }
    }
}