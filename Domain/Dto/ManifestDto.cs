using Domain.Enums;

namespace Domain.Dto
{
    public class ManifestDto
    {
        public int ManifestId { get; set; }
        public int LabId { get; set; }
        public string Code { get; set; } = string.Empty;
        public DateTime SentAt { get; set; }
        public ManifestStatus Status { get; set; }
    }
}
