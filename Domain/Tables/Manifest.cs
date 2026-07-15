using Domain.Enums;

namespace Domain.Tables
{
    public class Manifest
    {
        public int Id { get; set; }
        public int LabId { get; set; }
        public string Code { get; set; }
        public DateTime SentAt { get; set; }
        public ManifestStatus Status { get; set; } // Open / Closed / ClosedWithDiscrepancy

        // Navigation
        public Lab Lab { get; set; }
        public ICollection<Specimen> Specimens { get; set; }
        public ICollection<Discrepancy> Discrepancies { get; set; }
    }
}
