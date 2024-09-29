using AdminService.DAL.Filters;
using System.ComponentModel.DataAnnotations;

namespace AdminService.DAL.Entities
{
    public class ClientOrder
    {
        [SwaggerIgnore]
        public int id { get; set; }
        public string name { get; set; } = null!;
        public string typeEngeeniring { get; set; } = null!;
        public int timeStudy { get; set; }
        public float sumPay { get; set; }
        public int clientDataId { get; set; }
        public ClientData? clientData { get; set; }
    }
}
