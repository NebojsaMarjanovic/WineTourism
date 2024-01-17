using WineTourism.Domain.Common;

namespace WineTourism.Domain.Entities
{
    public class Wine : BaseEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Winery> Wineries { get; set; }
    }
}
