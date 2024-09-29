
namespace AdminService.BLL.Infrastructures
{
    public class AdminServiceException : Exception
    {
        public string property { get; } = null!;
        public AdminServiceException(string message, string property) : base(message) 
        { 
            this.property = property;
        }

        public AdminServiceException(AdminServiceException ex) : base(ex.Message) { this.property = ex.property; }

    }
}
