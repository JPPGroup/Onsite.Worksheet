using Onsite.Worksheets.UILogic.Models;
using System;

namespace Onsite.Worksheets.UILogic.ViewModels
{
    public class TrailPitCycleEntryViewModel
    {
        private readonly TrailPitCycleEntry _entry;

        public TrailPitCycleEntryViewModel(TrailPitCycleEntry entry)
        {
            _entry = entry ?? throw new ArgumentNullException(nameof(entry));

            //CategoryNavigationCommand = new DelegateCommand(NavigateToCategory);
        }
    }
}