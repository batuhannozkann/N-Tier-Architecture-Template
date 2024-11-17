using CV.Shared.DTOs;

namespace CV.Core.DTOs.Reference
{
    public class ReferenceDto : BaseDto
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}