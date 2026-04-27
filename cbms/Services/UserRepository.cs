using cbms.Models;

namespace cbms.Services
{
    public class UserRepository : ADORepository<User>, IUserRepository
    {
        private readonly DBMethodsUser _dBMethodsUser;
        public UserRepository(IConfiguration configuration) : base(new DBMethodsUser(configuration))
        {
            _dBMethodsUser = new DBMethodsUser(configuration);  
        }

        public User? VerifyUser(string name, string password)
        {
            return _dBMethodsUser.VerifyUser(name, password);
        }
    }
}
