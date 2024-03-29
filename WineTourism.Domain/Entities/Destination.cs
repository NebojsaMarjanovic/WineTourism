﻿using WineTourism.Domain.Common;

namespace WineTourism.Domain.Entities
{
    public class Destination : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int AvailableSeatsCount { get; set; }
        public string TravelProgram { get; set; }
        public double PricePerPerson { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Winery Winery { get; set; }
        public string WineryId { get; set; }
        public Hotel Hotel { get; set; }
        public string HotelId { get; set; }
        public List<Reservation> Reservations { get; set; }

    }
}
