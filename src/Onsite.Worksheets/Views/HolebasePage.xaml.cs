using System.ComponentModel;
using Windows.UI.Xaml;
using Onsite.Worksheets.ViewModels;
using Prism.Windows.Mvvm;

namespace Onsite.Worksheets.Views
{
    public sealed partial class HolebasePage : SessionStateAwarePage, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public HolebasePageViewModel ConcreteDataContext => DataContext as HolebasePageViewModel;

        public HolebasePage()
        {
            InitializeComponent();
            DataContextChanged += HolebasePage_DataContextChanged;
        }

        private void HolebasePage_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            var propertyChanged = PropertyChanged;
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ConcreteDataContext)));
        }
    }
}
