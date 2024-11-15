using CV.Shared.Entities.Concrete;

namespace CV.Core.Entities
{
    public class Project : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> TechnologiesUsed { get; set; }
        public ICollection<string> GitHubUrls { get; set; }
        public string ProjectURL { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
    }

}
