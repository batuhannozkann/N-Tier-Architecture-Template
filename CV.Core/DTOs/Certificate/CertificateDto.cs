using CV.Shared.DTOs;

namespace CV.Core.DTOs.Certificate
{
    public class CertificateDto : BaseDto
    {
        public string Name { get; set; }
        public string? IssuingOrganization { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? CredentialID { get; set; }
        public string? CredentialURL { get; set; }
    }
}