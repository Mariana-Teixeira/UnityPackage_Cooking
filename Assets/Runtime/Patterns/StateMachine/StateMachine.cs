using System.Collections.Generic;

public class StateMachine
{
    private readonly Dictionary<IState, Node> m_nodes = new();
    private Node m_currentNode;

    public void Update()
    {
        foreach (var transition in m_currentNode.Transitions)
        {
            if (!transition.Condition.Evaluate()) return;
            ChangeState(transition.To);
        }
    }

    public void AddTransition(IState from, IState to, ICondition condition)
    {
        GetNode(from).AddTransition(GetNode(to).State, condition);
    }
    
    public void SetState(IState state)
    {
        m_currentNode = GetNode(state);
    }

    private Node GetNode(IState from)
    {
        if (!m_nodes.ContainsKey(from)) m_nodes.Add(from, new Node(from));
        return m_nodes[from];
    }

    private void ChangeState(IState state)
    {
        if (m_currentNode.State == state) return;
        
        m_currentNode.State.OnExit();
        SetState(state);
        m_currentNode.State.OnEnter();
    }
}

public class Node
{
    public readonly IState State;
    public readonly HashSet<Transition> Transitions;

    public Node(IState state)
    {
        State = state;
        Transitions = new HashSet<Transition>();
    }

    public void AddTransition(IState to, ICondition condition)
        => Transitions.Add(new Transition(State, to, condition));
}

public interface IState
{
    public void OnEnter();
    public void OnExit();
}

public class Transition
{
    public readonly IState From;
    public readonly IState To;
    public readonly ICondition Condition;

    public Transition(IState from, IState to, ICondition condition)
    {
        From = from;
        To = to;
        Condition = condition;
    }
}

public interface ICondition
{
    public bool Evaluate();
}