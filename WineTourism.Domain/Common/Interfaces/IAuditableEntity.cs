﻿namespace WineTourism.Domain.Common.Interfaces
{
    public interface IAuditableEntity
    {
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }
}