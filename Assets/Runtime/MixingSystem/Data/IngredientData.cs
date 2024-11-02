using UnityEngine;

public enum FoodCategory
{
    Bread,
    Meat,
    Sauce,
}

[CreateAssetMenu(fileName = "Ingredient", menuName = "Cooking/Ingredient")]
public class IngredientData : ScriptableObject
{
    public FoodCategory Category;
}