using System;
using TMPro;
using UnityEngine;

public class DeliverDisplay : MonoBehaviour
{
    private TMP_Text m_foodText;

    public static Action<Food> SendFood;
    public static Action<string> SendDisplayText;

    private void Awake()
    {
        m_foodText = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        SendFood += OnReceiveFood;
        SendDisplayText += OnReceiveDisplayText;
    }

    private void OnDisable()
    {
        SendFood -= OnReceiveFood;
        SendDisplayText -= OnReceiveDisplayText;
    }

    private void OnReceiveDisplayText(string message) => UpdateDisplay(message);
    private void OnReceiveFood(Food food) => UpdateDisplay($"Deliver:\n{food.RecipeCreated.name}");

    private void UpdateDisplay(string message) => m_foodText.text = message;
}
