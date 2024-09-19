using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CookerDisplay : MonoBehaviour
{
    private TMP_Text m_inventoryText;

    public static Action<List<SO_Ingredient>> DisplayFromIngredients;
    public static Action<string> SendDisplayText;

    private void Awake()
    {
        m_inventoryText = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        DisplayFromIngredients += GetMessageFromIngredients;
        SendDisplayText += OnReceiveDisplayText;
    }

    private void OnDisable()
    {
        DisplayFromIngredients -= GetMessageFromIngredients;
        SendDisplayText -= OnReceiveDisplayText;
    }

    private void GetMessageFromIngredients(List<SO_Ingredient> ingredients)
    {
        var message = "Inside:\n";
        foreach (var ingredient in ingredients) message += $"- {ingredient.name}\n";
        OnReceiveDisplayText(message);
    }

    private void OnReceiveDisplayText(string message) => m_inventoryText.text = message;
}
