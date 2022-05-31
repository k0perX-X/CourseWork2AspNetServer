﻿using System.ComponentModel.DataAnnotations;

namespace CourseWork2AspNetServer.Models
{
    public class Patient
    {
        //[Key]
        [Required] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Surname { get; set; }
        public string MiddleName { get; set; }
        [Required] public DateTime Birthdate { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }
        public List<Procedure> Procedures { get; set; }
        public List<WellBeingRecord> WellBeingRecords { get; set; }
        public List<TakenMedication> TakenMedications { get; set; }
        public List<PatientsDrug> PatientsDrugs { get; set; }
        public List<DoctorsAppointment> DoctorsAppointments { get; set; }
        public List<OAuth> Tokens { get; set; }
    }

    public class OAuth
    {
        [Key] [Required] public string Token { get; set; }
        public string? OtherInformation { get; set; }
        [Required] public DateTime CreateTime { get; set; }
    }

    public class PatientsDrug
    {
        [Required] public int Id { get; set; }

        //[Key]
        [Required] public Patient Patient { get; set; }
        [Required] public int PatientId { get; set; }


        //[Key]
        [Required] public Drug Drug { get; set; }
        [Required] public int DrugId { get; set; }

        [Required] public int Remaining { get; set; }

        //[Key]
        [Required] public DateTime DateOfManufacture { get; set; }
    }

    public class Drug
    {
        //[Key]
        [Required] public int Id { get; set; }
        [Required] public string Name { get; set; }
        public string? Note { get; set; }
        [Required] public DateTime ExplorationDate { get; set; }
    }

    public class TakenMedication
    {
        [Required] public int Id { get; set; }

        //[Key]
        [Required] public Patient Patient { get; set; }
        [Required] public int PatientId { get; set; }

        //[Key]
        [Required] public Drug Drug { get; set; }
        [Required] public int DrugId { get; set; }

        //[Key]
        [Required] public DateTime DateTime { get; set; }
        [Required] public bool ReceptionTimeInTheMorning { get; set; }
        [Required] public bool ReceptionTimeDuringTheDay { get; set; }
        [Required] public bool ReceptionTimeInTheEvening { get; set; }
    }

    public class DoctorsAppointment
    {
        [Required] public int Id { get; set; }

        //[Key]
        [Required] public Patient Patient { get; set; }
        [Required] public int PatientId { get; set; }

        //[Key]
        [Required] public Doctor Doctor { get; set; }
        [Required] public int DoctorId { get; set; }
        public double? PatientTemperature { get; set; }

        public string? Note { get; set; }

        //[Key]
        [Required] public DateTime DateTime { get; set; }
        [Required] public bool Visited { get; set; }

        public List<PrescribedMedication> PrescribedMedications { get; set; }
    }

    public class Doctor
    {
        //[Key]
        [Required] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Surname { get; set; }
        public string MiddleName { get; set; }
        [Required] public DateTime Birthdate { get; set; }
        public string? Note { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }
    }

    public class PrescribedMedication
    {
        [Required] public int Id { get; set; }

        //[Key]
        [Required] public DoctorsAppointment DoctorsAppointment { get; set; }
        [Required] public int DoctorsAppointmentId { get; set; }

        //[Key]
        [Required] public Drug Drug { get; set; }
        [Required] public int DrugId { get; set; }
        [Required] public bool ReceptionTimeInTheMorning { get; set; }
        [Required] public bool ReceptionTimeDuringTheDay { get; set; }
        [Required] public bool ReceptionTimeInTheEvening { get; set; }
        [Required] public bool TakeBeforeMeals { get; set; }
        [Required] public bool TakeAfterMeals { get; set; }
        [Required] public bool TakeWithMeals { get; set; }

        public string? Note { get; set; }

        //[Key] // не нужен, но нужен при генерации чтобы изменить
        [Required] public DateTime TakeMedicineBeforeTheDate { get; set; }
    }

    public class PatientProcedure
    {
        [Required] public int Id { get; set; }

        //[Key]
        [Required] public DateTime DateTime { get; set; }

        //[Key]
        [Required] public Procedure Procedure { get; set; }
        [Required] public int ProcedureId { get; set; }

        public string? Note { get; set; }

        //[Key]
        [Required] public Patient Patient { get; set; }
        [Required] public int PatientId { get; set; }
        [Required] public bool Visited { get; set; }
    }

    public class Procedure
    {
        //[Key]
        [Required] public int Id { get; set; }
        [Required] public string Name { get; set; }
        public string? Note { get; set; }
    }

    public class WellBeingRecord
    {
        [Required] public int Id { get; set; }

        //[Key]
        [Required] public DateTime DateTime { get; set; }
        public double? Temperature { get; set; }

        public string? Note { get; set; }

        //[Key]
        [Required] public Patient Patient { get; set; }
        [Required] public int PatientId { get; set; }
    }
}