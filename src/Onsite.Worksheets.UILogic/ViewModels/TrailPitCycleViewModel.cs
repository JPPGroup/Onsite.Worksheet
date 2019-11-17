using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Onsite.Worksheets.UILogic.Models;

namespace Onsite.Worksheets.UILogic.ViewModels
{
    public class TrailPitCycleViewModel
    {
        private readonly TrailPitCycle _cycle;

        public IReadOnlyCollection<TrailPitCycleEntryViewModel> Entries { get; private set; }

        public TrailPitCycleViewModel(TrailPitCycle cycle)
        {
            _cycle = cycle ?? throw new ArgumentNullException(nameof(cycle));

            //CategoryNavigationCommand = new DelegateCommand(NavigateToCategory);

            if (_cycle.Entries != null)
            {
                Entries = new ReadOnlyCollection<TrailPitCycleEntryViewModel>(_cycle.Entries.Select(p => new TrailPitCycleEntryViewModel(p)).ToList());
            }
        }
    }
}