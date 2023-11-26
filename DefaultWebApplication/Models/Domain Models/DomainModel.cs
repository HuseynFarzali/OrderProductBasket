using System;

namespace DefaultWebApplication.Models.Domain_Models
{
    public abstract class DomainModel
    {
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }

        protected DomainModel()
        {
            Deleted = false;
            CreatedDate = DateTime.Now;
        }
    }
}
