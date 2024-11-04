using System;

public interface ICondition
{
    public bool Compare(object compare);
}

public readonly struct CompareCondition<T> : ICondition
{
    private readonly T _state;

    public CompareCondition(T state)
    {
        _state = state;
    }

    public bool Compare(object state) => _state.Equals(state);
}

public readonly struct InvokeCondition : ICondition
{
    private readonly Func<bool> _condition;

    public InvokeCondition(Func<bool> condition)
    {
        _condition = condition;
    }
    
    public bool Compare(object compare) => _condition.Invoke();
}