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
            string[] votesFile = File.ReadAllLines(inputDataFilePath);
            string votesLocation = votesFile[0];
            int votesTotal = int.Parse(votesFile[1]);
            var votesParties = new string[votesFile.Count() - 2];
            Array.Copy(votesFile, 2,votesParties,0,votesParties.Count());

            ElectionData VotingData = new ElectionData(votesLocation,votesTotal,votesParties);

            Console.ReadKey();
        }
    }


}
