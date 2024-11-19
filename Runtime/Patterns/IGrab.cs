namespace CookingSystem
{
    public interface IGrab
    {
        public void Grab();
        public void Drop();
        public void Send(IContainer user);
    }

    public interface IContainer
    {
        public void Empty();
        public void Store(IGrab grab);
        public void Receive(Ingredient ingredient);
        public void Receive(Tray tray);
        public void Receive(Plate plate);
    }
}