using System.Linq.Expressions;

namespace TestCoreAPP.Repository.@base
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(params string[] eagers );

        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> FindAllAsync(params string[] agers);
        Task<IEnumerable<T>> GetAllAsync();
        T SelectOne(Expression<Func<T, bool>> match);
        void addCat(T cat);
        void updateCat(T cat);
        void deleteCat(T cat);
        void addListCat(IEnumerable<T> Listcat);
        void updateListCat(IEnumerable<T> Listcat);
        void deleteListCat(IEnumerable<T> Listcat);

    }
}

