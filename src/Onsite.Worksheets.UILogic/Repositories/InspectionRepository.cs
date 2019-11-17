using Onsite.Worksheets.UILogic.Abstracts;
using Onsite.Worksheets.UILogic.Models;
using System;
using System.Threading.Tasks;

namespace Onsite.Worksheets.UILogic.Repositories
{
    public class InspectionRepository : IInspectionRepository
    {
        public Task<Inspection> GetAsync(string inspectionId)
        {
            throw new NotImplementedException();
        }
    }
}
