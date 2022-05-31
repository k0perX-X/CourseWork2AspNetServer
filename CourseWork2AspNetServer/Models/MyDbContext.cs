using Microsoft.EntityFrameworkCore;

namespace CourseWork2AspNetServer.Models
{
    public class MyDbContext : DbContext
    {
        DbSet<Patient> Patients { get; set; }
        DbSet<PatientsDrug> PatientsDrugs { get; set; }
        DbSet<Drug> Drugs { get; set; }
        DbSet<TakenMedication> TakenMedications { get; set; }
        DbSet<DoctorsAppointment> DoctorsAppointments { get; set; }
        DbSet<Doctor> Doctors { get; set; }
        DbSet<PrescribedMedication> PrescribedMedications { get; set; }
        DbSet<PatientProcedure> PatientProcedures { get; set; }
        DbSet<Procedure> Procedures { get; set; }
        DbSet<WellBeingRecord> WellBeingRecords { get; set; }
        DbSet<OAuth> OAuths { get; set; }

        //public string DbPath { get; }
        public MyDbContext()
        {
            //var folder = Environment.SpecialFolder.LocalApplicationData;
            //var path = Environment.GetFolderPath(folder);
            //DbPath = System.IO.Path.Join(path, "test.db");
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientsDrug>().HasKey(c =>
                new { c.PatientId, c.DrugId, c.DateOfManufacture });
            modelBuilder.Entity<TakenMedication>().HasKey(c =>
                new { c.PatientId, c.DrugId, c.DateTime });
            modelBuilder.Entity<DoctorsAppointment>().HasKey(c =>
                new { c.PatientId, c.DoctorId, c.DateTime });
            modelBuilder.Entity<PrescribedMedication>().HasKey(c =>
                new { c.DoctorsAppointmentId, c.DrugId });
            modelBuilder.Entity<PatientProcedure>().HasKey(c =>
                new { c.PatientId, c.ProcedureId, c.DateTime });
            modelBuilder.Entity<WellBeingRecord>().HasKey(c =>
                new { c.PatientId, c.DateTime });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestDB;Trusted_Connection=True;");
            //optionsBuilder.UseSqlite($"Data Source={DbPath}");
            optionsBuilder.UseNpgsql(ConnectionStringClass.ConnectionString);
        }
    }
}
