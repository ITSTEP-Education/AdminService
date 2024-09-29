using System.ComponentModel.DataAnnotations.Schema;

namespace AdminService.DAL.Infrastructures
{
    [NotMapped]
    public class StatusCode
    {
        public int code { get; }
        public string message { get; } = null!;

        public StatusCode(int code, string message)
        {
            this.code = code;
            this.message = message;
        }
    }
}
