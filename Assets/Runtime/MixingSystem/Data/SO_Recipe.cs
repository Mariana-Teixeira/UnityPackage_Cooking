using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Cooking/Recipe")]
public class SO_Recipe : ScriptableObject
{
    public FoodType Type;
    public List<SO_Ingredient> RequiredIngredients = new List<SO_Ingredient>();
}