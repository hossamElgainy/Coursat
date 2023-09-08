using Coursat.Data;
using Coursat.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Coursat.Repository
{
    public class MainRepository<T> : IRepository<T> where T : class
    {
        public MainRepository(AppDbContext appDbContext) 
        {
            _context = appDbContext;
        }
        private AppDbContext _context { get; set; }

        
        public T GetById(int id) // get one Record According to the Id
        {
            return _context.Set<T>().Find(id);
        }
        public T SelectOne(Expression<Func<T, bool>> match)// get one Record According to any Column
        {
            return _context.Set<T>().SingleOrDefault(match);
        }

        public IEnumerable<T> FindOne(int? id, params string[] agers) // get one Record According to the Id with eager loading
        {
            IQueryable<T> query = _context.Set<T>();

            if (agers.Length > 0)
            {
                foreach (var ager in agers)
                {
                    query = query.Include(ager);
                }
            }

            return query.ToList();
        }
        public IEnumerable<T> GetAll() // get all Record 
        {
            return _context.Set<T>().ToList();
        }
        public IEnumerable<T> GetGroupedList(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().Where(match).ToList();
        }
        
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public int Count()
        {
            return _context.Set<T>().Count();    
        }

        
    }
}
