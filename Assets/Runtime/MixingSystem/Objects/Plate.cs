using System.Collections.Generic;
using Codice.Client.Commands.WkTree;
using UnityEngine;

public class Plate : MonoBehaviour, IInteractable
{
    public readonly Dictionary<CookState, HashSet<Ingredient>> IngredientMap = new();

    public void Interact() => EventBus<PassObjectEvent<Plate>>.Raise(new PassObjectEvent<Plate>(this));

    private HashSet<Ingredient> GetMap(CookState state)
    {
        if (!IngredientMap.ContainsKey(state)) IngredientMap.Add(state, new HashSet<Ingredient>());
        return IngredientMap[state];
    }

    public void AddToPlate(Tray tray) => GetMap(tray.CookState).UnionWith(tray.Ingredients);
    public void AddToPlate(Ingredient ingredient) => GetMap(CookState.Raw).Add(ingredient);
}