using Domain.Enums;

namespace Domain.Tables
{
    public class Specimen
    {
        public int Id { get; set; }
        public int ManifestId { get; set; }
        public string Code { get; set; }
        public string Patient { get; set; }
        public string Provider { get; set; }
        public SpecimenStatus Status { get; set; } // Pending / Received / Flagged
        public DateTime ReceivedAt { get; set; } = DateTime.Now;

        // Navigation
        public Manifest Manifest { get; set; }
        public ICollection<Discrepancy> Discrepancies { get; set; }
    }
}
