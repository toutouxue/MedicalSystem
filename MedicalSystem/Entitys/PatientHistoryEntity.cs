using System;
using System.Collections.Generic;

namespace MedicalSystem.Models
{
    public partial class PatientHistoryEntity
    {
        public int PatientHistoryId { get; set; }
        public int PatientId { get; set; }
        public string MedicalCondition { get; set; }
        public DateTime DiagnosisDate { get; set; }
        public string TreatmentDescription { get; set; }
        public DateTime? TreatmentDate { get; set; }
        public string MedicationDescription { get; set; }
        public DateTime? MedicationStartDate { get; set; }
        public DateTime? MedicationEndDate { get; set; }

        public virtual PatientsEntity Patient { get; set; }
    }
}
