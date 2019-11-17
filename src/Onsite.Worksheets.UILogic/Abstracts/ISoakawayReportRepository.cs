using System.Collections.Generic;
using System.Threading.Tasks;
using Onsite.Worksheets.UILogic.Models;

namespace Onsite.Worksheets.UILogic.Abstracts
{
    //TODO: add xml comments
    public interface ISoakawayReportRepository
    {
        Task<ICollection<SoakawayReport>> GetFilteredReportsAsync(string queryText);
        Task<ICollection<SoakawayReport>> GetRecentReportsAsync();
    }
}
