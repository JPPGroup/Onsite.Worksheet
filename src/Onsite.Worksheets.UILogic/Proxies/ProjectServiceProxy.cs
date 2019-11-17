using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Onsite.Worksheets.UILogic.Abstracts;
using Onsite.Worksheets.UILogic.Models;

namespace Onsite.Worksheets.UILogic.Proxies
{
    public class ProjectServiceProxy : IProjectService
    {
        public Task<ReadOnlyCollection<string>> GetSearchSuggestionsAsync(string queryText)
        {
            return Task.Run(() =>
            {
                var dummyList = new List<Project>
                {
                    new Project { Code = "1231", Name = "Project 1" },
                    new Project { Code = "1232", Name = "Project 2" },
                    new Project { Code = "1233", Name = "Project 3" },
                    new Project { Code = "1234", Name = "Project 4" },
                    new Project { Code = "1235", Name = "Project 5" }
                };

                return new ReadOnlyCollection<string>(dummyList.Where(l => 
                    l.Name.ToLower().Contains(queryText.ToLower()) ||
                    l.Code.Contains(queryText)).Select(l => l.Name).ToList());
            });

            /*
             * using (var httpClient = new HttpClient())
             * {
                var response = await httpClient.GetAsync(new Uri(string.Format("{0}?searchTerm={1}", _searchSuggestionsBaseUrl, searchTerm)));
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ReadOnlyCollection<string>>(responseContent);

                return result;
            }*/
        }
    }
}
