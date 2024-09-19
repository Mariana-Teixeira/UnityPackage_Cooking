using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    private TMP_Text m_inventoryText;

    private void Awake()
    {
        m_inventoryText = GetComponentInChildren<TMP_Text>();
    }

    public void UpdateText(List<SO_Ingredient> ingredients)
    {
        string message = "Holding:";
        foreach (var ingredient in ingredients) message += $"\n\t{ingredient.name}";
        m_inventoryText.text = message;
    }
}
