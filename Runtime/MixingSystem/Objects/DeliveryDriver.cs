using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CookingSystem
{
    using EmptyDriver = EmptyEvent<DeliveryDriver>;
    
     public class DeliveryDriver : MonoBehaviour, IContainer
     {
         private TMP_Text _textbox;
         private Recipe _requestedRecipe;
         private Plate _deliveredPlate;
     
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
     
         private void AddToDelivery(Plate plate)
         {
             _deliveredPlate = plate;
             CheckDelivery();
         }
     
         private void RemoveFromDelivery()
         {
             _deliveredPlate = null;
             EventBus<EmptyDriver>.Raise(new EmptyDriver(this));
         }
         
         private void CheckDelivery()
         {
             var isCorrect = Deliver(_deliveredPlate);
             EventBus<DeliverEvent>.Raise(new DeliverEvent(isCorrect));
             Request();
             
             _deliveredPlate.Empty();
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
     
         public void Empty() => RemoveFromDelivery();
         public void Store(IGrab grab) => grab.Send(this);
         public void Receive(Ingredient ingredient) { }
         public void Receive(Tray tray) { }
         public void Receive(Plate plate) => AddToDelivery(plate);
     }   
}