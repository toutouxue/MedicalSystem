using System;
using System.Collections.Generic;

namespace MedicalSystem.Models
{
    public partial class HospitalEntity
    {
        public HospitalEntity()
        {
            Appointments = new HashSet<AppointmentEntity>();
        }

        public int HospitalId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual ICollection<AppointmentEntity> Appointments { get; set; }
    }
}
