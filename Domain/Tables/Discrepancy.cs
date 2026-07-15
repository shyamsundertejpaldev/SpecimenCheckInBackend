using Domain.Enums;

namespace Domain.Tables
{
    public class Discrepancy
    {
        public int Id { get; set; }
        public int ManifestId { get; set; }
        public int? SpecimenId { get; set; }
        public DiscrepancyType Type { get; set; }   // Missing / OffManifest
        public DiscrepancyStatus Status { get; set; } // Open / Resolved

        // Navigation
        public Manifest Manifest { get; set; }
        public Specimen Specimen { get; set; }
    }
}
