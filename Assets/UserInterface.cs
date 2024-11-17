using TMPro;
using UnityEngine;
using GrabIngredient = GrabEvent<Storage>;
using DropIngredient = DropEvent<Storage>;
using GrabTray = GrabEvent<Tray>;
using DropTray = DropEvent<Tray>;
using GrabPlate = GrabEvent<Plate>;
using DropPlate = DropEvent<Plate>;
using UseTray = UseEvent<Tray>;
using UseCooker = UseEvent<Appliance>;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private TMP_Text _activeElement;
    private TMP_Text _textContent;

    private EventBinding<GrabIngredient> _grabIngredientEvent;
    private EventBinding<DropIngredient> _dropIngredientEvent;
    private EventBinding<GrabTray> _grabTrayEvent;
    private EventBinding<DropTray> _dropTrayEvent;
    private EventBinding<GrabPlate> _grabPlateEvent;
    private EventBinding<DropPlate> _dropPlateEvent;
    private EventBinding<UseTray> _useTrayEvent;
    private EventBinding<UseCooker> _useCookerEvent;

    private void Awake()
    {
        _grabIngredientEvent = new EventBinding<GrabIngredient>(PrintGrab);
        _dropIngredientEvent = new EventBinding<DropIngredient>(ClearGrab);
        _grabTrayEvent = new EventBinding<GrabTray>(PrintGrab);
        _dropTrayEvent = new EventBinding<DropTray>(ClearGrab);
        _grabPlateEvent = new EventBinding<GrabPlate>(PrintGrab);
        _dropPlateEvent = new EventBinding<DropPlate>(ClearGrab);
        _useTrayEvent = new EventBinding<UseTray>(PrintUse);
        _useCookerEvent = new EventBinding<UseCooker>(PrintUse);
    }

    private void OnEnable()
    {
        EventBus<GrabIngredient>.Register(_grabIngredientEvent);
        EventBus<DropIngredient>.Register(_dropIngredientEvent);
        EventBus<GrabTray>.Register(_grabTrayEvent);
        EventBus<DropTray>.Register(_dropTrayEvent);
        EventBus<GrabPlate>.Register(_grabPlateEvent);
        EventBus<DropPlate>.Register(_dropPlateEvent);
        EventBus<UseTray>.Register(_useTrayEvent);
        EventBus<UseCooker>.Register(_useCookerEvent);
    }

    private void OnDisable()
    {
        EventBus<GrabIngredient>.Deregister(_grabIngredientEvent);
        EventBus<DropIngredient>.Deregister(_dropIngredientEvent);
        EventBus<GrabTray>.Deregister(_grabTrayEvent);
        EventBus<DropTray>.Deregister(_dropTrayEvent);
        EventBus<GrabPlate>.Deregister(_grabPlateEvent);
        EventBus<DropPlate>.Deregister(_dropPlateEvent);
        EventBus<UseTray>.Deregister(_useTrayEvent);
        EventBus<UseCooker>.Deregister(_useCookerEvent);
    }

    private void PrintGrab(GrabIngredient grabEvent)
    {
        _activeElement.text = grabEvent.TargetObject.Ingredient.name;
    }

    private void PrintGrab(GrabTray grabEvent)
    {
        _activeElement.text = grabEvent.TargetObject.name;
    }

    private void PrintGrab(GrabPlate plateEvent)
    {
        _activeElement.text = plateEvent.TargetObject.name;
    }
    
    private void ClearGrab(DropIngredient ingredientEvent)
    {
        _activeElement.text = string.Empty;
    }
    
    private void ClearGrab(DropTray trayEvent)
    {
        _activeElement.text = string.Empty;
        trayEvent.TargetObject.ClearText();
    }
    
    private void ClearGrab(DropPlate trayEvent)
    {
        _activeElement.text = string.Empty;
    }
    
    private void PrintUse(UseTray trayEvent)
    {
        string content = string.Empty;
        foreach (var ingredient in trayEvent.TargetObject.IngredientMap) content += $"{ingredient.name}\n";
        trayEvent.TargetObject.WriteText(content);
    }

    private void PrintUse(UseCooker cookEvent)
    {
        string content = string.Empty;
        foreach (var ingredient in cookEvent.TargetObject.Ingredients) content += $"{ingredient.name}\n";
        cookEvent.TargetObject.WriteText(content);
    }
}