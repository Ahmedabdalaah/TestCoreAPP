using TestCoreAPP.Areas.Employee.Models;
using TestCoreAPP.Data;
using TestCoreAPP.Repository.@base;

namespace TestCoreAPP.Repository
{
    public class EmpRep : MainRepositorycs<Employee>, IEmployeeRep
    {
        public EmpRep(AppDBContext context) : base(context)
        {
            _context = context;   
        }
        private readonly AppDBContext _context;

        public decimal getSallay(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void setPay(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
