using CV.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Core.DTOs.Certificate
{
    public class CreateCertificateDto
    {
        public string Name { get; set; }
        public string? IssuingOrganization { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? CredentialID { get; set; }
        public string? CredentialURL { get; set; }
        public int PersonId { get; set; }
    }
}
