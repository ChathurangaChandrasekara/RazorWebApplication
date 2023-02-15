using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorWebApplication.Models;
using RazorWebApplication.Services;

namespace RazorWebApplication.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public EditModel(IEmployeeRepository employeeRepository, IWebHostEnvironment webHostEnvironment)
        {
            this.employeeRepository = employeeRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

        public Employee? Employee { get; private set; }
        [BindProperty]
        public IFormFile Photo { get; set; }

        public IActionResult OnGet(int id)
        {
            Employee = employeeRepository.EmployeeGetById(id);
            if (Employee == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
        public IActionResult OnPost(Employee employee)
        {
            if (Photo != null) 
            {
                if(employee.PhotoPath != null)
                {
                    string filePath = Path.Combine(webHostEnvironment.WebRootPath, "images", employee.PhotoPath.Trim());
                    System.IO.File.Delete(filePath);
                }
                employee.PhotoPath = ProcessUploadedFile();
            }
            Employee = employeeRepository.Update(employee);
            return RedirectToPage("Index");
        }
        private string ProcessUploadedFile()
        {
            string uniquFileName = null;

            if(Photo != null)
            {
                string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");

                uniquFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;

                string filePath = Path.Combine(uploadFolder, uniquFileName);

                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }
            return uniquFileName;
        }
    }
}
