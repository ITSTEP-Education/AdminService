using AdminService.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace AdminService.DAL.Infrastructures
{
    public class EmptyClientOrderAttribute : ValidationAttribute
    {
        private string text = "empty field";
        public EmptyClientOrderAttribute() { }

        public override bool IsValid(object? value)
        {
            ClientOrder? co = value as ClientOrder;

            if(string.IsNullOrWhiteSpace(co?.name)){
                ErrorMessage = $"{text} \"name\"";
                return false;
            }
            else if (co?.clientData == null)
            {
                ErrorMessage = $"{text} \"ClientData\"";
                return false;
            }

            return true;
        }
    }
}
