using CV.Core.DTOs.Address;
using CV.Core.DTOs.Attachment;
using CV.Core.DTOs.Certificate;
using CV.Core.DTOs.Education;
using CV.Core.DTOs.Project;
using CV.Core.DTOs.Reference;
using CV.Core.DTOs.Skill;
using CV.Core.DTOs.SocialMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Core.DTOs.Person
{
    public class CreatePersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Image { get; set; }
        public ICollection<CreateCertificateDto>? Certificates { get; set; }
        public ICollection<CreateProjectDto>? Projects { get; set; }
        public ICollection<CreateEducationDto>? Educations { get; set; }
        public ICollection<CreateSocialMediaDto>? SocialMedias { get; set; }
        public ICollection<CreateSkillDto>? Skills { get; set; }
        public ICollection<CreateReferenceDto>? References { get; set; }
        public ICollection<CreateAttachmentDto>? Attachments { get; set; }
        public ICollection<CreateAddressDto>? Addresses { get; set; }
    }
}
