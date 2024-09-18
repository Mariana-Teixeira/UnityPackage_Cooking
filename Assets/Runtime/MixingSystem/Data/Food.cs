using System.Collections.Generic;

public class Food
{
    private SO_Recipe m_recipeCreated;
    private List<SO_Ingredient> m_ingredientsUsed;
    private SO_Effect m_foodEffect;

    public Food(SO_Recipe recipeCreated, List<SO_Ingredient> ingredientsUsed, SO_Effect foodEffect)
    {
        m_recipeCreated = recipeCreated;
        m_ingredientsUsed = ingredientsUsed;
        m_foodEffect = foodEffect;
    }
}
