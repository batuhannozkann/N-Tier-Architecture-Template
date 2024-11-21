using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Core.DTOs.SocialMedia
{
    public class CreateSocialMediaDto
    {
        public string Platform { get; set; }
        public string Username { get; set; }
        public string ProfileURL { get; set; }
        public int PersonId { get; set; }
    }
}
