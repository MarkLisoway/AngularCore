namespace BusinessLogic.CoreEntity
{
    public interface IEntity<out T>
    {
        
        T Value { get; }
        
        EntityState State { get; }

        bool HasValue { get; }

    }
}