using UnityEngine;
using static UnityEngine.Screen;

public interface IGrab
{
    public void Grab();
    public void Drop();
    public void Send(IUse user);
}

public interface IUse
{
    public void Use(IGrab grab);
    public void Receive(Ingredient ingredient);
    public void Receive(Tray tray);
    public void Receive(Plate plate);
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
    
    private SelectState GetState => _canSelect ? SelectState.MouseOver : SelectState.MouseLeave;
    public Collider GetInteracted => _canSelect ? _hit.collider : null;

    public PlayerInteraction(Camera camera, LayerMask mask, float rayDistance)
    {
        _camera = camera;
        _rayMask = mask;
        _rayDistance = rayDistance;
    }

    public void Update()
    {
        SelectionRaycaster();
    }

    private void SelectionRaycaster()
    {
        var centerViewport = new Vector3(width / 2.0f, height / 2.0f, 0);
        var _lookingAtRay = _camera.ScreenPointToRay(centerViewport);
        _canSelect = Physics.Raycast(_lookingAtRay, out _hit, _rayDistance, _rayMask);
    }
}