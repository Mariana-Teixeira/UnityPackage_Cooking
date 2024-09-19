public class Request
{
    private SO_Recipe m_requestRecipe;

    public SO_Recipe RequestRecipe
    {
        get
        {
            return m_requestRecipe;
        }
    }
    
    public Request(SO_Recipe recipe)
    {
        m_requestRecipe = recipe;
    }

    public override string ToString()
    {
        string message = string.Empty;
        foreach(var ingredient in m_requestRecipe.RequiredIngredients) message += $"- {ingredient.name}\n";
        return message;
    }
}