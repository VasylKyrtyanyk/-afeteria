namespace Сafeteria.DataModels.Entities.Abstraction
{
    /// <summary>
    /// Interface which should be implemented by each entity
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
