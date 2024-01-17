namespace WineTourism.Application.DTOs
{
    public record CreateReservationDTO
    {
        public int DestinationId { get; set; }
        public int UserId { get; set; }
        public int NumberOfPersons { get; set; }
        public bool BreakfastInHotel { get; set; }
        public bool DinnerInWinery { get; set; }
        public string Note { get; set; }
        public double TotalPrice { get; set; }
    }
}
