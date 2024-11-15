using CV.Shared.Entities.Concrete;

namespace CV.Core.Entities
{
    public class Education : BaseEntity
    {
        public string InstitutionName { get; set; }
        public string Degree { get; set; }
        public string FieldOfStudy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double? GPA { get; set; }
    }

}
