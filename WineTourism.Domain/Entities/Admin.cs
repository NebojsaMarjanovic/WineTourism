using Microsoft.AspNetCore.Identity;

namespace WineTourism.Domain.Entities
{
    public class Admin : IdentityUser
    {
        public DateTime EmploymentDate { get; set; }
    }
}
