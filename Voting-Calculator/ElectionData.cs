using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting_Calculator
{
    class ElectionData
    {
        private string _Location;
        private int _TotalVotes;
        private List<Party> _Parties;


        public string Location => _Location;
        public int TotalVotes => _TotalVotes;
        public List<Party> Parties => _Parties;

        public ElectionData(string Location, int TotalVotes, string[] Parties)
        {
            _Location = Location;
            _TotalVotes = TotalVotes;
            _Parties = makePartyClasses(Parties);
        }
        
        public List<Party> makePartyClasses(string[] arrayParties)
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



    }
}
