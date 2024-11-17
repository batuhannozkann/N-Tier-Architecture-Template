using CV.Shared.DTOs;

namespace CV.Core.DTOs.SocialMedia
{
    public class SocialMediaDto : BaseDto
    {
        public string Platform { get; set; }
        public string Username { get; set; }
        public string ProfileURL { get; set; }
    }
}