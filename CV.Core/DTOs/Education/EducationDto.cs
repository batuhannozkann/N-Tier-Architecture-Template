using CV.Shared.DTOs;

namespace CV.Core.DTOs.Education
{
    public class EducationDto : BaseDto
    {
        public string InstitutionName { get; set; }
        public string Degree { get; set; }
        public string FieldOfStudy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double? GPA { get; set; }
    }
}