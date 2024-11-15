using CV.Shared.Entities.Abstract;

namespace CV.Shared.Entities.Concrete
{
    public class BaseEntity:IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
