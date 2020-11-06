using SearchChallenge.engine.Interfaces;
using SearchChallenge.logic.Interfaces;
using SearchChallenge.logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchChallenge.logic.Classes
{
    public class SearchManager : ISearchManager
    {
        private IList<ISearchEngine> _enginesList;

        public SearchManager()
        {
            _enginesList = GetEnginesList();
        }

        private static IList<ISearchEngine> GetEnginesList()
        {

            var instances = AppDomain.CurrentDomain.GetAssemblies()
                            .SelectMany(assembly => assembly.GetTypes())
                            .Where(type => type.GetInterface(typeof(ISearchEngine).ToString()) != null)
                            .Select(type => Activator.CreateInstance(type) as ISearchEngine).ToList();
            return instances;
        }

        public async Task<IList<Search>> GetResults(IList<string> terms)
        {
            if ((terms == null) || (!terms.Any()))
            {
                throw new Exception("There are no terms indicated for the search.");
            }

            IList<Search> results = new List<Search>();

            foreach (var engine in _enginesList)
            {
                foreach (var searchterm in terms)
                {
                    results.Add(new Search { SearchEngine = engine.Name, Terms = searchterm, Results = await engine.GetTotalResults(searchterm) });
                }

            }

            return results;
        }
    }
}
