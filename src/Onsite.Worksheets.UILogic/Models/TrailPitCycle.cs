using System.Collections.Generic;

namespace Onsite.Worksheets.UILogic.Models
{
    public class TrailPitCycle
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }

        public IEnumerable<TrailPitCycleEntry> Entries { get; set; }
    }
}
