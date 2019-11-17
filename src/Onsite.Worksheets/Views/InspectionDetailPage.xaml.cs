﻿using System.ComponentModel;
using Windows.UI.Xaml;
using Onsite.Worksheets.ViewModels;
using Prism.Windows.Mvvm;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
namespace Onsite.Worksheets.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InspectionDetailPage : SessionStateAwarePage, INotifyPropertyChanged
    {
        public InspectionDetailPage()
        {
            InitializeComponent();
            DataContextChanged += InspectionDetailPage_DataContextChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public InspectionDetailPageViewModel ConcreteDataContext
        {
            get
            {
                return DataContext as InspectionDetailPageViewModel;
            }
        }

        private void InspectionDetailPage_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(nameof(ConcreteDataContext)));
            }
        }
    }
}
