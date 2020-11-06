using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchChallenge.logic.Models;

namespace SearchChallenge.logic.Interfaces
{
    interface IProcessResult
    {
        IEnumerable<Winner> GetWinnersByEngine(IList<Search> results);
        Winner GetWinner(IList<Search> results);
        List<string> GeneratePrintResults(IList<Search> results);
        List<string> GeneratePrintWinnerByEngine(IEnumerable<Winner> winners);
        string GeneratePrintForWinner(Winner winner);


    }
}
