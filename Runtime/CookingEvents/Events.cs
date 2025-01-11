namespace CookingSystem.Events
{
    public struct BeginCookingEvent : ICookEvent { }
    public struct EndCookingEvent : ICookEvent { }
    public struct AddIngredient : ICookEvent { }
}