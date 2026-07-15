namespace Domain.Tables
{
    public class Lab
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation
        public ICollection<Manifest> Manifests { get; set; }
    }
}
