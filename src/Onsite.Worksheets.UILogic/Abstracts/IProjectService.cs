using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Onsite.Worksheets.UILogic.Abstracts
{
    //TODO: add xml comments
    public interface IProjectService
    {
        Task<ReadOnlyCollection<string>> GetSearchSuggestionsAsync(string queryText);
    }
}
