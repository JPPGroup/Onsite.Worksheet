using Onsite.Worksheets.UILogic.Abstracts;
using Onsite.Worksheets.UILogic.ViewModels;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Globalization;
using Windows.UI.Xaml.Navigation;

namespace Onsite.Worksheets.ViewModels
{
    public class InspectionDetailPageViewModel : ViewModelBase
    {
        private readonly IAlertMessageService _alertMessageService;
        private readonly IResourceLoader _resourceLoader;
        private readonly IInspectionRepository _inspectionRepository;
        private InspectionViewModel _selectedInspection;

        public string DisplayText { get; }
        public InspectionViewModel SelectedInspection
        {
            get => _selectedInspection;
            set => SetProperty(ref _selectedInspection, value);
        }

        public InspectionDetailPageViewModel(IInspectionRepository inspectionRepository, IAlertMessageService alertMessageService, IResourceLoader resourceLoader)
        {
            _inspectionRepository = inspectionRepository;
            _alertMessageService = alertMessageService;
            _resourceLoader = resourceLoader;

            DisplayText = "This is the inspection detail page!";
        }

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            var errorMessage = string.Empty;
            try
            {
                var inspectionId = e.Parameter as string; //TODO: cast as guid
                var selectedInspection = await _inspectionRepository.GetAsync(inspectionId);
                SelectedInspection = new InspectionViewModel(selectedInspection, _inspectionRepository, _alertMessageService, _resourceLoader);
            }
            catch (Exception ex)
            {
                errorMessage = string.Format(CultureInfo.CurrentCulture, _resourceLoader.GetString("GeneralServiceErrorMessage"), Environment.NewLine, ex.Message);
            }

            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                await _alertMessageService.ShowAsync(errorMessage, _resourceLoader.GetString("ErrorServiceUnreachable"));
            }

            if (e.NavigationMode != NavigationMode.New)
            {
                base.OnNavigatedTo(e, viewModelState);
            }
        }
    }
}
