using BankingApplication.Models;

namespace BankingApplication.Interface
{
    public interface IRepository<K,T> where T : class
        
    {
        Task<T> Get ( K key );
        Task <IEnumerable<T>> GetAll ();
        Task <int >Delete ( K key );

        Task <T> Update ( K key, T value );

        Task<T> Create(T enity);

    }
}
