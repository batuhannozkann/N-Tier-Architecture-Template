using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Core.DTOs.Reference
{
    public class CreateReferenceDto
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int PersonId { get; set; }
    }
}
