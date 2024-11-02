using System;

[Serializable]
public struct Requirement
{
    private CookState m_cookState;
    private Ingredient[] m_requiredIngredients;
    private FoodCategory[] m_requiredCategories;
}