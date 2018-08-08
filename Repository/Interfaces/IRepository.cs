namespace Repository.Interfaces
{
    public interface IRepository<T>
    {
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(int id);
        void Commit();
    }
}
