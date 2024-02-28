using TestCoreAPP.Areas.Employee.Models;
using TestCoreAPP.Controllers;
using TestCoreAPP.Data;
using TestCoreAPP.Models;
using TestCoreAPP.Repository.@base;

namespace TestCoreAPP.Repository
{
    public class UnitOfWork : IunitOfWork
    {
        public UnitOfWork(AppDBContext context)
        {
            _context = context;
            categories = new MainRepositorycs<Categories>(_context);
            items = new MainRepositorycs<Item> (_context);
            employee = new EmpRep(_context);
        }
     private readonly AppDBContext _context;

        public IRepository<Categories> categories { get; private set; }

        public IRepository<Item> items { get; private set; }

        public IEmployeeRep employee { get; private set; }

        int IunitOfWork.commitChanges => throw new NotImplementedException();

        public int commitChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
