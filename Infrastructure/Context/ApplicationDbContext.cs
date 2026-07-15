using Domain.Tables;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Lab> Labs { get; set; }
        public DbSet<Manifest> Manifests { get; set; }
        public DbSet<Specimen> Specimens { get; set; }
        public DbSet<Discrepancy> Discrepancies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Lab
            modelBuilder.Entity<Lab>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Lab>()
                .HasMany(l => l.Manifests)
                .WithOne(m => m.Lab)
                .HasForeignKey(m => m.LabId);

            // Manifest
            modelBuilder.Entity<Manifest>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Manifest>()
                .HasMany(m => m.Specimens)
                .WithOne(s => s.Manifest)
                .HasForeignKey(s => s.ManifestId);

            modelBuilder.Entity<Manifest>()
                .HasMany(m => m.Discrepancies)
                .WithOne(d => d.Manifest)
                .HasForeignKey(d => d.ManifestId);

            // Specimen
            modelBuilder.Entity<Specimen>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Specimen>()
                .HasMany(s => s.Discrepancies)
                .WithOne(d => d.Specimen)
                .HasForeignKey(d => d.SpecimenId);

            // Discrepancy
            modelBuilder.Entity<Discrepancy>()
                .HasKey(d => d.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
