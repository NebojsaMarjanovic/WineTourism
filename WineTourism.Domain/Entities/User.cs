using Microsoft.AspNetCore.Identity;
using WineTourism.Domain.Common;
using WineTourism.Domain.Common.Interfaces;

namespace WineTourism.Domain.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Reservation> Reservations { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
