using System.Linq;
using UnityEditor;

[CustomEditor(typeof(SO_Ingredient))]
public class SO_IngredientEditor : Editor
{
    private SO_Ingredient m_ingredient;
    private string[] m_keys;

    private void Awake()
    {
        m_ingredient = target as SO_Ingredient;
        m_keys = Loader.Effects.Keys.ToArray();
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("HealthRecovery"));

        m_ingredient.HasEffect = EditorGUILayout.Toggle("Add Effect", m_ingredient.HasEffect);
        if (m_ingredient.HasEffect)
        {
            m_ingredient.EffectIndex = EditorGUILayout.Popup(m_ingredient.EffectIndex, m_keys);
            m_ingredient.Effect = m_keys[m_ingredient.EffectIndex];
        }
        else
        {
            m_ingredient.Effect = string.Empty;
        }

        serializedObject.ApplyModifiedProperties();
    }
}