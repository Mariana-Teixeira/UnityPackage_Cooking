namespace CookingSystem
{
    public interface IContainer
    {
        public void Empty();
        public void Store(IProduct product);
    }
}