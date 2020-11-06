using SearchChallenge.logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchChallenge.logic.Interfaces
{
    interface ISearchManager
    {
        Task<IList<Search>> GetResults(IList<string> terms);
    }
}
