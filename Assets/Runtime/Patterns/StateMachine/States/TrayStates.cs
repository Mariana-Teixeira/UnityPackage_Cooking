public struct RawState : IState
{
    private readonly Tray _tray;

    public RawState(Tray tray)
    {
        _tray = tray;
    }

    public void OnEnter()
    {
        _tray.CookState = CookState.Raw;
    }

    public void Update()
    { }

    public void OnExit()
    { }
}

public readonly struct CookedState : IState
{
    private readonly Tray _tray;

    public CookedState(Tray tray)
    {
        _tray = tray;
    }   
    
    public void OnEnter()
    {
        _tray.CookState = CookState.Cooked;
    }

    public void Update()
    { }

    public void OnExit()
    { }
}

public readonly struct FriedState : IState
{
    private readonly Tray _tray;

    public FriedState(Tray tray)
    {
        _tray = tray;
    }
    
    public void OnEnter()
    {
        _tray.CookState = CookState.Fried;
    }

    public void Update()
    { }

    public void OnExit()
    { }
}

public readonly struct BurntState : IState
{
    private readonly Tray _tray;

    public BurntState(Tray tray)
    {
        _tray = tray;
    }
    
    public void OnEnter()
    {
        _tray.CookState = CookState.Burnt;
    }

    public void Update()
    { }

    public void OnExit()
    { }
}

