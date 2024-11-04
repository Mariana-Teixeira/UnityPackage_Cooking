using UnityEngine;

public class Appliance : MonoBehaviour, IInteractable
{
    [SerializeField] private CookState _cookState;
    
    public void Grab() { }
    public void DropOn<T>() => EventBus<DropOnObject<T, Appliance>>.Raise(new DropOnObject<T, Appliance>(this));

    public void Cook(Tray tray) => tray.Cook(_cookState);
}