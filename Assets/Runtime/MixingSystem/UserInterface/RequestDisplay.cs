using TMPro;
using UnityEngine;

public class RequestDisplay : MonoBehaviour
{
    private TMP_Text m_requestText;

    private void Awake()
    {
        m_requestText = GetComponentInChildren<TMP_Text>();
    }

    public void UpdateDisplay(Request request)
    {
        m_requestText.text = request.ToString();
    }
}