using WineTourism.Domain.Common;

namespace WineTourism.Domain.Entities
{
    public class Hotel : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }

    }
}
