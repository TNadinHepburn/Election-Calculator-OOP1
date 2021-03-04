using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting_Calculator
{
    class ElectionData
    {
        public string Location { get; }
        public int TotalVotes { get; }
        public List<Party> Parties { get; }
        public int TotalSeats { get; } = 5;

        public ElectionData(string Location, int TotalVotes, string[] Parties)
        {
            this.Location = Location;
            this.TotalVotes = TotalVotes;
            this.Parties = MakePartyClasses(Parties);
        }
        
        public List<Party> MakePartyClasses(string[] arrayParties)
        {
            List<Party> listParties = new List<Party>();
            //Brexit Party,452321,BP1,BP2,BP3,BP4,BP5;
            foreach(string elem in arrayParties)
            {

                string PartyName = elem.Split(',')[0];
                int PartyVotes = int.Parse(elem.Split(',')[1]);
                //VotingInfo.Replace(VotingInfo.Split('\n')[0], "").Replace(VotingInfo.Split('\n')[1], "").Trim();
                string[] PartyCandidates = elem.Replace(elem.Split(',')[0], "").Replace(elem.Split(',')[1], "").Replace(";", "").Replace(",", " ").Trim().Split(' ');
                Party tempParty = new Party(PartyName, PartyVotes, PartyCandidates);
                listParties.Add(tempParty);
            }
            return listParties;
        }

        public void BiggestVotes()
        {
            int seatWinnerIndex = 0;
            Party seatWinner = new Party();
            int counter = 0;
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

        public void SeatsAwarded()
        {
            for (int i = 0; i < TotalSeats; i++)
            {
                this.BiggestVotes();
            }
        }

        public string Result()
        {
            string finalResult = $"{this.Location}\n";
            
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
