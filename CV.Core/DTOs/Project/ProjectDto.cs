using CV.Shared.DTOs;

namespace CV.Core.DTOs.Project
{
    public class ProjectDto : BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> TechnologiesUsed { get; set; }
        public ICollection<string> GitHubUrls { get; set; }
        public string ProjectURL { get; set; }
    }
}