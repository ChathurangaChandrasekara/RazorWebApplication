using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorWebApplication.Models;
using RazorWebApplication.Services;

namespace RazorWebApplication.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly IEmployeeRepository employeeRepository;

        public DetailsModel(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public Employee Employee { get; private set; }

        public void OnGet(int id)
        {
            Employee = employeeRepository.EmployeeGetById(id);
        }
    }
}
