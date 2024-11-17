using CV.Core.DTOs.Address;
using CV.Core.DTOs.Attachment;
using CV.Core.DTOs.Certificate;
using CV.Core.DTOs.Education;
using CV.Core.DTOs.Project;
using CV.Core.DTOs.Reference;
using CV.Core.DTOs.Skill;
using CV.Core.DTOs.SocialMedia;
using CV.Core.Entities;
using CV.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Core.DTOs.Person
{
    public class PersonDto:BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Image { get; set; }
        public ICollection<CertificateDto>? Certificates { get; set; }
        public ICollection<ProjectDto>? Projects { get; set; }
        public ICollection<EducationDto>? Educations { get; set; }
        public ICollection<SocialMediaDto>? SocialMedias { get; set; }
        public ICollection<SkillDto>? Skills { get; set; }
        public ICollection<ReferenceDto>? References { get; set; }
        public ICollection<AttachmentDto>? Attachments { get; set; }
        public ICollection<AddressDto>? Addresses { get; set; }
    }
}
