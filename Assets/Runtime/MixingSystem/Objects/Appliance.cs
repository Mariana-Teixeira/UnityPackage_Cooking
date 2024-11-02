using UnityEngine;

public class Appliance : MonoBehaviour, IInteractable
{
    [SerializeField] private CookState m_cookState;
    public void Interact() => EventBus<CookEvent>.Raise(new CookEvent(this));
    public void Cook(Tray tray) => tray.Cook(m_cookState);
}