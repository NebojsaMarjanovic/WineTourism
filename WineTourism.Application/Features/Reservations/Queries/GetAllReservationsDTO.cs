using WineTourism.Application.Common.Mappings;
using WineTourism.Domain.Entities;

namespace WineTourism.Application.Features.Reservations.Queries
{
    public class GetAllReservationsDTO : IMapFrom<Reservation>
    {
        public string Id { get; set; }
        public string CityName { get; set; }
        public string UsersName { get; set; }
        public int NumberOfPersons { get; set; }
        public bool BreakfastInHotel { get; set; }
        public bool DinnerInWinery { get; set; }
        public string Note { get; set; }
        public double Price { get; set; }
    }
}
