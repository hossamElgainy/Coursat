using System.Linq.Expressions;

namespace Coursat.Repository.Base
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        T SelectOne(Expression<Func<T, bool>> match);
        IEnumerable<T> GetGroupedList(Expression<Func<T, bool>> match);
        IEnumerable<T> GetAll();
        IEnumerable<T> FindOne(int? id,params string[] agers);
        int Count();

        void Add(T entity);
        void Update(T entity);  
        void Delete(T entity);
    }
}
