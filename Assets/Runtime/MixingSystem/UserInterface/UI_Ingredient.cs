using UnityEngine;
using UnityEngine.UI;

public class UI_Ingredient : MonoBehaviour
{
    private Toggle m_toggle;
    private Text m_text;

    public bool Toggle
    {
        get
        {
            return m_toggle.isOn;
        }
    }

    private void Awake()
    {
        m_toggle = GetComponent<Toggle>();
        m_text = GetComponentInChildren<Text>();
    }

    public UI_Ingredient SetIngredient(bool toggle, string name)
    {
        m_toggle.isOn = false;
        m_text.text = name;
        this.name = name;
        return this;
    }
}