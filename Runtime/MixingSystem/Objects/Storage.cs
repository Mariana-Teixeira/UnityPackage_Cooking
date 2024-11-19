using UnityEngine;

namespace CookingSystem
{
    using GrabEvent = GrabEvent<Storage>;
    using DropEvent = DropEvent<Storage>;

    public class Storage : MonoBehaviour, IGrab
    {
        [SerializeField] private Ingredient _ingredient;
        public Ingredient Ingredient => _ingredient;

        public void Grab() => EventBus<GrabEvent>.Raise(new GrabEvent(this));
        public void Drop() => EventBus<DropEvent>.Raise(new DropEvent(this));
        public void Send(IContainer user) => user.Receive(_ingredient);
    }   
}