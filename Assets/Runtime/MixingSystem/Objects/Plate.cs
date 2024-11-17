using System.Collections.Generic;
using UnityEngine;
using GrabEvent = GrabEvent<Plate>;
using DropEvent = DropEvent<Plate>;

public class Plate : MonoBehaviour, IGrab, IUse
{
    public Dictionary<CookState, HashSet<Ingredient>> IngredientMap { get; } = new();

    public HashSet<Ingredient> GetMap(CookState state)
    {
        if (!IngredientMap.ContainsKey(state)) IngredientMap.Add(state, new HashSet<Ingredient>());
        return IngredientMap[state];
    }

    public void Grab() => EventBus<GrabEvent>.Raise(new GrabEvent(this));

    public void Drop() => EventBus<DropEvent>.Raise(new DropEvent(this));

    public void Send(IUse user) => user.Receive(this);
    
    public void Use(IGrab grab) => grab.Send(this);
    public void Receive(Ingredient ingredient) => GetMap(CookState.Raw).Add(ingredient);
    public void Receive(Tray tray) { }
    public void Receive(Plate plate) { }
}