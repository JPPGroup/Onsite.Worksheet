using Prism.Windows.Mvvm;

namespace Onsite.Worksheets.ViewModels
{
    public class TrlDcpReportsPageViewModel : ViewModelBase
    {
        public string DisplayText { get; }

        public TrlDcpReportsPageViewModel()
        { 
            DisplayText = "This is the Dynamic Cone Penetrometer (DCP) Reports page!";

        }
    }
}