using System;
using System.Collections.Generic;

namespace MedicalSystem.Models
{
    public partial class DoctorEntity
    {
        public DoctorEntity()
        {
            Appointments = new HashSet<AppointmentEntity>();
        }

        public int DoctorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Specialty { get; set; }

        public virtual ICollection<AppointmentEntity> Appointments { get; set; }
        
    }
}
