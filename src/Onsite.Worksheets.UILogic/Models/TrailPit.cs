using System.Collections.Generic;

namespace Onsite.Worksheets.UILogic.Models
{
    public class TrailPit
    {
        public string Name { get; set; }
        public IEnumerable<TrailPitCycle> Cycles { get; set; }
    }
}
