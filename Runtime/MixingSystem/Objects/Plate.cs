using System.Collections.Generic;
using TMPro;
using UnityEngine;
using GrabEvent = GrabEvent<Plate>;
using DropEvent = DropEvent<Plate>;
using StoreEvent = StoreEvent<Plate>;
using EmptyEvent = EmptyEvent<Plate>;

public class Plate : MonoBehaviour, IGrab, IContainer
{
    private TMP_Text _textbox;
    public Dictionary<CookState, HashSet<Ingredient>> IngredientMap { get; } = new();

    private void Awake()
    {
        _textbox = GetComponentInChildren<TMP_Text>();
    }

    private HashSet<Ingredient> GetMap(CookState state)
    {
        if (!IngredientMap.ContainsKey(state)) IngredientMap.Add(state, new HashSet<Ingredient>());
        return IngredientMap[state];
    }

    private void AddToPlate(Ingredient ingredient)
    {
        GetMap(CookState.Raw).Add(ingredient);
        EventBus<StoreEvent>.Raise(new StoreEvent(this));
    }
    
    public void AddToPlate(Tray tray)
    {
        GetMap(tray.CurrentState).UnionWith(tray.IngredientMap);
        EventBus<StoreEvent>.Raise(new StoreEvent(this));
        
        tray.Empty();
    }

    private void EmptyPlate()
    {
        IngredientMap.Clear();
        EventBus<EmptyEvent>.Raise(new EmptyEvent(this));
    }

    public void WriteText(string text) => _textbox.text = text;
    public void ClearText() => _textbox.text = this.name;

    public void Grab() => EventBus<GrabEvent>.Raise(new GrabEvent(this));
    public void Drop() => EventBus<DropEvent>.Raise(new DropEvent(this));
    public void Send(IContainer user) => user.Receive(this);

    public void Empty() => EmptyPlate();
    public void Store(IGrab grab) => grab.Send(this);
    public void Receive(Ingredient ingredient) => AddToPlate(ingredient);
    public void Receive(Tray tray) => AddToPlate(tray);
    public void Receive(Plate plate) { }
}