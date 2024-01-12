using WineTourism.Domain.Common.Interfaces;

namespace WineTourism.Domain.Common
{
    public class BaseEntity : IEntity
    {
        public string Id { get; set; }
    }
}
