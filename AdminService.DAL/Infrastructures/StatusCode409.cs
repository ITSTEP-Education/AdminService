using System.ComponentModel.DataAnnotations.Schema;

namespace AdminService.DAL.Infrastructures
{
    [NotMapped]
    public class StatusCode409 : Exception
    {
        public int code { get; }
        public string property { get; } = null!;

        public StatusCode409(string property) : this(409, "no connection to db", property) { }
        public StatusCode409(int code, string msg, string property) : base(msg)
        {
            this.code = code;
            this.property = property;
        }
    }
}
