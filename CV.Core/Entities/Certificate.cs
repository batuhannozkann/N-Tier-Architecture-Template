using CV.Shared.Entities.Concrete;

namespace CV.Core.Entities
{
    public class Certificate : BaseEntity
    {
        public string Name { get; set; }
        public string? IssuingOrganization { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? CredentialID { get; set; }
        public string? CredentialURL { get; set; }
    }

}
