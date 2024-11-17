using CV.Core.Entities;
using CV.Shared.DTOs;

namespace CV.Core.DTOs.Skill
{
    public class SkillDto : BaseDto
    {
        public string Name { get; set; }
        public Level ProficiencyLevel { get; set; }
    }
}