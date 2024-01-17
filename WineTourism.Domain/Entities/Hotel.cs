using WineTourism.Domain.Common;

namespace WineTourism.Domain.Entities
{
    public class Hotel : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Destination Destination { get; set; }
        public int DestinationId { get; set; }

    }
}
