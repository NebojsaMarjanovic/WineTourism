using Microsoft.AspNetCore.Identity;

namespace WineTourism.Domain.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
