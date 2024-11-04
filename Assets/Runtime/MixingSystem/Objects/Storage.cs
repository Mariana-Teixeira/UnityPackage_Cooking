using UnityEngine;

public class Storage : MonoBehaviour, IInteractable
{
    [SerializeField] private Ingredient _Ingredient;
    public Ingredient target { get; }
    public void Grab() => EventBus<GrabObject<Ingredient>>.Raise(new GrabObject<Ingredient>(_Ingredient));
    public void DropOn<T>() { }
}