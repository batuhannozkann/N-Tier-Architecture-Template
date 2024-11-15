using CV.Shared.Entities.Concrete;

namespace CV.Core.Entities
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; }
        public Level ProficiencyLevel { get; set; } // e.g., Beginner, Intermediate, Expert
    }

    public enum Level{
        Beginner,
        Intermediate,
        UpperIntermediate,
        Expert
    }

}
