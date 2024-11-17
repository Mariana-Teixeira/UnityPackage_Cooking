using UnityEngine;

public struct EmptyState : IState
{
    private readonly PlayerController _playerController;

    public EmptyState(PlayerController controller)
    {
        _playerController = controller;
    }
    
    public void OnEnter()
    {
        Debug.Log("Empty State");
        
        _playerController.Drop();
        _playerController.OnClearInteract();
    }

    public void Update()
    { }

    public void OnExit()
    { }
}

public readonly struct GrabState : IState
{
    private readonly PlayerController _playerController;

    public GrabState(PlayerController controller)
    {
        _playerController = controller;
    }

    public void OnEnter()
    {
        Debug.Log("Grab State");

        _playerController.Grab();
        _playerController.OnClearInteract();
    }

    public void Update()
    { }

    public void OnExit()
    { }
}

public readonly struct UseState : IState
{
    private readonly PlayerController _playerController;
    
    public UseState(PlayerController controller)
    {
        _playerController = controller;
    }

    public void OnEnter()
    {
        Debug.Log("Use State");

        _playerController.Use();
        _playerController.OnClearInteract();
    }

    public void Update()
    { }

    public void OnExit()
    { }
}