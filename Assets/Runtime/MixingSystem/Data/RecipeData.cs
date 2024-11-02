using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Cooking/Recipe")]
public class RecipeData : ScriptableObject
{
    public Requirement[] m_requirements;
}