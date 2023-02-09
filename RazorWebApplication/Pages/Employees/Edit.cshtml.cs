using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorWebApplication.Models;
using RazorWebApplication.Services;

namespace RazorWebApplication.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepository employeeRepository;

        public EditModel(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public Employee Employee { get; private set; }

        public IActionResult OnGet(int id)
        {
            Employee = employeeRepository.EmployeeGetById(id);
            if (Employee == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
    }
}
