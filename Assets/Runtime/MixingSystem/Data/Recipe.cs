using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Cooking/Recipe")]
public class Recipe : ScriptableObject
{
    public Requirements[] m_dish;
}

[Serializable]
public struct Requirements
{
    public CookState State;
    public Ingredient[] Ingredients;
}