using System.Collections.Generic;
using System.Linq;

public class StateMachine
{
    private readonly Dictionary<IState, Node> m_nodes = new();
    private Node m_currentNode;

    public void Compare<T>(T target)
    {
        Transition transition = GetTransition(target);
        if (transition != null)
        {
            ChangeState(transition.To);
        }
    }

    public void AddTransition(IState from, IState to, ICondition condition)
    {
        GetNode(from).AddTransition(GetNode(to).State, condition);
    }

    private Transition GetTransition<T>(T target)
    {
        return m_currentNode.Transitions.FirstOrDefault(transition => transition.Condition.Compare(target));
    }
    
    public void SetState(IState state)
    {
        m_currentNode = GetNode(state);
    }

    private Node GetNode(IState from)
    {
        if (!m_nodes.ContainsKey(from))
        {
            m_nodes.Add(from, new Node(from));
        }
        
        return m_nodes[from];
    }

    private void ChangeState(IState state)
    {
        if (m_currentNode.State == state) return;
        m_currentNode = GetNode(state);
        m_currentNode.State.OnEnter();
    }
}