using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Effect", menuName = "Cooking/Effect")]
public class SO_Effect : ScriptableObject
{
    public int EffectValue;
    public UnityEvent<Food> Event;
}