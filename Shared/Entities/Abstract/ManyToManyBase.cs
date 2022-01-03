namespace Shared.Entities.Abstract
{
    public class ManyToManyBase
    {
        public virtual bool IsDeleted { get; set; } = false;
        public virtual bool IsActive { get; set; } = true;
        public virtual int? CreatedByUserId { get; set; }
        public virtual int? ModifiedByUserId { get; set; }
        public virtual DateTime? CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime? ModifiedDate { get; set; }
    }
}