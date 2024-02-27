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
    }
}
