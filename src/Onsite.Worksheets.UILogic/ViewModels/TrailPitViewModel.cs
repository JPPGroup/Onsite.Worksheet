using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Onsite.Worksheets.UILogic.Models;

namespace Onsite.Worksheets.UILogic.ViewModels
{
    public class TrailPitViewModel
    {
        private readonly TrailPit _trailPit;

        public IReadOnlyCollection<TrailPitCycleViewModel> Cycles { get; private set; }

        public TrailPitViewModel(TrailPit trailPit)
        {
            _trailPit = trailPit ?? throw new ArgumentNullException(nameof(trailPit));

            //CategoryNavigationCommand = new DelegateCommand(NavigateToCategory);

            if (_trailPit.Cycles != null)
            {
                Cycles = new ReadOnlyCollection<TrailPitCycleViewModel>(_trailPit.Cycles.Select(p => new TrailPitCycleViewModel(p)).ToList());
            }
        }
    }
}