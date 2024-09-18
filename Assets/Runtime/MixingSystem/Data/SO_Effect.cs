using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Effect", menuName = "Cooking/Effect")]
public class SO_Effect : ScriptableObject
{
    public int Value;
    public UnityEvent<Food> Event;
}