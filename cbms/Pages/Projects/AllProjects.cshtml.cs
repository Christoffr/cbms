using cbms.Models;
using cbms.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cbms.Pages.Projects
{
    public class AllProjectsModel : PageModel
    {
        private IRepository<Project> _projectRepository;

        public List<Project> Projects { get; set; }

        public AllProjectsModel(IRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public void OnGet()
        {
            Projects = _projectRepository.ReadAll();
        }
    }
}
