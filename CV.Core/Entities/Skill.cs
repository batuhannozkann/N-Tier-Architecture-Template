using CV.Shared.Entities.Concrete;

namespace CV.Core.Entities
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; }
        public Level ProficiencyLevel { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
    }

    public enum Level{
        Beginner,
        Intermediate,
        UpperIntermediate,
        Expert
    }

}
