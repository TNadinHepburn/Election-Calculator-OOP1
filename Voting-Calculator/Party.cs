using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting_Calculator
{
    class Party
    {
        private int _seats;

        public string Name { get; }
        public int Votes { get; }
        public string[] Candidates { get; }
        public int Seats
        {
            get => _seats;
            set => _seats++;
        }

        public Party(string Name, int Votes, string[] Candidates)
        {
            this.Name = Name;
            this.Votes = Votes;
            this.Candidates = Candidates;
            _seats = 0;
        }
        public Party()
        {
            this.Votes = 0;
        }

    }
}
