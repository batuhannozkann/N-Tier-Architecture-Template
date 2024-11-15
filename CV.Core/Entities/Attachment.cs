using CV.Shared.Entities.Concrete;

namespace CV.Core.Entities
{
    public class Attachment : BaseEntity
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public byte[] FileData { get; set; }
    }

}
