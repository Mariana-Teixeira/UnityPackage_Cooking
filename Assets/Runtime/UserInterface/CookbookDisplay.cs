using TMPro;
using UnityEngine;

public class CookbookDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject m_recipeText;
    private Transform m_content;

    private void Awake()
    {
        m_content = transform.Find("Content");
    }

    private void Start()
    {
        InstantiateRecipeList();
    }

    private void InstantiateRecipeList()
    {
        var recipeList = Loader.Recipes;
        foreach (var recipe in recipeList)
        {
            var textbox = Instantiate(m_recipeText).GetComponent<TMP_Text>();
            textbox.text = GetRecipeString(recipe);
        }
    }

    private string GetRecipeString(SO_Recipe recipe)
    {
        var text = $"{recipe.name}: ";
        foreach (var ingredient in recipe.RequiredIngredients) text += ingredient.ToString();
        return text;
    }
}
