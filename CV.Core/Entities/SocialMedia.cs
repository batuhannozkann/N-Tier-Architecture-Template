using CV.Shared.Entities.Concrete;

namespace CV.Core.Entities
{
    public class SocialMedia : BaseEntity
    {
        public string Platform { get; set; }
        public string Username { get; set; }
        public string ProfileURL { get; set; }
    }

}
