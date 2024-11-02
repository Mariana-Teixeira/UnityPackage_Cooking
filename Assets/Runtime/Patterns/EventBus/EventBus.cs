using System.Collections.Generic;
using Codice.Client.Common.Connection;

public static class EventBus<T> where T : IEvent
{
    private static readonly HashSet<EventBinding<T>> m_bindings = new();
    
    public static void Register(EventBinding<T> binding) =>  m_bindings.Add(binding);

    public static void Deregister(EventBinding<T> binding) => m_bindings.Remove(binding);

    public static void Raise(T @event)
    {
        foreach(var binding in m_bindings)
        {
            binding.OnEvent?.Invoke(@event);
            binding.OnEventNoArgs?.Invoke();
        }
    }
}