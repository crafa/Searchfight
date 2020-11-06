using System;
using System.Linq;
using System.Threading.Tasks;
using SearchChallenge.logic;

namespace SearchChallenge.app
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("There are no terms specified for the search, please enter this information.");
                return;
            }

            Console.WriteLine("Searching....");
            ExecuteSearch(args).GetAwaiter().GetResult();
        }

        private static async Task ExecuteSearch(string[] args)
        {
            var resultsToPrint = await SearchLogic.SearchTerms(args.ToList());
            string lines = string.Join(Environment.NewLine, resultsToPrint);
            Console.Write(lines);
            Console.WriteLine();
            Console.WriteLine("Done");
        }

    }
}
