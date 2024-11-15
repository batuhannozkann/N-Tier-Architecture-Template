using CV.Shared.Entities.Concrete;

namespace CV.Core.Entities
{
    public class Reference : BaseEntity
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
    }

}
