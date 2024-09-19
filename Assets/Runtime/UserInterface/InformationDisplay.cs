using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformationDisplay : MonoBehaviour
{
    private const float MESSAGEDISPLAYDURATION = 1.5f;
    private const float DEFAULTCURSORSIZE = 1.0f;
    private const float MAXCURSORSIZE = 2.5f;

    private TMP_Text m_informationText;
    private Image m_cursor;

    public static Action<string, Color> SendDisplayText;

    private void Awake()
    {
        m_informationText = GetComponentInChildren<TMP_Text>();
        m_cursor = GetComponentInChildren<Image>();
    }

    private void Start()
    {
        m_informationText.color = Color.white;
        m_informationText.text = string.Empty;
    }

    private void OnEnable()
    {
        SendDisplayText += OnReceiveDisplayText;
        PlayerInteraction.CursorStateChange += OnCursorStateChange;
    }

    private void OnDisable()
    {
        SendDisplayText -= OnReceiveDisplayText;
        PlayerInteraction.CursorStateChange -= OnCursorStateChange;
    }

    private void OnReceiveDisplayText(string message, Color color)
    {
        StopAllCoroutines();
        m_informationText.color = color;
        m_informationText.text = message;
        StartCoroutine(ResetMessageTimer());
    }

    private void ResetCanvas()
    {
        m_informationText.color = Color.white;
        m_informationText.text = string.Empty;
    }

    private IEnumerator ResetMessageTimer()
    {
        yield return new WaitForSeconds(MESSAGEDISPLAYDURATION);
        ResetCanvas();
    }

    private bool m_pingpong;
    private void OnCursorStateChange()
    {
        if (m_pingpong) m_cursor.transform.localScale = Vector3.one * MAXCURSORSIZE;
        else m_cursor.transform.localScale = Vector3.one * DEFAULTCURSORSIZE;
        m_pingpong = !m_pingpong;
    }
}