using cbms.Models;
using cbms.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.Pkcs;

namespace cbms.Pages.Projects
{
    public class CreateProjectModel : PageModel
    {
        private IRepository<Project> _projectRepository;

        [BindProperty]
        public Project Project { get; set; }
       
        public CreateProjectModel(IRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
                return Page();

            _projectRepository.Create(Project);
            return RedirectToPage("/Index");
        }
    }
}
