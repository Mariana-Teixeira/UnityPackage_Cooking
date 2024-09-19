using System;
using UnityEngine;

// TODO: Comment my code.
public class PlayerInteraction : MonoBehaviour
{
    private Camera m_camera;
    private RaycastHit m_hit;
    private bool m_canSelect;
    private LayerMask m_rayMask;
    private float m_rayDistance = 1.0f;

    private enum SelectState { MouseOver, MouseLeave };
    private SelectState m_currentSelectState;

    public static Action CursorStateChange;
    public static Action<string> TransportIngredient;
    public static Action Cook;
    public static Action DeliverRequest;
    public static Action TrashIngredients;

    private void Awake()
    {
        m_rayMask = LayerMask.GetMask("Interactable");
        m_camera = FindAnyObjectByType<Camera>();
    }

    private void Update()
    {
        SelectionRaycaster();
        CallWhenStateChange();
    }

    private void SelectionRaycaster()
    {
        var centerViewport = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        var _lookingAtRay = m_camera.ScreenPointToRay(centerViewport);
        m_canSelect = Physics.Raycast(_lookingAtRay, out m_hit, m_rayDistance, m_rayMask);
    }

    private void CallWhenStateChange()
    {
        var state = GetState();
        if (m_currentSelectState == state) return;

        m_currentSelectState = state;
        CursorStateChange.Invoke();
    }

    private SelectState GetState()
    {
        if (m_canSelect) return SelectState.MouseOver;
        else return SelectState.MouseLeave;
    }

    private void InvokeInteractEvent()
    {
        if (m_canSelect == false) return;

        if (m_hit.collider.CompareTag("FoodStorage"))
        {
            var objectName = m_hit.collider.name;
            TransportIngredient.Invoke(objectName);
        }
        else if (m_hit.collider.CompareTag("Cooker"))
        {
            Cook.Invoke();
        }
        else if (m_hit.collider.CompareTag("Requester"))
        {
            DeliverRequest.Invoke();
        }
        else if (m_hit.collider.CompareTag("Trash"))
        {
            TrashIngredients.Invoke();
        }
        else
        {
            Debug.LogError("Interact: Item not selectable.");
        }
    }
    public void OnInteract() => InvokeInteractEvent();
}