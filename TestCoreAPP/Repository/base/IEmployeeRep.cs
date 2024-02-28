using TestCoreAPP.Areas.Employee.Models;

namespace TestCoreAPP.Repository.@base
{
    public interface IEmployeeRep : IRepository<Employee>
{
        void setPay(Employee employee);
        decimal getSallay(Employee employee);
}
}
