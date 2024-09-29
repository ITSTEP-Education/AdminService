using System.ComponentModel.DataAnnotations.Schema;

namespace AdminService.DAL.Infrastructures
{
    [NotMapped]
    public class StatusCode201 : StatusCode
    {
        public string property { get; } = null!;

        public StatusCode201(string property) : this(201, "operation is done in db", property) { }

        public StatusCode201(string message, string property) : this(201, message, property) { }
        private StatusCode201(int code, string msg, string property) : base(code, msg)
        {
            this.property = property;
        }
    }
}
