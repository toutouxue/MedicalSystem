using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MedicalSystem.Models
{
    public partial class MedicalSystemContext : DbContext
    {
        private readonly IConfiguration _config;
        public MedicalSystemContext()
        {
            

        }

        public MedicalSystemContext(DbContextOptions<MedicalSystemContext> options)
            : base(options)
        {
           
        }

        public virtual DbSet<AppointmentEntity> Appointments { get; set; }
        public virtual DbSet<DoctorEntity> Doctors { get; set; }
        public virtual DbSet<HospitalEntity> Hospitals { get; set; }
        public virtual DbSet<MedicinesEntity> Medicines { get; set; }
        public virtual DbSet<PatientHistoryEntity> PatientHistory { get; set; }
        public virtual DbSet<PatientsEntity> Patients { get; set; }
        public virtual DbSet<PrescriptionsEntity> Prescriptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_config.GetValue<string>("MssqlConnectionString"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentEntity>(entity =>
            {
                entity.HasKey(e => e.AppointmentId)
                    .HasName("PK__Appointm__8ECDFCA2869FA76A");

                entity.Property(e => e.AppointmentId).HasColumnName("AppointmentID");

                entity.Property(e => e.AppointmentDate).HasColumnType("datetime");

                entity.Property(e => e.AppointmentType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Diagnosis)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.HospitalId).HasColumnName("HospitalID");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.Prescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ReasonForVisit)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Doctor");

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.HospitalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hospital");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Patient");
            });

            modelBuilder.Entity<DoctorEntity>(entity =>
            {
                entity.HasKey(e => e.DoctorId)
                    .HasName("PK__Doctors__2DC00EDF3E90FD1E");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Specialty)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HospitalEntity>(entity =>
            {
                entity.HasKey(e => e.HospitalId)
                    .HasName("PK__Hospital__38C2E58F774E0E70");

                entity.Property(e => e.HospitalId).HasColumnName("HospitalID");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MedicinesEntity>(entity =>
            {
                entity.HasKey(e => e.MedicineId)
                    .HasName("PK__Medicine__4F2128F063A25E92");

                entity.Property(e => e.MedicineId).HasColumnName("MedicineID");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Manufacturer)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MedicineName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<PatientHistoryEntity>(entity =>
            {
                entity.Property(e => e.DiagnosisDate).HasColumnType("date");

                entity.Property(e => e.MedicalCondition)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MedicationDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MedicationEndDate).HasColumnType("date");

                entity.Property(e => e.MedicationStartDate).HasColumnType("date");

                entity.Property(e => e.TreatmentDate).HasColumnType("date");

                entity.Property(e => e.TreatmentDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientHistory)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_PatientHistory_Patient");
            });

            modelBuilder.Entity<PatientsEntity>(entity =>
            {
                entity.HasKey(e => e.PatientId)
                    .HasName("PK__Patient__970EC3660D727EFF");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PrescriptionsEntity>(entity =>
            {
                entity.HasKey(e => e.PrescriptionId)
                    .HasName("PK__Prescrip__401308128A5B5096");

                entity.Property(e => e.PrescriptionId).HasColumnName("PrescriptionID");

                entity.Property(e => e.AppointmentId).HasColumnName("AppointmentID");

                entity.Property(e => e.Dosage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MedicineId).HasColumnName("MedicineID");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.AppointmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appointment");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.MedicineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medicine");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
