using UnityEngine;

namespace CookingSystem
{
    public class Appliance : IContainer, ITool
    {
        private readonly CookState _cookState;
        private Tray _currentTray;

        public Appliance(CookState cookState)
        {
            _cookState = cookState;
        }

        public Appliance(CookState cookState, Tray currentTray)
        {
            _cookState = cookState;
            _currentTray = currentTray;
        }

        private void Add(IProduct product)
        {
            if (product is Tray tray) Add(tray);
        }

        private void Add(Tray tray)
        {
            _currentTray = tray;
        }

        private void Clear()
        {
            _currentTray = null;
        }
        
        private void Cook()
        {
            _currentTray?.ChangeState(_cookState);
        }

        #region Interface Functions
        public void Empty() => Clear();
        public void Store(IProduct product) => Add(product);
        public void Use() => Cook();
        #endregion
    }   
}