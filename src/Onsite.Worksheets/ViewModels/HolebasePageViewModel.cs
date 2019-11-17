using Prism.Windows.Mvvm;

namespace Onsite.Worksheets.ViewModels
{
    public class HolebasePageViewModel : ViewModelBase
    {
        public string DisplayText { get; }

        public HolebasePageViewModel()
        { 
            DisplayText = "This is the Holebase page!";

        }
    }
}