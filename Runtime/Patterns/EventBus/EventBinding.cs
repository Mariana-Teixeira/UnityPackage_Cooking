using System;

namespace CookingSystem.Events
{
    public interface IEvent { }

    public class EventBinding<T> where T : IEvent
    {
        public Action<T> OnEvent { get; }
        public Action OnEventNoArgs { get; }

        public EventBinding(Action<T> onEvent) => OnEvent = onEvent;
        public EventBinding(Action onEventNoArgs) => OnEventNoArgs = onEventNoArgs;
    }   
}