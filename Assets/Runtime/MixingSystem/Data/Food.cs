using System.Collections.Generic;

public class Food
{
    private SO_Recipe m_recipeCreated;
    private List<SO_Ingredient> m_ingredientsUsed;
    private SO_Effect m_foodEffect;

    public List<SO_Ingredient> IngredientsUsed
    {
        get
        {
            return m_ingredientsUsed;
        }
    }
    public SO_Effect FoodEffect
    {
        get
        {
            return m_foodEffect;
        }
    }

    public Food(SO_Recipe recipeCreated, List<SO_Ingredient> ingredientsUsed, SO_Effect foodEffect)
    {
        m_recipeCreated = recipeCreated;
        m_ingredientsUsed = ingredientsUsed;
        m_foodEffect = foodEffect;
    }

    public bool ApplyEffect()
    {
        if (m_foodEffect == null) return false;
        m_foodEffect.Event.Invoke(this);
        return true;
    }
}
