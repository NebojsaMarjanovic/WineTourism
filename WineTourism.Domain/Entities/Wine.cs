using WineTourism.Domain.Common;
using WineTourism.Domain.Common.Interfaces;

namespace WineTourism.Domain.Entities
{
    public class Wine : BaseEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Winery> Wineries { get; set; }
    }
}
