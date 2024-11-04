using System.Collections.Generic;
using System.Linq;

public class StateMachine
{
    private readonly Dictionary<IState, Node> _nodes = new();
    private Node _currentNode;

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
        return _currentNode.Transitions.FirstOrDefault(transition => transition.Condition.Compare(target));
    }
    
    public void SetState(IState state)
    {
        _currentNode = GetNode(state);
    }

    private Node GetNode(IState from)
    {
        if (!_nodes.ContainsKey(from))
        {
            _nodes.Add(from, new Node(from));
        }
        
        return _nodes[from];
    }

    private void ChangeState(IState state)
    {
        if (_currentNode.State == state) return;
        _currentNode = GetNode(state);
        _currentNode.State.OnEnter();
    }
}