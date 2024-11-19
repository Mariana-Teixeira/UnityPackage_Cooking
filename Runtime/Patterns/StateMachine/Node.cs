using System.Collections.Generic;

public class Node
{
    public readonly IState State;
    public readonly HashSet<Transition> Transitions;

    public Node(IState state)
    {
        State = state;
        Transitions = new HashSet<Transition>();
    }

    public void AddTransition(IState to, ICondition condition) => Transitions.Add(new Transition(State, to, condition));
}