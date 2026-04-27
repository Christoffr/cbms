using cbms.Models;

namespace cbms.Services
{
    public interface IUserRepository : IRepository<User>
    {
          User? VerifyUser(string name, string password);
    }
}
