using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Onsite.Worksheets.UILogic;
using Prism.Commands;
using Prism.Events;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

namespace Onsite.Worksheets.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public MenuViewModel( INavigationService navigationService, IResourceLoader resourceLoader)
        {
            _navigationService = navigationService;

            Commands = new ObservableCollection<MenuItemViewModel>
            {
                new MenuItemViewModel { DisplayName = resourceLoader.GetString("SoakawayReportsPageMenuItemDisplayName"), FontIcon = "\ue81d", Command = new DelegateCommand(() => NavigateToPage(PageTokens.SoakawayReports)) },
                new MenuItemViewModel { DisplayName = resourceLoader.GetString("InspectionsPageMenuItemDisplayName"), FontIcon = "\ue731", Command = new DelegateCommand(() => NavigateToPage(PageTokens.Inspections)) }
            };
        }

        public ObservableCollection<MenuItemViewModel> Commands { get; set; }


        private void NavigateToPage(PageTokens pageToken)
        {
            _navigationService.Navigate(pageToken.ToString(), null);
        }
    }
}