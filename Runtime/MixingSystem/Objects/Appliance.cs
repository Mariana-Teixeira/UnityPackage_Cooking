namespace CookingSystem
{
    public class Appliance : IContainer, ITool
    {
        private readonly DishState _dishState;
        private Tray _currentTray;

        public Appliance(DishState dishState)
        {
            _dishState = dishState;
        }

        public Appliance(DishState dishState, Tray currentTray)
        {
            _dishState = dishState;
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
            _currentTray?.ChangeState(_dishState);
        }

        #region Interface Functions
        public void Empty() => Clear();
        public void Store(IProduct product) => Add(product);
        public void Use() => Cook();
        #endregion
    }   
}