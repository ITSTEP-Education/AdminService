namespace AdminService.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T>? getAllItems();

        public T getItem(string name);
        public void deleteItem(string name);
    }
}
