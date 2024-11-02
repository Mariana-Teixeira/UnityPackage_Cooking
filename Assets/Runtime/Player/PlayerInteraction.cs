using UnityEngine;
using static UnityEngine.Screen;

public interface IInteractable
{
    public void Interact();
}

public class PlayerInteraction
{
    private RaycastHit m_hit;
    private bool m_canSelect;
    private readonly Camera m_camera;
    private readonly LayerMask m_rayMask;
    private readonly float m_rayDistance;

    private enum SelectState { MouseOver, MouseLeave };
    private SelectState m_currentSelectState;

    public PlayerInteraction(Camera camera, LayerMask mask, float rayDistance)
    {
        m_camera = camera;
        m_rayMask = mask;
        m_rayDistance = rayDistance;
    }

    public void Update()
    {
        SelectionRaycaster();
        CallWhenStateChange();
    }
    
    public void Interact()
    {
        if (m_canSelect == false) return;
        m_hit.collider.GetComponent<IInteractable>().Interact();
    }

    private void SelectionRaycaster()
    {
        var centerViewport = new Vector3(width / 2.0f, height / 2.0f, 0);
        var _lookingAtRay = m_camera.ScreenPointToRay(centerViewport);
        m_canSelect = Physics.Raycast(_lookingAtRay, out m_hit, m_rayDistance, m_rayMask);
    }

    private void CallWhenStateChange()
    {
        m_currentSelectState = GetState();
    }
    
    private SelectState GetState() => m_canSelect ? SelectState.MouseOver : SelectState.MouseLeave;
}