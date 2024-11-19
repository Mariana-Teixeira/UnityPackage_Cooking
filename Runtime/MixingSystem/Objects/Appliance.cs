using TMPro;
using UnityEngine;

namespace CookingSystem
{
    using StoreEvent = StoreEvent<Appliance>;
    using EmptyEvent = EmptyEvent<Appliance>;
    
    public class Appliance : MonoBehaviour, IContainer, IStatic
    {
        [SerializeField] private CookState _cookState;
        private Tray _currentTray;
        private TMP_Text _textbox;

        public Tray GetTray => _currentTray;

        private void Awake()
        {
            _textbox = GetComponentInChildren<TMP_Text>();
        }

        private void AddToAppliance(Tray tray)
        {
            _currentTray = tray;
            EventBus<StoreEvent>.Raise(new StoreEvent(this));
        }

        private void Cook()
        {
            _currentTray?.Cook(_cookState);
        }

        private void EmptyAppliance()
        {
            _currentTray = null;
            EventBus<EmptyEvent>.Raise(new EmptyEvent(this));
        }

        public void WriteText(string text) => _textbox.text = text;
        public void ClearText() => _textbox.text = this.name;

        public void Empty() => EmptyAppliance();
        public void Store(IGrab grab) => grab.Send(this);
        public void Receive(Ingredient ingredient) { }
        public void Receive(Tray tray) => AddToAppliance(tray);
        public void Receive(Plate plate) { }

        public void Use()
        {
            Cook();
            Empty();
        }
    }   
}