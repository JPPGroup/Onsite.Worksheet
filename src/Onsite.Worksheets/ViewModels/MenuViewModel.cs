using Onsite.Worksheets.UILogic;
using Prism.Commands;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System.Collections.ObjectModel;

namespace Onsite.Worksheets.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        
        public ObservableCollection<MenuItemViewModel> Commands { get; set; }

        public MenuViewModel( INavigationService navigationService, IResourceLoader resourceLoader)
        {
            _navigationService = navigationService;

            Commands = new ObservableCollection<MenuItemViewModel>
            {
                new MenuItemViewModel { DisplayName = resourceLoader.GetString("SoakawayReportsPageMenuItemDisplayName"), FontIcon = "\ue81d", Command = new DelegateCommand(() => NavigateToPage(PageTokens.SoakawayReports)) },
                new MenuItemViewModel { DisplayName = resourceLoader.GetString("InspectionsPageMenuItemDisplayName"), FontIcon = "\ue731", Command = new DelegateCommand(() => NavigateToPage(PageTokens.Inspections)) },
                new MenuItemViewModel { DisplayName = resourceLoader.GetString("TrlDcpReportsPageMenuItemDisplayName"), FontIcon = "\ue76d", Command = new DelegateCommand(() => NavigateToPage(PageTokens.TrlDcpReports)) },
                new MenuItemViewModel { DisplayName = resourceLoader.GetString("HolebasePageMenuItemDisplayName"), FontIcon = "\ue7B7", Command = new DelegateCommand(() => NavigateToPage(PageTokens.Holebase)) }
            };
        }

        private void NavigateToPage(PageTokens pageToken)
        {
            _navigationService.Navigate(pageToken.ToString(), null);
        }
    }
}