using Codice.CM.SEIDInfo;
using UnityEngine;

public struct EmptyHanded : IState
{
    public void OnEnter()
    {
        Debug.Log("Enter Empty Handed");
    }

    public void Update()
    { }

    public void OnExit()
    { }
}

public readonly struct GrabState<T> : IState
{
    private readonly PlayerController _controller;

    public GrabState(PlayerController controller)
    {
        _controller = controller;
    }

    public void OnEnter()
    {
        Debug.Log($"Enter Grab {typeof(T)}");
        _controller.Interactable.Grab();
    }

    public void Update()
    { }

    public void OnExit()
    { }
}

public readonly struct DropOnState<T1, T2> : IState
{
    private readonly PlayerController _controller;

    public DropOnState(PlayerController controller)
    {
        _controller = controller;
    }

    public void OnEnter()
    {
        Debug.Log($"Enter Drop {typeof(T1)} on {typeof(T2)}");
        _controller.Interactable.DropOn<T1>();
        _controller.CheckConditions();
    }

    public void Update()
    { }

    public void OnExit()
    { }
}