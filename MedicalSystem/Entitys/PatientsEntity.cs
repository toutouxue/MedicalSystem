using System;
using System.Collections.Generic;

namespace MedicalSystem.Models
{
    public partial class PatientsEntity
    {
        public PatientsEntity()
        {
            Appointments = new HashSet<AppointmentEntity>();
            PatientHistory = new HashSet<PatientHistoryEntity>();
        }

        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

        public virtual ICollection<AppointmentEntity> Appointments { get; set; }
        public virtual ICollection<PatientHistoryEntity> PatientHistory { get; set; }
    }
}
