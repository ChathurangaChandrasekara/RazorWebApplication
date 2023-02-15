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
        [TempData]
        public string Message { get; set; }
        public Employee Employee { get; private set; }

        public IActionResult OnGet(int id)
        {
            Employee = employeeRepository.EmployeeGetById(id);
            if(Employee==null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
    }
}
