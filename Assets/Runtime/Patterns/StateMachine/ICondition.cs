using System;

public interface ICondition
{
    public bool Compare<T>(T compare);
}

public readonly struct CompareCondition<T> : ICondition
{
    private readonly T m_state;

    public CompareCondition(T state)
    {
        m_state = state;
    }

    public bool Compare<T>(T state) => m_state.Equals(state);
}

public readonly struct InvokeCondition : ICondition
{
    private readonly Func<bool> m_condition;

    public InvokeCondition(Func<bool> condition)
    {
        m_condition = condition;
    }
    
    public bool Compare<T>(T compare) => m_condition.Invoke();
}