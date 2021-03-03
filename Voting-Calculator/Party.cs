using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting_Calculator
{
    class Party
    {
        private string _name;
        private int _votes;
        private string[] _candidates;
        private int _seats;

        public string Name => _name;
        public int Votes => _votes;
        public string[] Candidates => _candidates;
        public int Seats
        {
            get => _seats;
            set => _seats++;
        }

        public Party(string Name, int Votes, string[] Candidates)
        {
            _name = Name;
            _votes = Votes;
            _candidates = Candidates;
            _seats = 0;
        }

    }
}
