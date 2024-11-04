using UnityEngine;
using static UnityEngine.Screen;

public interface IInteractable
{
    public void Grab();
    public void DropOn<T>();
}


public class PlayerInteraction
{
    private RaycastHit _hit;
    private bool _canSelect;
    private readonly Camera _camera;
    private readonly LayerMask _rayMask;
    private readonly float _rayDistance;

    private enum SelectState { MouseOver, MouseLeave };
    private SelectState _currentSelectState;

    public PlayerInteraction(Camera camera, LayerMask mask, float rayDistance)
    {
        _camera = camera;
        _rayMask = mask;
        _rayDistance = rayDistance;
    }

    public void Update()
    {
        SelectionRaycaster();
        CallWhenStateChange();
    }

    public IInteractable GetInteracted() => _canSelect ? _hit.collider.GetComponent<IInteractable>() : null;

    private void SelectionRaycaster()
    {
        var centerViewport = new Vector3(width / 2.0f, height / 2.0f, 0);
        var _lookingAtRay = _camera.ScreenPointToRay(centerViewport);
        _canSelect = Physics.Raycast(_lookingAtRay, out _hit, _rayDistance, _rayMask);
    }

    private void CallWhenStateChange() => _currentSelectState = GetState();
    
    private SelectState GetState() => _canSelect ? SelectState.MouseOver : SelectState.MouseLeave;
}