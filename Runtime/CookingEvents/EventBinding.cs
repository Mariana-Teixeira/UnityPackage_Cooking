using System;

namespace CookingSystem.Events
{
    public interface ICookEvent { }

    public class EventBinding<T> where T : ICookEvent
    {
        public Action<T> OnEvent { get; }
        public Action OnEventNoArgs { get; }

        public EventBinding(Action<T> onEvent) => OnEvent = onEvent;
        public EventBinding(Action onEventNoArgs) => OnEventNoArgs = onEventNoArgs;
    }   
}