namespace AdminService.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T>? getAllItems();

        public void deleteItem(string name);
    }
}
