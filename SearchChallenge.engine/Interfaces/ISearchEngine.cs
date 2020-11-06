using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchChallenge.engine.Interfaces
{
    public interface ISearchEngine
    {
        string Name { get;}
        Task<long> GetTotalResults(string term);
    }
}
