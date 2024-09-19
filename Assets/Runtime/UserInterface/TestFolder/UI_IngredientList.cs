using UnityEngine;

public class UI_IngredientList : MonoBehaviour
{
    [SerializeField]
    private GameObject m_ingredientPrefab;

    private void Start()
    {
        InstantiateAllIngrediants();
    }

    private void InstantiateAllIngrediants()
    {
        foreach (var item in Loader.Ingredients.Values)
        {
            Instantiate(m_ingredientPrefab, this.transform)
                .GetComponent<UI_Ingredient>()
                .SetIngredient(false, item.name);
        }
    }
}