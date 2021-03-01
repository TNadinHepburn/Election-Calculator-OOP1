using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Voting_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int TotalSeats = 5;
            var inputDataFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assessment1InputData.txt");
            var votesFile = File.ReadAllText(inputDataFilePath);
            Console.WriteLine(votesFile);
            Console.ReadKey();
        }
    }
}
