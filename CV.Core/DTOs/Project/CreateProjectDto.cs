using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Core.DTOs.Project
{
    public class CreateProjectDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> TechnologiesUsed { get; set; }
        public ICollection<string> GitHubUrls { get; set; }
        public string ProjectURL { get; set; }
        public int PersonId { get; set; }
    }
}
