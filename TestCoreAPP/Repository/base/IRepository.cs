namespace TestCoreAPP.Repository.@base
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}

