using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Voting
{
    public partial class RankedResults : Form
    {
        public RankedResults()
        {
            InitializeComponent();
        }
        
        private void RankedResults_Load_1(object sender, EventArgs e)
        {
            List<Candidate> candidates = DBA.getCandidateFirstVotes();
            Stack<Candidate> eliminated = new Stack<Candidate>();
            int candidateCount = candidates.Count;
            do
            {
                Candidate bottom = candidates[0];
                for (int i = 1; i < candidates.Count; i++)
                {
                    if (candidates[i].RankedFinal < bottom.RankedFinal)
                    {
                        bottom = candidates[i];
                    }
                }
                eliminated.Push(bottom);
                candidates.Remove(bottom);
                candidates = DBA.getCandidateNextVotes(candidates, eliminated);
            } while (eliminated.Count < candidateCount);

            while (eliminated.Count > 0)
            {
                listBox2.Items.Add(eliminated.Pop().ToString(false));
            }
        }
    }
}
