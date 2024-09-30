using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminService.DAL.Infrastructures
{
    [NotMapped]
    public class StatusCode200 : StatusCode
    {
        public string property { get; } = null!;

        public StatusCode200(string property) : this(200, "request done", property) {}

        private StatusCode200(int code, string msg, string property) : base(code, msg) 
        { 
            this.property = property;
        }
    }
}
