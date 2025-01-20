namespace BankingApplication.Interface
{
    public interface IRepository<K,T> where T : class
        
    {
        Task<T> Get ( K key );
        Task <IEnumerable<T>> GetAll ( K key );
        Task Delete ( K key );

        Task <T> Update ( K key, T value );

        Task<T> Create(T enity);

    }
}
