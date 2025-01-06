using System.Collections.Generic;

namespace CookingSystem.Events
{
    public static class EventBus<T> where T : ICookEvent
    {
        private static readonly HashSet<EventBinding<T>> _bindings = new();

        public static void Register(EventBinding<T> binding) => _bindings.Add(binding);
        public static void Deregister(EventBinding<T> binding) => _bindings.Remove(binding);

        public static void Raise(T @event)
        {
            foreach(var binding in _bindings)
            {
                binding.OnEvent?.Invoke(@event);
                binding.OnEventNoArgs?.Invoke();
            }
        }
    }
}