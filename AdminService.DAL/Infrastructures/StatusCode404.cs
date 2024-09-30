using System.ComponentModel.DataAnnotations.Schema;

namespace AdminService.DAL.Infrastructures
{
    [NotMapped]
    public class StatusCode404 : Exception
    {
        public int code { get; }
        public string property { get; } = null!;

        public StatusCode404(string property) : this(404, "records are absent in db", property) { }
        public StatusCode404(int code, string msg, string property) : base(msg)
        {
            this.code = code;
            this.property = property;
        }
    }
}
