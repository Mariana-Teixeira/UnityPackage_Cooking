using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UseEvent = UseEvent<Appliance>;

public class Appliance : MonoBehaviour, IUse
{
    [SerializeField] private CookState _cookState;
    private TMP_Text _textbox;

    private void Awake()
    {
        _textbox = GetComponentInChildren<TMP_Text>();
    }

    public void WriteText(string text)
    {
        _textbox.text = text;
    }

    public void ClearText()
    {
        _textbox.text = string.Empty;
    }
    
    public void Use(IGrab grab)
    {
        grab.Send(this);
        EventBus<UseEvent>.Raise(new UseEvent(this));
    }

    public void Receive(Ingredient ingredient) { }

    public void Receive(Tray tray) { }

    public void Receive(Plate plate) { }
}