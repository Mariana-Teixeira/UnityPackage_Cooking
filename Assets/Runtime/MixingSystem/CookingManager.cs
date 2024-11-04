using UnityEngine;

public class CookingManager : MonoBehaviour
{
    private EventBinding<GrabObject<Ingredient>> _grabIngredient;
    private EventBinding<DropOnObject<Ingredient, Tray>> _useTray;
    private EventBinding<GrabObject<Tray>> _grabTray;
    
    private Ingredient _ingredient;
    private Tray _tray;

    private void Awake()
    {
        _grabIngredient = new EventBinding<GrabObject<Ingredient>>(ingredient => _ingredient = ingredient.TargetObject);
        _grabTray = new EventBinding<GrabObject<Tray>>(tray => _tray = tray.TargetObject);
        _useTray = new EventBinding<DropOnObject<Ingredient, Tray>>(DropIngredientOnTray);
    }
    
    private void OnEnable()
    {
        EventBus<GrabObject<Ingredient>>.Register(_grabIngredient);
        EventBus<GrabObject<Tray>>.Register(_grabTray);
        
        EventBus<DropOnObject<Ingredient, Tray>>.Register(_useTray);
    }

    private void OnDisable()
    {
        EventBus<GrabObject<Ingredient>>.Deregister(_grabIngredient);
        EventBus<GrabObject<Tray>>.Deregister(_grabTray);
        
        EventBus<DropOnObject<Ingredient, Tray>>.Deregister(_useTray);
    }

    private void DropIngredientOnTray(DropOnObject<Ingredient, Tray> dropOnObject)
    {
        dropOnObject.TargetObject.Add(_ingredient);
        _ingredient = null;
    }
}