namespace WineTourism.Domain.Common.Interfaces
{
    public interface IAuditableEntity
    {
        public string CreatedBy { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }

    }
}
