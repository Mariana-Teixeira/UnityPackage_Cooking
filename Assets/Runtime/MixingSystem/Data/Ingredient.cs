public enum CookState
{
    Raw,
    Cooked,
    Fried,
    Burnt
}

public class Ingredient
{
    private readonly string m_name;
    private readonly FoodCategory m_category;
    private CookState m_state;

    public Ingredient(string name, FoodCategory category, CookState state = CookState.Raw)
    {
        m_name = name;
        m_category = category;
        m_state = state;
    }
    
    // TODO: Employ State Machine?
    public void ChangeState(CookType cookType)
    {
        if (m_state == CookState.Raw && cookType == CookType.Cooking)
        {
            m_state = CookState.Cooked;
        }
        else if (m_state == CookState.Raw && cookType == CookType.Frying)
        {
            m_state = CookState.Fried;
        }
        else if (m_state != CookState.Raw)
        {
            m_state = CookState.Burnt;
        }
    }

    public override string ToString()
    {
        return m_name;
    }
}