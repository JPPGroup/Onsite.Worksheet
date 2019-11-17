using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Onsite.Worksheets.UILogic.Models;
using Prism.Commands;
using Prism.Windows.Navigation;

namespace Onsite.Worksheets.UILogic.ViewModels
{
    public class SoakawayReportViewModel
    {
        private readonly SoakawayReport _report;
        private readonly INavigationService _navigationService;

        private TrailPitViewModel _selectedPit;

        public ICommand SoakawayReportNavigationCommand { get; private set; }
        public IReadOnlyCollection<TrailPitViewModel> TrailPits { get; private set; }
        public string ReportId => _report.Id.ToString();

        public SoakawayReportViewModel(SoakawayReport report) : this(report, null) { }
        public SoakawayReportViewModel(SoakawayReport report, INavigationService navigationService)
        {
            _report = report ?? throw new ArgumentNullException(nameof(report));
            _navigationService = navigationService;

            SoakawayReportNavigationCommand = new DelegateCommand(NavigateToReport);

            if (_report.TrailPits != null)
            {
                TrailPits = new ReadOnlyCollection<TrailPitViewModel>(_report.TrailPits.Select(p => new TrailPitViewModel(p)).ToList());
            }
        }

        private void NavigateToReport()
        {
            _navigationService.Navigate(PageTokens.SoakawayReportDetails.ToString(), _report.Id);
        }
    }
}
