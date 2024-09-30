using AdminService.DAL.Filters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminService.DAL.Entities
{
    public class ClientOrder
    {
        [SwaggerIgnore]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; } = null!;
        public string typeEngeeniring { get; set; } = null!;
        public int timeStudy { get; set; }
        public float sumPay { get; set; }

        public int clientDataId { get; set; }
        public ClientData? clientData { get; set; }
    }
}
