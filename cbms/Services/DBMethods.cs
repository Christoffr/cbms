using Microsoft.Data.SqlClient;

namespace cbms.Services
{
    public abstract class DBMethods<T> where T : class
    {
        private string _tableName;
        private string _paramterList;

        protected string ConnectionString { get; }

        public DBMethods(IConfiguration configuration, string tableName, string parameterList)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            _tableName = tableName;
            _paramterList = parameterList;
        }

        public void Create(T entity)
        {
            string quaryString = $"INSERT INTO {_tableName} VALUES {_paramterList}";
            // Code to create a new record in the database
            try
            {
                using SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                
                using SqlCommand command = new SqlCommand(quaryString, connection);
                AddParametersValues(command, entity);

                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Exception: {ex.Message}");
                throw;
            }
        }

        public List<T> ReadAll()
        {
            string quaryString = $"SELECT * FROM {_tableName}";
            List<T> entities = new List<T>();
            try
            {
                using SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
               
                using SqlCommand command = new SqlCommand(quaryString, connection);
                using var reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    entities.Add(GetRow(reader));
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Exception: {ex.Message}");
                throw;
            }
            return entities;
        }

        protected abstract void AddParametersValues(SqlCommand command, T entity);

        protected abstract T GetRow(SqlDataReader reader);
    }
}
