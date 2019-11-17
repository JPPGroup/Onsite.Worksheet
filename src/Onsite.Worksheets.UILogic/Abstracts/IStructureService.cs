using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Onsite.Worksheets.UILogic.Models;

namespace Onsite.Worksheets.UILogic.Abstracts
{
    //TODO: add xml comments
    public interface IStructureService
    {
        Task<IEnumerable<Structure>> GetAllByProject(Guid projectId);
        Task<Structure> GetSingle(Guid id);
        
        Task Save(Structure entity);
    }
}
