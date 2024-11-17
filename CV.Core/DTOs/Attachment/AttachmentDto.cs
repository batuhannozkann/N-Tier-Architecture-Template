using CV.Shared.DTOs;

namespace CV.Core.DTOs.Attachment
{
    public class AttachmentDto : BaseDto
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public byte[] FileData { get; set; }
    }
}