using SearchChallenge.logic.Classes;
using SearchChallenge.logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchChallenge.logic
{
    public static class SearchLogic
    {
        private static ISearchManager _searchManager;
        private static IProcessResult _procesResult;
        private static readonly List<string> printResults;

        static SearchLogic()
        {
            _searchManager = new SearchManager();
            _procesResult = new ProcessResult();
            printResults = new List<string>();
        }

        public static async Task<List<string>> SearchTerms(IList<string> terms)
        {
            var searchResult = await _searchManager.GetResults(terms);
            var winnerByEngine = _procesResult.GetWinnersByEngine(searchResult);
            var searchWinner = _procesResult.GetWinner(searchResult);

            printResults.AddRange(_procesResult.GeneratePrintResults(searchResult));
            printResults.AddRange(_procesResult.GeneratePrintWinnerByEngine(winnerByEngine));
            printResults.Add(_procesResult.GeneratePrintForWinner(searchWinner));

            return printResults;
        }
    }
}
