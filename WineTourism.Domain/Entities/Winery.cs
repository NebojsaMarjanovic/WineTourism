using WineTourism.Domain.Common;

namespace WineTourism.Domain.Entities
{
    public class Winery : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Wine> Wines { get; set; }
    }
}
