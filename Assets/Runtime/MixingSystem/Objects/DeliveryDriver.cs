using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UseEvent = UseEvent<DeliveryDriver>;

public class DeliveryDriver : MonoBehaviour, IUse
{
    private TMP_Text _textbox;
    private Recipe _requestedRecipe;

    private void Awake()
    {
        _textbox = GetComponentInChildren<TMP_Text>();
    }

    private void Start()
    {
        Request();
    }

    private void Request()
    {
        _requestedRecipe = Loader.GetRandomRecipe();
        _textbox.text = _requestedRecipe.name;
    }

    private bool Deliver(Plate plate)
    {
        var requested = _requestedRecipe._dish;
        var delivered = plate.IngredientMap;

        foreach (var requirement in requested)
        {
            CookState requestedState = requirement.State;
            var requestedIngredients = new HashSet<Ingredient>(requirement.Ingredients);

            if (!delivered.TryGetValue(requestedState, out var deliveredIngredients)) return false;
            if (!deliveredIngredients.SetEquals(requestedIngredients)) return false;
        }

        return true;
    }

    public void Use(IGrab grab)
    {
        grab.Send(this);
        EventBus<UseEvent>.Raise(new UseEvent(this));
    }

    public void Receive(Ingredient ingredient) { }

    public void Receive(Tray tray) { }

    public void Receive(Plate plate)
    {
        if (Deliver(plate))
        {
            Debug.Log("Delivered!");
            Request();
        }
        else
        {
            Debug.Log("Wrong Delivery...");
            Request();
        }
    }
}
