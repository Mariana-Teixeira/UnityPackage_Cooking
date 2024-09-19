using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//public class MixManager : MonoBehaviour
//{
//    [SerializeField]
//    private Transform m_uiIngredients;

//    public List<SO_Ingredient> GetIngredientsSelected()
//    {
//        var selectedIngredients = new List<SO_Ingredient>();
//        var ingredientList = m_uiIngredients.GetComponentsInChildren<UI_Ingredient>().Where(x => x.Toggle);
//        foreach (var ingredient in ingredientList) selectedIngredients.Add(Loader.Ingredients[ingredient.name]);
//        return selectedIngredients;
//    }

//    public bool Mix(List<SO_Ingredient> chosenIngredients, out Food createdFood)
//    {
//        var chosenIngredients = GetIngredientsSelected();
//        var recipe = Mixing.MixingIngredients(chosenIngredients);
//        var effect = Mixing.RetrieveEffect(chosenIngredients);

//        if (recipe == null)
//        {
//            createdFood = null;
//            return false;
//        }
//        else
//        {
//            createdFood = new Food(recipe, chosenIngredients, effect);
//            return true;
//        }
//    }
//}
