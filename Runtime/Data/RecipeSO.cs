using System;
using UnityEngine;

namespace CookingSystem
{
    [CreateAssetMenu(fileName = "Recipe", menuName = "Cooking/Recipe")]
    public class RecipeSO : ScriptableObject
    {
        public string Name;
        public Sprite Image;
        [TextArea] public string Description;
        public Requirements[] Instructions;
    }

    [Serializable]
    public struct Requirements
    {
        public FoodState State;
        public IngredientSO[] Ingredients;
    }   
}