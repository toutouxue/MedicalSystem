using System;
using System.Collections.Generic;

namespace MedicalSystem.Models
{
    public partial class AppointmentEntity
    {
        public AppointmentEntity()
        {
            Prescriptions = new HashSet<PrescriptionsEntity>();
        }

        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int HospitalId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string AppointmentType { get; set; }
        public string ReasonForVisit { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }

        public virtual DoctorEntity Doctor { get; set; }
        public virtual HospitalEntity Hospital { get; set; }
        public virtual PatientsEntity Patient { get; set; }
        public virtual ICollection<PrescriptionsEntity> Prescriptions { get; set; }
    }
}
