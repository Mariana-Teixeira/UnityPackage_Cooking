using System.Collections.Generic;
using TMPro;
using UnityEngine;
using GrabEvent = GrabEvent<Tray>;
using DropEvent = DropEvent<Tray>;
using StoreEvent = StoreEvent<Tray>;
using EmptyEvent = EmptyEvent<Tray>;

public class Tray : MonoBehaviour, IGrab, IContainer
{
    private TMP_Text _textbox;
    public CookState CurrentState { get; private set; } = CookState.Raw;
    public HashSet<Ingredient> IngredientMap { get; } = new();

    private void Awake()
    {
        _textbox = GetComponentInChildren<TMP_Text>();
    }

    private void AddToTray(Ingredient ingredient)
    {
        IngredientMap.Add(ingredient);
        EventBus<StoreEvent>.Raise(new StoreEvent(this));
    }

    public void Cook(CookState state)
    {
        CurrentState = state;
    }

    private void EmptyTray()
    {
        IngredientMap.Clear();
        CurrentState = CookState.Raw;
        EventBus<EmptyEvent>.Raise(new EmptyEvent(this));
    }

    public void WriteText(string text) => _textbox.text = text;
    public void ClearText() => _textbox.text = $"{this.name}: {CurrentState}";

    public void Grab() => EventBus<GrabEvent>.Raise(new GrabEvent(this));
    public void Drop() => EventBus<DropEvent>.Raise(new DropEvent(this));
    public void Send(IContainer user) => user.Receive(this);

    public void Empty() => EmptyTray();
    public void Store(IGrab grab) => grab.Send(this);
    public void Receive(Ingredient ingredient) => AddToTray(ingredient);
    public void Receive(Tray tray) { }
    public void Receive(Plate plate) => plate.AddToPlate(this);
}