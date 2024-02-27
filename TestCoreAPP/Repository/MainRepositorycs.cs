using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Linq.Expressions;
using TestCoreAPP.Data;
using TestCoreAPP.Repository.@base;

namespace TestCoreAPP.Repository
{
    public class MainRepositorycs<T> : IRepository<T> where T : class
    {
        public MainRepositorycs(AppDBContext dbContext) 
        { 
            this.dbContext = dbContext;
        }
        protected AppDBContext dbContext;
        public T GetById(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>().ToList();

        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async  Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public T SelectOne(Expression<Func<T, bool>> match)
        {
            return dbContext.Set<T>().SingleOrDefault(match);
        }

        public IEnumerable<T> GetAll(params string[] eagers)
        {
            IQueryable<T> query = dbContext.Set<T>();
            if(eagers.Length >0 )
            {
                foreach(var eager in eagers)
                {
                    query=query.Include(eager);
                }
            }
            return query.ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync(params string[] agers)
        {
            IQueryable<T> query = dbContext.Set<T>();

            if (agers.Length > 0)
            {
                foreach (var ager in agers)
                {
                    query = query.Include(ager);
                }
            }

            return await query.ToListAsync();
        }

        public void addCat(T cat)
        {
            dbContext.Set<T>().Add(cat);    
            dbContext.SaveChanges();
        }

        public void updateCat(T cat)
        {
            dbContext.Set<T>().Update(cat);
            dbContext.SaveChanges();
        }

        public void deleteCat(T cat)
        {
            dbContext.Set<T>().Remove(cat);
            dbContext.SaveChanges() ;   
        }

        public void addListCat(IEnumerable<T> Listcat)
        {
            dbContext.AddRange(Listcat);
            dbContext.SaveChanges();
        }

        public void updateListCat(IEnumerable<T> Listcat)
        {
            dbContext.UpdateRange(Listcat);
            dbContext.SaveChanges();
        }

        public void deleteListCat(IEnumerable<T> Listcat)
        {
            dbContext.RemoveRange(Listcat); 
            dbContext.SaveChanges();    
        }
    }
}
