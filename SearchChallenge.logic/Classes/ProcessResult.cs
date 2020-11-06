using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchChallenge.logic.Interfaces;
using SearchChallenge.logic.Models;

namespace SearchChallenge.logic.Classes
{
    public class ProcessResult : IProcessResult
    {
        public string GeneratePrintForWinner(Winner winner)
        {
            var printText = "Total Winner: {0}";
            return string.Format(printText, winner.Term);
        }

        public List<string> GeneratePrintResults(IList<Search> results)
        {
            var grouped = results.GroupBy(item => item.Terms);
            return grouped.Select(g => string.Join(" ", g.Key + ": ", string.Join(", ", g.Select(x => x.SearchEngine + ": " + x.Results.ToString())))).ToList();
        }

        public List<string> GeneratePrintWinnerByEngine(IEnumerable<Winner> winners)
        {
            var printText = "{0} winner: {1}";
            return winners.Select(x => string.Format(printText, x.Name, x.Term)).ToList();
        }

        public Winner GetWinner(IList<Search> results)
        {
            var maxResult = results.OrderByDescending(item => item.Results).First();
            return new Winner() {Name = maxResult.SearchEngine, Term = maxResult.Terms };
        }

        public IEnumerable<Winner> GetWinnersByEngine(IList<Search> results)
        {
            var bestResults = results
                .GroupBy(item => item.SearchEngine)
                .Select(eng => eng.OrderByDescending(val => val.Results).First())
                .ToList();

            return bestResults.Select(x => new Winner() { Name = x.SearchEngine, Term = x.Terms });
            
        }
    }
}
