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
            //Total amount of seats avaliable
            int TotalSeats = 5;
            //Read in the election input file
            var inputDataFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assessment1InputData.txt");
            string[] votesFile = File.ReadAllLines(inputDataFilePath);
            string votesLocation = votesFile[0];
            int votesTotal = int.Parse(votesFile[1]);
            //Create and add the parties to an new array 
            var votesParties = new string[votesFile.Count() - 2];
            Array.Copy(votesFile, 2,votesParties,0,votesParties.Count());
            //create instance of Election data 
            ElectionData VotingData = new ElectionData(votesLocation,votesTotal,votesParties);
            //Find which party gets each seat
            VotingData.SeatsAwarded();
            //Print result or election to console
            Console.WriteLine(VotingData.Result());

            Console.ReadKey();
        }
    }


}
