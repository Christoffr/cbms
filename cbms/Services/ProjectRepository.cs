using cbms.Models;

namespace cbms.Services
{
    public class ProjectRepository : ADORepository<Project>, IRepository<Project>
    {
        public ProjectRepository(IConfiguration configuration) : base(new DBMethodsProject(configuration))
        {
        }
    }
}
