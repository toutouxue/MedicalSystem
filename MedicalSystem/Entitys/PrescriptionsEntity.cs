using System;
using System.Collections.Generic;

namespace MedicalSystem.Models
{
    public partial class PrescriptionsEntity
    {
        public int PrescriptionId { get; set; }
        public int AppointmentId { get; set; }
        public int MedicineId { get; set; }
        public string Dosage { get; set; }

        public virtual AppointmentEntity Appointment { get; set; }
        public virtual MedicinesEntity Medicine { get; set; }
    }
}
