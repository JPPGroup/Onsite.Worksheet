using Onsite.Worksheets.UILogic.Abstracts;
using Onsite.Worksheets.UILogic.Models;
using Onsite.Worksheets.UILogic.ViewModels;
using Prism.Commands;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Onsite.Worksheets.ViewModels
{
    public class SoakawayReportsPageViewModel : ViewModelBase
    {
        private const uint MAX_NUMBER_OF_SUGGESTIONS = 5;
        
        private readonly IProjectService _projectService;
        private readonly ISoakawayReportRepository _soakawayReportRepository;
        private readonly IResourceLoader _resourceLoader;
        private readonly IAlertMessageService _alertMessageService;

        private ReadOnlyCollection<SoakawayReportViewModel> _results;
        private string _searchTerm;
        private string _queryString;
        private bool _noResults;

        public DelegateCommand<SearchBoxQuerySubmittedEventArgs> SearchCommand { get; set; }
        public DelegateCommand<SearchBoxSuggestionsRequestedEventArgs> SearchSuggestionsCommand { get; set; }
        public string DisplayText { get; }
        public ReadOnlyCollection<SoakawayReportViewModel> Results
        {
            get => _results;
            private set => SetProperty(ref _results, value);
        }
        [RestorableState]
        public static ICollection<SoakawayReport> Reports { get; private set; }
        [RestorableState]
        public string SearchTerm
        {
            get => _searchTerm;
            private set => SetProperty(ref _searchTerm, value);
        }
        public bool NoResults
        {
            get => _noResults;
            private set => SetProperty(ref _noResults, value);
        }
        public string QueryText
        {
            get => _queryString;
            private set => SetProperty(ref _queryString, value);
        }

        public SoakawayReportsPageViewModel(IProjectService projectService, ISoakawayReportRepository soakawayReportRepository, IResourceLoader resourceLoader, IAlertMessageService alertMessageService)
        {
            _projectService = projectService;
            _soakawayReportRepository = soakawayReportRepository;
            _resourceLoader = resourceLoader;
            _alertMessageService = alertMessageService;

            DisplayText = "This is the Soakaway Reports page!";

            SearchCommand = new DelegateCommand<SearchBoxQuerySubmittedEventArgs>(SearchBoxQuerySubmitted);
            SearchSuggestionsCommand = new DelegateCommand<SearchBoxSuggestionsRequestedEventArgs>(async eventArgs =>
            {
                await SearchBoxSuggestionsRequested(eventArgs);
            });
        }

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            await PopulateReportList(SearchTerm);
        }

        private async void SearchBoxQuerySubmitted(SearchBoxQuerySubmittedEventArgs eventArgs)
        {
            var searchTerm = eventArgs.QueryText.Trim();
            await PopulateReportList(searchTerm);
        }

        private async Task SearchBoxSuggestionsRequested(SearchBoxSuggestionsRequestedEventArgs args)
        {
            var queryText = args.QueryText.Trim();
            if (string.IsNullOrEmpty(queryText)) return;

            var deferral = args.Request.GetDeferral();

            try
            {
                var suggestionCollection = args.Request.SearchSuggestionCollection;

                var querySuggestions = await _projectService.GetSearchSuggestionsAsync(queryText);
                if (querySuggestions != null && querySuggestions.Count > 0)
                {
                    var querySuggestionCount = 0;
                    foreach (var suggestion in querySuggestions)
                    {
                        querySuggestionCount++;
                        suggestionCollection.AppendQuerySuggestion(suggestion);

                        if (querySuggestionCount >= MAX_NUMBER_OF_SUGGESTIONS) break;
                    }
                }
            }
            catch (Exception) { } // Ignore any exceptions that occur trying to find search suggestions.

            deferral.Complete();
        }

        private async Task PopulateReportList(string queryText)
        {
            var errorMessage = string.Empty;

            try
            {
                ICollection<SoakawayReport> results;
                if (!string.IsNullOrEmpty(queryText))
                {
                    if (queryText == SearchTerm)
                    {
                        results = Reports;
                    }
                    else
                    {
                        results = await _soakawayReportRepository.GetFilteredReportsAsync(queryText);
                    }
                    
                    SearchTerm = queryText;
                    QueryText = $"{results.Count} results for \u201c{queryText}\u201d"; //TODO: move to resources
                }
                else
                {
                    results = await _soakawayReportRepository.GetRecentReportsAsync();
                    SearchTerm = string.Empty;
                    QueryText = "Recent Reports"; //TODO: move to resources
                }

                var reportViewModels = results.Select(report => new SoakawayReportViewModel(report)).ToList();
                Reports = results;
                Results = new ReadOnlyCollection<SoakawayReportViewModel>(reportViewModels);
                NoResults = !Results.Any();
            }
            catch (Exception ex)
            {
                errorMessage = string.Format(CultureInfo.CurrentCulture, _resourceLoader.GetString("GeneralServiceErrorMessage"), Environment.NewLine, ex.Message);
            }

            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                await _alertMessageService.ShowAsync(errorMessage, _resourceLoader.GetString("ErrorServiceUnreachable"));
            }
        }
    }
}