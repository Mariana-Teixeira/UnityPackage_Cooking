using UnityEngine;
using UnityEngine.Serialization;

public class Storage : MonoBehaviour, IInteractable
{
    [SerializeField] private Ingredient m_Ingredient;
    public void Interact() => EventBus<PassEvent<Ingredient>>.Raise(new PassEvent<Ingredient>(m_Ingredient));
}