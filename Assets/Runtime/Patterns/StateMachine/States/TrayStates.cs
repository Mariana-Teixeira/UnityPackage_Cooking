public struct RawState : IState
{
    private readonly Tray m_tray;

    public RawState(Tray tray)
    {
        m_tray = tray;
    }

    public void OnEnter()
    {
        m_tray.CookState = CookState.Raw;
    }
}

public readonly struct CookedState : IState
{
    private readonly Tray m_tray;

    public CookedState(Tray tray)
    {
        m_tray = tray;
    }   
    
    public void OnEnter()
    {
        m_tray.CookState = CookState.Cooked;
    }
}

public readonly struct FriedState : IState
{
    private readonly Tray m_tray;

    public FriedState(Tray tray)
    {
        m_tray = tray;
    }
    
    public void OnEnter()
    {
        m_tray.CookState = CookState.Fried;
    }
}

public readonly struct BurntState : IState
{
    private readonly Tray m_tray;

    public BurntState(Tray tray)
    {
        m_tray = tray;
    }
    
    public void OnEnter()
    {
        m_tray.CookState = CookState.Burnt;
    }
}

