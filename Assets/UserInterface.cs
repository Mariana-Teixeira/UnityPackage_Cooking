using System.Collections.Generic;
using TMPro;
using UnityEngine;
using GrabIngredient = GrabEvent<Storage>;
using GrabTray = GrabEvent<Tray>;
using GrabPlate = GrabEvent<Plate>;

using DropIngredient = DropEvent<Storage>;
using DropTray = DropEvent<Tray>;
using DropPlate = DropEvent<Plate>;

using StoreTray = StoreEvent<Tray>;
using StoreCooker = StoreEvent<Appliance>;
using StorePlate = StoreEvent<Plate>;

using EmptyTray = EmptyEvent<Tray>;
using EmptyCooker = EmptyEvent<Appliance>;
using EmptyPlate = EmptyEvent<Plate>;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private TMP_Text _activeElement;
    private TMP_Text _textContent;

    private EventBinding<GrabIngredient> _grabIngredientEvent;
    private EventBinding<GrabTray> _grabTrayEvent;
    private EventBinding<GrabPlate> _grabPlateEvent;
    
    private EventBinding<DropTray> _dropTrayEvent;
    private EventBinding<DropIngredient> _dropIngredientEvent;
    private EventBinding<DropPlate> _dropPlateEvent;

    private EventBinding<StoreTray> _storeTrayEvent;
    private EventBinding<StoreCooker> _storeCookerEvent;
    private EventBinding<StorePlate> _storePlateEvent;

    private EventBinding<EmptyTray> _emptyTray;
    private EventBinding<EmptyCooker> _emptyCooker;
    private EventBinding<EmptyPlate> _emptyPlate;
    
    private EventBinding<DeliverEvent> _deliverEvent;

    private void Awake()
    {
        _grabIngredientEvent = new EventBinding<GrabIngredient>(PrintGrab);
        _grabTrayEvent = new EventBinding<GrabTray>(PrintGrab);
        _grabPlateEvent = new EventBinding<GrabPlate>(PrintGrab);
        
        _dropIngredientEvent = new EventBinding<DropIngredient>(ClearGrab);
        _dropTrayEvent = new EventBinding<DropTray>(ClearGrab);
        _dropPlateEvent = new EventBinding<DropPlate>(ClearGrab);

        _storeTrayEvent = new EventBinding<StoreTray>(Print);
        _storeCookerEvent = new EventBinding<StoreCooker>(Print);
        _storePlateEvent = new EventBinding<StorePlate>(Print);

        _emptyTray = new EventBinding<EmptyTray>(EmptyTray);
        _emptyCooker = new EventBinding<EmptyCooker>(EmptyCooker);
        _emptyPlate = new EventBinding<EmptyPlate>(EmptyPlate);

        _deliverEvent = new EventBinding<DeliverEvent>(x => Debug.Log($"Delivery was {x.IsCorrect}."));
    }

    private void OnEnable()
    {
        EventBus<GrabIngredient>.Register(_grabIngredientEvent);
        EventBus<GrabTray>.Register(_grabTrayEvent);
        EventBus<GrabPlate>.Register(_grabPlateEvent);
        
        EventBus<DropIngredient>.Register(_dropIngredientEvent);
        EventBus<DropTray>.Register(_dropTrayEvent);
        EventBus<DropPlate>.Register(_dropPlateEvent);
        
        EventBus<StoreTray>.Register(_storeTrayEvent);
        EventBus<StoreCooker>.Register(_storeCookerEvent);
        EventBus<StorePlate>.Register(_storePlateEvent);
        
        EventBus<EmptyTray>.Register(_emptyTray);
        EventBus<EmptyCooker>.Register(_emptyCooker);
        EventBus<EmptyPlate>.Register(_emptyPlate);
        
        EventBus<DeliverEvent>.Register(_deliverEvent);
    }

    private void OnDisable()
    {
        EventBus<GrabIngredient>.Deregister(_grabIngredientEvent);
        EventBus<GrabTray>.Deregister(_grabTrayEvent);
        EventBus<GrabPlate>.Deregister(_grabPlateEvent);
        
        EventBus<DropIngredient>.Deregister(_dropIngredientEvent);
        EventBus<DropTray>.Deregister(_dropTrayEvent);
        EventBus<DropPlate>.Deregister(_dropPlateEvent);
        
        EventBus<StoreTray>.Deregister(_storeTrayEvent);
        EventBus<StoreCooker>.Deregister(_storeCookerEvent);
        EventBus<StorePlate>.Deregister(_storePlateEvent);
        
        EventBus<EmptyTray>.Deregister(_emptyTray);
        EventBus<EmptyCooker>.Deregister(_emptyCooker);
        EventBus<EmptyPlate>.Deregister(_emptyPlate);
        
        EventBus<DeliverEvent>.Deregister(_deliverEvent);
    }

    private void PrintGrab(GrabIngredient grabEvent) => _activeElement.text = grabEvent.TargetObject.Ingredient.name;
    private void PrintGrab(GrabTray grabEvent) => _activeElement.text = grabEvent.TargetObject.name;
    private void PrintGrab(GrabPlate plateEvent) => _activeElement.text = plateEvent.TargetObject.name;
    private void ClearGrab(DropIngredient ingredientEvent) => _activeElement.text = string.Empty;
    private void ClearGrab(DropTray trayEvent) => _activeElement.text = string.Empty;
    private void ClearGrab(DropPlate trayEvent) => _activeElement.text = string.Empty;
    private void EmptyTray(EmptyTray trayEvent) => trayEvent.TargetObject.ClearText();
    private void EmptyCooker(EmptyCooker cookerEvent) => cookerEvent.TargetObject.ClearText();
    private void EmptyPlate(EmptyPlate playEvent) => playEvent.TargetObject.ClearText();

    private void Print(StoreTray trayEvent)
    {
        string content = $"{trayEvent.TargetObject.name}\n";
        content += PrintTray(trayEvent.TargetObject.IngredientMap);
        trayEvent.TargetObject.WriteText(content);
    }

    private void Print(StoreCooker cookerEvent)
    {
        string content = $"{cookerEvent.TargetObject.name}\n";
        content += PrintTray(cookerEvent.TargetObject.GetTray.IngredientMap);
        cookerEvent.TargetObject.WriteText(content);
    }

    private void Print(StorePlate plateEvent)
    {
        string content = $"{plateEvent.TargetObject.name}\n";
        foreach (var pair in plateEvent.TargetObject.IngredientMap)
        {
            content += $"- {pair.Key} -\n";
            content += PrintTray(pair.Value);
        }
        plateEvent.TargetObject.WriteText(content);
    }
    
    private string PrintTray(HashSet<Ingredient> map)
    {
        string content = string.Empty;
        foreach (var ingredient in map) content += $"{ingredient.name}\n";
        return content;
    }

    private void PrintDelivery(DeliverEvent deliveryEvent)
    {
        Debug.Log($"Delivery was {deliveryEvent.IsCorrect}.");
    }
}