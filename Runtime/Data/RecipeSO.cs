using UnityEngine;
using UnityEngine.Serialization;

namespace CookingSystem.Data
{
    [CreateAssetMenu(fileName = "Recipe", menuName = "Cooking/Recipe")]
    public class RecipeSO : ScriptableObject
    {
        public string Name;
        [FormerlySerializedAs("Image")] public Sprite Sprite;
        [TextArea] public string Description;
        public IngredientData[] Data;
    }
}