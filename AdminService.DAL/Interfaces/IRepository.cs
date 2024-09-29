namespace AdminService.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T>? getAllItems();
    }
}
