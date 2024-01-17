namespace WineTourism.Application.Features.Reservations.Queries
{
    public class GetAllReservationsDTO 
    {
        public string Id { get; set; }
        public string DestinationName { get; set; }
        public string UsersName { get; set; }
        public int NumberOfPersons { get; set; }
        public bool BreakfastInHotel { get; set; }
        public bool DinnerInWinery { get; set; }
        public string Note { get; set; }
        public double Price { get; set; }
    }
}
