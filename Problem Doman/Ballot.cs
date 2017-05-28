using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting
{
    class Ballot
    {
        private List<string> candidates;
        public List<string> Candidates
        {
            get { return candidates; }
        }

        public Ballot() { }

        public Ballot(string cand1, string cand2, string cand3, string cand4)
        {
            candidates = new List<string>();
            candidates.Add(cand1);
            candidates.Add(cand2);
            candidates.Add(cand3);
            candidates.Add(cand4);
        }

        public Ballot(List<string> candidates)
        {
            this.candidates = candidates;
        }

        public bool NotSame()
        {
            bool same = false;
            for (int i = 0; i < candidates.Count; i++)
            {
                if (candidates[i].Equals(""))
                    continue;

                for (int j = i + 1; j < candidates.Count; j++)
                {
                    same = candidates[i].Equals(candidates[j]);
                    if (same)
                        break;
                }
                if (same)
                    break;
            }
            return !same;
        }
    }
}
