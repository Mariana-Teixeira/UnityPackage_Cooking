using UnityEngine;
using UnityEngine.Serialization;

public class Storage : MonoBehaviour, IInteractable
{
    [SerializeField] private Ingredient m_Ingredient;
    public void Interact() => EventBus<StorageEvent>.Raise(new StorageEvent(m_Ingredient));
}