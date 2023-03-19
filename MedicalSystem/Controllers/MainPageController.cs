using MedicalSystem.Models;

namespace MedicalSystem.Controllers
{
    
    public class MainPageController
    {
        private readonly MainPageViewModel _mainPageModelView;
        public MainPageController(MainPageViewModel mainPageModelView)
        {
            _mainPageModelView = mainPageModelView;
        }
    }
}
