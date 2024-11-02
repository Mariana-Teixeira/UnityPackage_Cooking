using UnityEngine;
using UnityEngine.Serialization;

public class Storage : MonoBehaviour, IInteractable
{
    [FormerlySerializedAs("mSoIngredient")] [FormerlySerializedAs("m_ingredient")] [SerializeField] private IngredientData mIngredientData;
    public void Interact() => EventBus<StorageEvent>.Raise(new StorageEvent(mIngredientData));
}