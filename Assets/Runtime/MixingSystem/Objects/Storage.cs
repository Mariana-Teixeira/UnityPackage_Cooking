using UnityEngine;
using UnityEngine.Serialization;

public class Storage : MonoBehaviour, IInteractable
{
    [SerializeField] private Ingredient m_Ingredient;
    public void Interact() => EventBus<PassObjectEvent<Ingredient>>.Raise(new PassObjectEvent<Ingredient>(m_Ingredient));
}