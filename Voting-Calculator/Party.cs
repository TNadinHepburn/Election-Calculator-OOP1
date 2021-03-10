using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting_Calculator
{
    class Party
    {
        //Properties of Party
        //How many seats a party has won
        private int _seats;
        //Name and votes and candidates of a party with auto-imlemented gets
        public string Name { get; }
        public int Votes { get; }
        //list of candidates that can win seats
        public string[] Candidates { get; }

        //Get and increment seat value
        public int Seats
        {
            get => _seats;
            set => _seats++;
        }
        //Constructors for this Class
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
