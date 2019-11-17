using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Onsite.Worksheets.UILogic.Abstracts;
using Onsite.Worksheets.UILogic.Models;

namespace Onsite.Worksheets.UILogic.Proxies
{
    public class StructureServiceProxy : IStructureService
    {
        public Task<IEnumerable<Structure>> GetAllByProject(Guid projectId)
        {
            throw new NotImplementedException();
        }

        public Task<Structure> GetSingle(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Save(Structure entity)
        {
            throw new NotImplementedException();
        }
    }
}
