namespace cbms.Services
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        List<T> ReadAll();
    }
}
