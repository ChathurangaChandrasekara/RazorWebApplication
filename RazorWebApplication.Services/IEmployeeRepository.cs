using RazorWebApplication.Models;

namespace RazorWebApplication.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
    }
}