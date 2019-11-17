using System.Threading.Tasks;
using Onsite.Worksheets.UILogic.Models;

namespace Onsite.Worksheets.UILogic.Abstracts
{
    //TODO: add xml comments
    public interface IInspectionRepository
    {
        Task<Inspection> GetAsync(string inspectionId);
    }
}