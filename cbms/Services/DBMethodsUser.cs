using cbms.Models;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Identity;

namespace cbms.Services
{
    public class DBMethodsUser : DBMethods<User>
    {
        public DBMethodsUser(IConfiguration configuration) : base(configuration, "cbms_User", "(@Name, @Role, @PasswordHash)")
        {
        }

        public User? VerifyUser(string name, string password)
        {
            string query = "SELECT Id, Name, Role, PasswordHash FROM cbms_User WHERE Name = @Name";
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", name);

            using var reader = command.ExecuteReader();
            if (!reader.Read()) return null;

            var hash = reader.GetString(3);
            var user = new User
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Role = reader.GetString(2)
            };

            var passwordHasher = new PasswordHasher<User>();
            var result = passwordHasher.VerifyHashedPassword(user, hash, password);
            return result == PasswordVerificationResult.Success ? user : null;
        }

        protected override void AddParametersValues(SqlCommand command, User entity)
        {
            var passwordHasher = new PasswordHasher<User>();
            var hashedPassword = passwordHasher.HashPassword(entity, entity.Password);

            command.Parameters.AddWithValue("@Name", entity.Name);
            command.Parameters.AddWithValue("@Role", entity.Role);
            command.Parameters.AddWithValue("@PasswordHash", hashedPassword);
        }

        protected override User GetRow(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
