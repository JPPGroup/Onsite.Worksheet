using System.ComponentModel;
using Windows.UI.Xaml;
using Onsite.Worksheets.ViewModels;
using Prism.Windows.Mvvm;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
namespace Onsite.Worksheets.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InspectionsPage : SessionStateAwarePage, INotifyPropertyChanged
    {
        public InspectionsPage()
        {
            InitializeComponent();
            DataContextChanged += InspectionsPage_DataContextChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public InspectionsPageViewModel ConcreteDataContext
        {
            get
            {
                return DataContext as InspectionsPageViewModel;
            }
        }

        private void InspectionsPage_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(nameof(ConcreteDataContext)));
            }
        }
    }
}
