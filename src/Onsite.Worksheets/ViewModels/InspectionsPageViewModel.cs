using Prism.Windows.Mvvm;

namespace Onsite.Worksheets.ViewModels
{
    public class InspectionsPageViewModel : ViewModelBase
    {
        public string DisplayText { get; }

        public InspectionsPageViewModel()
        { 
            DisplayText = "This is the Structural Inspections page!";

        }


    }
}