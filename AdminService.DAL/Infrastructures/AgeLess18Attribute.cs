using AdminService.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace AdminService.DAL.Infrastructures
{
    public class AgeLess18Attribute : ValidationAttribute
    {
        public AgeLess18Attribute() {
            ErrorMessage = "Age =< 18";
        }

        public override bool IsValid(object? value)
        {

            if(value != null && (Math.Abs((int)value) > 18)){
                return true;
            }

            return false;
        }
    }
}
