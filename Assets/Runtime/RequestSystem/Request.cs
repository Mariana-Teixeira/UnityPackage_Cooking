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
        string message = "Request";
        foreach(var ingredient in m_requestRecipe.RequiredIngredients) message += $"\n\t{ingredient.name}";
        return message;
    }
}