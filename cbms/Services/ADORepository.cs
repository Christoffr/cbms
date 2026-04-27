namespace cbms.Services
{
    public class ADORepository<T> : IRepository<T> where T : class
    {
        private DBMethods<T> _dbMethods;
        public ADORepository(DBMethods<T> dbMethods)
        {
            _dbMethods = dbMethods;
        }
        public void Create(T entity)
        {
            _dbMethods.Create(entity);
        }
    }
}
