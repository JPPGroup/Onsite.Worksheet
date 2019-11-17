using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Onsite.Worksheets.UILogic.Abstracts;
using Onsite.Worksheets.UILogic.Models;

namespace Onsite.Worksheets.UILogic.Proxies
{
    public class InspectionServiceProxy : IInspectionService
    {
        public InspectionServiceProxy()
        {

        }

        public Task<IEnumerable<Inspection>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Inspection>> GetAllByProject(Guid projectId)
        {
            throw new NotImplementedException();
        }

        public Task<Inspection> GetSingle(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Save(Inspection entity)
        {
            throw new NotImplementedException();
        }
    }
}
