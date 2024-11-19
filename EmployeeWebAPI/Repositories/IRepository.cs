namespace EmployeeWebAPI.Repositories
{
    public interface IRepository<T>
    {
        public int Add(T entity);
       
        public T GetById(Guid id);
        public IQueryable<T> GetAll();
    }
}
