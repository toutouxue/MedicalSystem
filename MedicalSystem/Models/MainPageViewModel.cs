using Microsoft.AspNetCore.Mvc;

namespace MedicalSystem.Models
{
    public class MainPageViewModel
    {
        private readonly IUserBase _user; 
        private MainPageViewModel mainPageViewModel { get; set; }

        readonly MedicalSystemContext context =new();
        public MainPageViewModel(IUserBase user)
        {
            _user = user;
        }

        public ActionResult GetMainTittleload()
        {

        }
        public string MainTittleload()
        {
            if (_user.UserType==UserTypeEnum.Doctor)
            {
                return "Welcome Back Doctor " + _user.FirstName; 
            }
            return "Welcome Back Nurse " + _user.FirstName;
        }
        public MainPageWorkPlanDTO MainPageWorkPlan()
        {
            MainPageWorkPlanDTO DoctorWorkPlanDTO = new();
            DoctorWorkPlanDTO.PatientsTotal = context.Doctors.Where(d => d.DoctorId == _user.UserID).SelectMany(d => d.Appointments).Count(t => t.AppointmentDate == DateTime.Now);
            return DoctorWorkPlanDTO;
        }
    }

    public class MainPageWorkPlanDTO
    {
        public DateTime Date { set => value = DateTime.Now; }
        public int PatientsTotal { get; set; }
        public int Patiened {  set => value = 0; }
        public int RemainPatien { set => value = 0; }
    }

}
