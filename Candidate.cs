using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting
{
    class Candidate
    {
        private string name;
        public string Name
        {
            get { return name; }
        }
        private int first;
        public int First
        {
            set { first = value; }
            get { return first; }
        }
        private int second;
        public int Second
        {
            set { second = value; }
            get { return second; }
        }
        private int third;
        public int Third
        {
            set { third = value; }
            get { return third; }
        }
        private int fourth;
        public int Fourth
        {
            set { fourth = value; }
            get { return fourth; }
        }
        public int BordaCount
        {
            get { return first * 4 + second * 3 + third * 2 + fourth; }
        }

        public int RankedFinal
        {
            get { return first + second + third + fourth; }
        }

        public Candidate(string name)
        {
            this.name = name;
        }

        public void setVotes(int first, int second, int third, int fourth)
        {
            this.first = first;
            this.second = second;
            this.third = third;
            this.fourth = fourth;
        }

        public string ToString(bool borda)
        {
            string candidate = name;
            while (candidate.Length < 20)
            {
                candidate += " ";
            }
                
            candidate += "|  total: " + (borda ? BordaCount : RankedFinal) + "  |  first: " + first + "  |  second: " + second +
                "  |  third: " + third + "  | fourth: " + fourth + "  |";
            return candidate;
        }
    }
}
