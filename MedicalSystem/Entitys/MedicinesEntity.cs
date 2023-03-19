using System;
using System.Collections.Generic;

namespace MedicalSystem.Models
{
    public partial class MedicinesEntity
    {
        public MedicinesEntity()
        {
            Prescriptions = new HashSet<PrescriptionsEntity>();
        }

        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<PrescriptionsEntity> Prescriptions { get; set; }
    }
}
