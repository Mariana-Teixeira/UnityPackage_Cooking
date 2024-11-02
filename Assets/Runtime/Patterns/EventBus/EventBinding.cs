using System;

public interface IEvent { }

public class EventBinding<T> where T : IEvent
{
    public Action<T> OnEvent { get; set; }
    public Action OnEventNoArgs { get; set; }

    public EventBinding(Action<T> onEvent) => OnEvent = onEvent;

    public EventBinding(Action onEventNoArgs) => OnEventNoArgs = onEventNoArgs;
}