using System;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class RequestManager : MonoBehaviour
{
    public static Func<Request> GetCurrentRequest => GetCurrentRequest;

    [SerializeField]
    private RequestDisplay m_requestDisplay;
    private SO_Recipe[] m_allRecipes;
    private Request m_currentRequest;

    private void Awake()
    {
        m_allRecipes = Loader.Recipes.ToArray();
    }

    public Request OnGetCurrentRequest()
    {
        return m_currentRequest;
    }

    public void PoolRequest()
    {
        var randomIndex = UnityEngine.Random.Range(0, m_allRecipes.Length);
        m_currentRequest = new Request(m_allRecipes[randomIndex]);

        if (m_allRecipes[randomIndex] == null) Debug.LogError("Can't find recipe.");
        else m_requestDisplay.UpdateDisplay(m_currentRequest);
    }
}
