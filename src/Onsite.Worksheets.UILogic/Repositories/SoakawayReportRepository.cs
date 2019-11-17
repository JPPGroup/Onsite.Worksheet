using Onsite.Worksheets.UILogic.Abstracts;
using Onsite.Worksheets.UILogic.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onsite.Worksheets.UILogic.Repositories
{
    public class SoakawayReportRepository : ISoakawayReportRepository
    {
        public Task<ICollection<SoakawayReport>> GetFilteredReportsAsync(string queryText)
        {
            return Task.Run(() =>
            {
                var list = new List<SoakawayReport>
                {
                    new SoakawayReport {Project = "Project 1"},
                    new SoakawayReport {Project = "Project 2"},
                    new SoakawayReport {Project = "Project 3"},
                    new SoakawayReport {Project = "Project 4"},
                    new SoakawayReport {Project = "Project 5"},
                    new SoakawayReport {Project = "Project 6"},
                    new SoakawayReport {Project = "Project 7"},
                    new SoakawayReport {Project = "Project 8"},
                    new SoakawayReport {Project = "Project 9"},
                    new SoakawayReport {Project = "Project 10"}
                };


                ICollection<SoakawayReport> col = list.Where(r => r.Project.ToLower().Contains(queryText.ToLower())).ToList(); 

                return col;
            });
        }

        public Task<ICollection<SoakawayReport>> GetRecentReportsAsync()
        {
            return Task.Run(() =>
            {
                ICollection<SoakawayReport> list = new List<SoakawayReport>
                {
                    new SoakawayReport {Project = "Project 1"},
                    new SoakawayReport {Project = "Project 2"},
                    new SoakawayReport {Project = "Project 3"},
                    new SoakawayReport {Project = "Project 4"}
                };

                return list;
            });
        }
    }
}
