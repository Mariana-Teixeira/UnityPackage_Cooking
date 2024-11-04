using System;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Recipe", menuName = "Cooking/Recipe")]
public class Recipe : ScriptableObject
{
    public Requirements[] _dish;
}

[Serializable]
public struct Requirements
{
    public CookState State;
    public Ingredient[] Ingredients;
}