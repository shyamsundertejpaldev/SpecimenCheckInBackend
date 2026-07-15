namespace Domain.Enums
{
    public enum ManifestStatus
    {
        Open = 1,
        Closed,
        ClosedWithDiscrepancy
    }

    // Specimen check-in states
    public enum SpecimenStatus
    {
        Pending = 1,
        Received,
        Flagged
    }

    // Types of discrepancies
    public enum DiscrepancyType
    {
        Missing = 1,
        OffManifest
    }

    // Discrepancy resolution states
    public enum DiscrepancyStatus
    {
        Open = 1,
        Resolved
    }

    // Optional: Lab classification
    public enum LabType
    {
        CentralLab = 1,
        SatelliteLab
    }

    // Optional: User roles for future expansion
    public enum UserRole
    {
        LabTech = 1,
        Supervisor,
        Admin
    }

}
