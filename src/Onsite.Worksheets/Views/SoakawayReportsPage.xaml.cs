using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Onsite.Worksheets.ViewModels;
using Prism.Windows.Mvvm;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
namespace Onsite.Worksheets.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SoakawayReportsPage : SessionStateAwarePage, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public SoakawayReportsPageViewModel ConcreteDataContext => DataContext as SoakawayReportsPageViewModel;

        public SoakawayReportsPage()
        {
            InitializeComponent();
            DataContextChanged += SoakawayReportsPage_DataContextChanged;
        }


        private void SoakawayReportsPage_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            var propertyChanged = PropertyChanged;
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ConcreteDataContext)));
        }
    }
}
