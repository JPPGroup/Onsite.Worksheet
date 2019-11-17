using Prism.Windows.Mvvm;

namespace Onsite.Worksheets.ViewModels
{
    public class InspectionsPageViewModel : ViewModelBase
    {
        public InspectionsPageViewModel()
        { 
            DisplayText = "This is the Structural Inspections page!";

        }

        public string DisplayText { get; private set; }
    }
}