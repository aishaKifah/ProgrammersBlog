using System;

namespace ProgrammersBlog.Shared.Entities.Abstract
{
    public abstract class EntityBase
    {
        public virtual DateTime createdDate { get; set; } = DateTime.Now;
        public virtual DateTime modifiedDate { get; set; } = DateTime.Now;
        public virtual bool isActive { get; set; } = true;
        public virtual bool isDeleted { get; set; } = false;
        public virtual String createdByname { get; set; } = "Admin";
        public virtual String modifiedByName { get; set; } = "Admin";
        public virtual String note { get; set; }


    }
}
