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