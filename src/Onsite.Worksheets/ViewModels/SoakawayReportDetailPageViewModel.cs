using Onsite.Worksheets.UILogic.Abstracts;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Globalization;
using Windows.UI.Xaml.Navigation;

namespace Onsite.Worksheets.ViewModels
{
    public class SoakawayReportDetailPageViewModel : ViewModelBase
    {
        private readonly IAlertMessageService _alertMessageService;
        private readonly IResourceLoader _resourceLoader;

        public string DisplayText { get; private set; }

        public SoakawayReportDetailPageViewModel(IAlertMessageService alertMessageService, IResourceLoader resourceLoader)
        {
            _alertMessageService = alertMessageService;
            _resourceLoader = resourceLoader;

            DisplayText = "This is the soakaway report details page!";
        }

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            var errorMessage = string.Empty;
            try
            {
                var reportId = e.Parameter as string; //TODO: cast as guid
                DisplayText = $"Soakaway report details for {reportId}!";

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
