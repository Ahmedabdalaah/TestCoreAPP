using TestCoreAPP.Areas.Employee.Models;
using TestCoreAPP.Models;

namespace TestCoreAPP.Repository.@base
{
    public interface IunitOfWork : IDisposable
{
        IRepository<Categories> categories { get; }
        IRepository<Item> items { get; }    
        IEmployeeRep employee { get; }
        int commitChanges { get; }

    }
}
