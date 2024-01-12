using WineTourism.Domain.Common;

namespace WineTourism.Domain.Entities
{
    public class Reservation : BaseAuditableEntity
    {
        public int CityId { get; set; }
        public City City { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int NumberOfPersons { get; set; }
        public bool BreakfastInHotel { get; set; }
        public bool DinnerInWinery { get; set; }
        public string Note { get; set; }
        public double Price { get; set; }

    }
}
