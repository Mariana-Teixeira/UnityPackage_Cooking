using System;
using TMPro;
using UnityEngine;

public class RequestDisplay : MonoBehaviour
{
    private TMP_Text m_requestText;

    public static Action<Request> SendDisplayText;

    private void Awake()
    {
        m_requestText = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        SendDisplayText += OnReceiveDisplayText;
    }

    private void OnDisable()
    {
        SendDisplayText -= OnReceiveDisplayText;
    }

    private void OnReceiveDisplayText(Request request)
    {
        var display = $"{request.RequestRecipe.name}";
        UpdateDisplay(display);
    }

    private void UpdateDisplay(string message) => m_requestText.text = message;
}