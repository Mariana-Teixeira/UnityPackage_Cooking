namespace CookingSystem
{
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

    public struct DeliverEvent : IEvent
    {
        public readonly bool IsCorrect;

        public DeliverEvent(bool isCorrect)
        {
            IsCorrect = isCorrect;
        }
    }   
}