using System;
using System.Collections.Generic;

namespace Onsite.Worksheets.UILogic.Models
{
    public class SoakawayReport
    {
        public Guid Id { get; set; }
        public string Project { get; set; }
        public IEnumerable<TrailPit> TrailPits { get; set; }

        public SoakawayReport()
        {
            Id = Guid.NewGuid();
        }
    }
}
