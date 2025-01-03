using System;

namespace CookingSystem.States
{
    public interface ICondition
    {
        public Func<bool> Condition { get; }
        public bool Evaluate();
    }

    public class Predicate : ICondition
    {
        public Func<bool> Condition { get; }

        public Predicate(Func<bool> condition)
        {
            Condition = condition;
        }

        public bool Evaluate()
        {
            return Condition.Invoke();
        }
    }   
}