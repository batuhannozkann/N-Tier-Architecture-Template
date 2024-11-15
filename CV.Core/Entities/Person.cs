using CV.Shared.Entities.Abstract;
using CV.Shared.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Core.Entities
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public ICollection<Certificate> Certificates { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Education> Educations { get; set; }
        public ICollection<SocialMedia> SocialMedias { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<Reference> References { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
        public ICollection<Address> Addresses { get; set; }
        
    }

}
