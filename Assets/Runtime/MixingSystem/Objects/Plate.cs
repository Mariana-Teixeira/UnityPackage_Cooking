using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour, IInteractable
{
    public readonly Dictionary<CookState, HashSet<Ingredient>> IngredientMap = new();

    public void Grab() => EventBus<GrabObject<Plate>>.Raise(new GrabObject<Plate>(this));
    public void DropOn<T>() => EventBus<DropOnObject<T, Plate>>.Raise(new DropOnObject<T, Plate>(this));

    private HashSet<Ingredient> GetMap(CookState state)
    {
        if (!IngredientMap.ContainsKey(state)) IngredientMap.Add(state, new HashSet<Ingredient>());
        return IngredientMap[state];
    }

    public void AddToPlate(Tray tray) => GetMap(tray.CookState).UnionWith(tray.Ingredients);
}