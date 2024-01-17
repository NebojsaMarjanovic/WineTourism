using WineTourism.Domain.Common.Interfaces;

namespace WineTourism.Domain.Common
{
    public abstract class BaseEntity : IEntity
    {
        public string Id { get; set; }
    }
}
