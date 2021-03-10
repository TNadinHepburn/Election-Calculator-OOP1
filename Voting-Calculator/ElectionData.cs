using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting_Calculator
{
    class ElectionData
    {
        //Properties of ElectionData
        public string Location { get; }
        public int TotalVotes { get; }
        public List<Party> Parties { get; }
        public int TotalSeats { get; } = 5;

        //Constructor for ElectionData
        public ElectionData(string Location, int TotalVotes, string[] Parties)
        {
            this.Location = Location;
            this.TotalVotes = TotalVotes;
            this.Parties = MakePartyClasses(Parties);
        }
        //Methods for ElectionData
        //Makes each party into a Party clsas
        public List<Party> MakePartyClasses(string[] arrayParties)
        {
            List<Party> listParties = new List<Party>();
            foreach(string elem in arrayParties)
            {
                //Splittting the name votes and candidates into seperate variables
                string PartyName = elem.Split(',')[0];
                int PartyVotes = int.Parse(elem.Split(',')[1]);
                //VotingInfo.Replace(VotingInfo.Split('\n')[0], "").Replace(VotingInfo.Split('\n')[1], "").Trim();
                string[] PartyCandidates = elem.Replace(elem.Split(',')[0], "").Replace(elem.Split(',')[1], "").Replace(";", "").Replace(",", " ").Trim().Split(' ');
                //create and add party to ElectionData 
                Party tempParty = new Party(PartyName, PartyVotes, PartyCandidates);
                listParties.Add(tempParty);
            }
            return listParties;
        }
        //Calculates using De'Hont who is awarded a seat
        public void BiggestVotes()
        {
            int seatWinnerIndex = 0;
            Party seatWinner = new Party();
            int counter = 0;
            //
            foreach (Party party in Parties)
            {
                if ((party.Votes/(party.Seats+1)) > (seatWinner.Votes/(seatWinner.Seats+1)))
                {
                    seatWinner = party;
                    seatWinnerIndex = counter;
                }
                counter++;
            }
            this.Parties[seatWinnerIndex].Seats++;
        }
        //For each avaliable seat calls the method to find the winner of the seat
        public void SeatsAwarded()
        {
            for (int i = 0; i < TotalSeats; i++)
            {
                this.BiggestVotes();
            }
        }
        //Returns a string containing the results of the election
        public string Result()
        {
            //Adds location the the start of the string
            string finalResult = $"{this.Location}\n";
            //Each party that won a seat is added into the string
            foreach(Party party in Parties)
            {
                string tempCandidates = "";
                if (party.Seats > 0)
                {
                    for (int i = 0; i < party.Seats-1; i++)
                    {
                        tempCandidates += $"{party.Candidates[i]},";
                    }
                    tempCandidates += $"{party.Candidates[party.Seats-1]};\n";
                    finalResult += $"{party.Name},{tempCandidates}";
                }
            }
            return finalResult.Trim();
        }

    }
}
