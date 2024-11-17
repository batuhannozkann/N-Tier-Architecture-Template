using CV.Shared.DTOs;

namespace CV.Core.DTOs.Address
{
    public class AddressDto : BaseDto
    {
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
    }
}