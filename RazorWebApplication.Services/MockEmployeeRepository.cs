using RazorWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorWebApplication.Services
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employees;
        public MockEmployeeRepository()
        {
            _employees = new List<Employee>()
            {
                new Employee(){ Id = 1, Name = "Mary", Department = Dept.HR, Email = "mary@gmail.com", PhotoPath = "mary.png" },
                new Employee(){ Id = 2, Name = "John", Department = Dept.IT, Email = "jhon@gmail.com", PhotoPath = "jhon.png" },
                new Employee(){ Id = 3, Name = "Sara", Department = Dept.IT, Email = "sara@gmail.com", PhotoPath = "sara.png" },
                new Employee(){ Id = 4, Name = "David", Department = Dept.Payroll, Email = "david@gmail.com" },
            };
        }

        public Employee EmployeeGetById(int id)
        {
            return _employees.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

        public Employee Update(Employee updatedEmployee)
        {
            Employee employee = _employees.FirstOrDefault(x => x.Id == updatedEmployee.Id);

            if(employee!=null)
            {
                employee.Name = updatedEmployee.Name;
                employee.Email = updatedEmployee.Email;
                employee.Department= updatedEmployee.Department;
                employee.PhotoPath = updatedEmployee.PhotoPath;
            }
            return employee;
        }
    }
}
