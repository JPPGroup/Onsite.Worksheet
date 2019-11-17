using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Onsite.Worksheets.UILogic.Models;

namespace Onsite.Worksheets.UILogic.Abstracts
{
    //TODO: add xml comments
    public interface IInspectionService
    {
        Task<IEnumerable<Inspection>> GetAll();
        Task<IEnumerable<Inspection>> GetAllByProject(Guid projectId);
        Task<Inspection> GetSingle(Guid id);

        Task Save(Inspection entity);
    }
}
