using Domain.Enums;

namespace Domain.Dto
{
    public class SpecimenDto
    {
        public int SpecimenId { get; set; }
        public int ManifestId { get; set; }
        public string Code { get; set; }
        public string Patient { get; set; }
        public string Provider { get; set; }
        public SpecimenStatus Status { get; set; }
        public DateTime ReceivedAt { get; set; } = DateTime.Now;
        public string LabName { get; set; }
        public int LabId { get; set; }
    }
}
