using System.Collections.Generic;
using TMPro;
using UnityEngine;
using GrabEvent = GrabEvent<Tray>;
using DropEvent = DropEvent<Tray>;
using UseEvent = UseEvent<Tray>;

public class Tray : MonoBehaviour, IGrab, IUse
{
    private TMP_Text _textbox;
    public HashSet<Ingredient> IngredientMap { get; } = new();

    private void Awake()
    {
        _textbox = GetComponentInChildren<TMP_Text>();
    }

    public void Cook(CookState state)
    {
        
    }

    public void WriteText(string text)
    {
        _textbox.text = text;
    }
    public void ClearText()
    {
        _textbox.text = string.Empty;
    }

    public void Grab() => EventBus<GrabEvent>.Raise(new GrabEvent(this));
    public void Drop()
    {
        IngredientMap.Clear();
        EventBus<DropEvent>.Raise(new DropEvent(this));
    }
    public void Send(IUse user) => user.Receive(this);

    public void Use(IGrab grab)
    {
        grab.Send(this);
        EventBus<UseEvent>.Raise(new UseEvent(this));
    }

    public void Receive(Ingredient ingredient) => IngredientMap.Add(ingredient);   
    public void Receive(Tray tray) { }
    public void Receive(Plate plate) { }
}