using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Serialization;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private TMP_Text _activeElement;
    [SerializeField] private TMP_Text _contentTray;

    private HashSet<Ingredient> _ingredients;
    
    private EventBinding<GrabObject<Ingredient>> _grabIngredient;
    private EventBinding<GrabObject<Tray>> _grabTray;
    private EventBinding<GrabObject<Plate>> _grabPlate;

    private EventBinding<DropOnObject<Ingredient, Tray>> _useTray;
    
    private void Awake()
    {
        _ingredients = new HashSet<Ingredient>();
        
        _grabIngredient = new EventBinding<GrabObject<Ingredient>>(GrabIngredient);
        _grabTray = new EventBinding<GrabObject<Tray>>(tray => _activeElement.text = $"Active Tray:\n{tray.TargetObject.name}");
        _grabPlate = new EventBinding<GrabObject<Plate>>(plate => _activeElement.text = $"Active Plate:\n{plate.TargetObject.name}");

        _useTray = new EventBinding<DropOnObject<Ingredient, Tray>>(PrintIngredientsInTray);
    }

    private void OnEnable()
    {
        EventBus<GrabObject<Ingredient>>.Register(_grabIngredient);
        EventBus<GrabObject<Tray>>.Register(_grabTray);
        EventBus<GrabObject<Plate>>.Register(_grabPlate);
        
        EventBus<DropOnObject<Ingredient, Tray>>.Register(_useTray);
    }

    private void OnDisable()
    {
        EventBus<GrabObject<Ingredient>>.Deregister(_grabIngredient);
        EventBus<GrabObject<Tray>>.Deregister(_grabTray);
        EventBus<GrabObject<Plate>>.Deregister(_grabPlate);
        
        EventBus<DropOnObject<Ingredient, Tray>>.Deregister(_useTray);
    }

    private void GrabIngredient(GrabObject<Ingredient> grabIngredient)
    {
        _activeElement.text = $"Active Ingredient:\n{grabIngredient.TargetObject.name}";
        _ingredients.Add(grabIngredient.TargetObject);
    }

    private void PrintIngredientsInTray(DropOnObject<Ingredient, Tray> trayEvent)
    {
        _activeElement.text = string.Empty;
        _contentTray.text = $"Content of {trayEvent.TargetObject.name}\n";
        foreach (var ingredient in _ingredients) _contentTray.text += $"- {ingredient.name}\n";
    }
}