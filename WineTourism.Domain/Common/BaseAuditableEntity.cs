using WineTourism.Domain.Common.Interfaces;

namespace WineTourism.Domain.Common
{
    public abstract class BaseAuditableEntity : BaseEntity, IAuditableEntity
    {
        public string CreatedBy { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
    }
}
