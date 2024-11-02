using System.Collections.Generic;

public class Food
{
    public HashSet<Ingredient> Ingredients { get; } = new();

    public void AddIngredient(Ingredient ingredient)
    {
        Ingredients.Add(ingredient);
    }
}