using System.Collections.Generic;
using System.Linq;

namespace CookingSystem.States
{
    public class StateMachine
    {
        private readonly Dictionary<IState, Node> _nodes = new();
        private Node _currentNode;

        public IState CurrentState => _currentNode.State;

        public void Evaluate()
        {
            Transition transition = GetTransition();
            if (transition != null)
            {
                ChangeState(transition.To);
            }
        }

        public void AddTransition(IState from, IState to, ICondition condition)
        {
            GetNode(from).AddTransition(GetNode(to).State, condition);
        }

        private Transition GetTransition()
        {
            return _currentNode.Transitions.FirstOrDefault(transition => transition.Condition.Evaluate());
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
}