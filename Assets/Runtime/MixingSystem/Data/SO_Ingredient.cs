using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Ingredient", menuName = "Cooking/Ingredient")]
public class SO_Ingredient : ScriptableObject
{
    public int HealthRecovery = 1;

    public bool HasEffect = false;
    public int EffectIndex = 0;
    public string Effect = string.Empty;
}