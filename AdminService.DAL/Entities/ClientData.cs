using AdminService.DAL.Filters;
using AdminService.DAL.Infrastructures;
using System.ComponentModel.DataAnnotations;

namespace AdminService.DAL.Entities
{
    
    public class ClientData : IValidatableObject
    {
        [SwaggerIgnore]
        public int id { get; set; }
        public string firstName { get; set; } = null!;
        public string lastName { get; set; } = null!;
        [AgeLess18]
        public int age { get; set; }
        public string mobile { get; set; } = null!;

        [SwaggerIgnore]
        public ClientOrder? clientOrder { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.firstName))
            {
                errors.Add(new ValidationResult("input field \"firstName\" in ClientOrder"));
            }
            if (string.IsNullOrWhiteSpace(this.lastName))
            {
                errors.Add(new ValidationResult("input field \"lastName\" in ClientOrder"));
            }
            if (string.IsNullOrWhiteSpace(this.mobile))
            {
                errors.Add(new ValidationResult("input field \"mobile\" in ClientOrder"));
            }

            return errors;
        }
    }
}
