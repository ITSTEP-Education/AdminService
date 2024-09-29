using System.ComponentModel.DataAnnotations.Schema;

namespace AdminService.DAL.Infrastructures
{
    [NotMapped]
    public class StatusCode400 : Exception
    {
        public int code { get; }
        public string property { get; } = null!;

        public StatusCode400(string property) : this(400, "inputed uncorrect format", property) { }
        public StatusCode400(int code, string msg, string property) : base(msg)
        {
            this.code = code;
            this.property = property;
        }
    }
}
