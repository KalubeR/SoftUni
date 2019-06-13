using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<PatientMedicament> PatientMedicaments { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPatient(modelBuilder);

            OnModelCreatingVisitation(modelBuilder);

            OnModelCreatingDiagnose(modelBuilder);

            OnModelCreatingMedicament(modelBuilder);

            OnModelCreatingPatientMedicaments(modelBuilder);

            OnModelCreatingDoctor(modelBuilder);
        }

        private void OnModelCreatingDoctor(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Doctor>()
                .HasKey(p => p.DoctorId);

            modelBuilder
                .Entity<Doctor>()
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsUnicode();

            modelBuilder
                .Entity<Doctor>()
                .Property(p => p.Specialty)
                .HasMaxLength(100)
                .IsUnicode();

            modelBuilder
                .Entity<Doctor>()
                .HasMany(p => p.Visitations)
                .WithOne(p => p.Doctor);
        }

        private void OnModelCreatingPatientMedicaments(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<PatientMedicament>()
                .HasKey(k => new {k.PatientId, k.MedicamentId});

            modelBuilder
                .Entity<PatientMedicament>()
                .HasOne(pm => pm.Patient)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(pm => pm.PatientId);

            modelBuilder
                .Entity<PatientMedicament>()
                .HasOne(pm => pm.Medicament)
                .WithMany(m => m.Prescriptions)
                .HasForeignKey(m => m.MedicamentId);
        }

        private void OnModelCreatingMedicament(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicament>()
                .HasKey(k => k.MedicamentId);

            modelBuilder.Entity<Medicament>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode();
        }

        private void OnModelCreatingDiagnose(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diagnose>()
                .HasKey(p => p.DiagnoseId);

            modelBuilder.Entity<Diagnose>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode();

            modelBuilder.Entity<Diagnose>()
                .Property(p => p.Comments)
                .HasMaxLength(250)
                .IsUnicode();

            modelBuilder.Entity<Diagnose>()
                .HasOne(p => p.Patient)
                .WithMany(d => d.Diagnoses);
        }

        private void OnModelCreatingVisitation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visitation>()
                .HasKey(e => e.VisitationId);

            modelBuilder.Entity<Visitation>()
                .Property(e => e.Comments)
                .HasMaxLength(250)
                .IsUnicode();

            modelBuilder.Entity<Visitation>()
                .HasOne(p => p.Patient)
                .WithMany(v => v.Visitations);
        }

        private void OnModelCreatingPatient(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasKey(e => e.PatientId);

            modelBuilder.Entity<Patient>()
                .Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            modelBuilder.Entity<Patient>()
                .Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode();

            modelBuilder.Entity<Patient>()
                .Property(e => e.Address)
                .HasMaxLength(250)
                .IsUnicode();

            modelBuilder.Entity<Patient>()
                .Property(e => e.Email)
                .HasMaxLength(80);
        }
    }
}