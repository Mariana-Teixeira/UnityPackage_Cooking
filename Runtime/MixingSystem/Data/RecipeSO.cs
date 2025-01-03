using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace CookingSystem
{
    [CreateAssetMenu(fileName = "Recipe", menuName = "Cooking/Recipe")]
    public class RecipeSO : ScriptableObject
    {
        public Requirements[] Instructions;
    }

    [Serializable]
    public struct Requirements
    {
        public DishState State;
        public IngredientSO[] Ingredients;
    }   
}