using UnityEngine;

namespace  CookingSystem.Data
{
    [CreateAssetMenu(fileName = "Ingredient", menuName = "Cooking/Ingredient")]
    public class IngredientSO : ScriptableObject
    {
        public string Name;
        public Sprite Image;
        [TextArea] public string Description;
    }   
}