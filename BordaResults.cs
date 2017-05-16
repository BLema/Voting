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
    public partial class BordaResults : Form
    {
        public BordaResults()
        {
            InitializeComponent();
        }

        private void BordaResults_Load(object sender, EventArgs e)
        {
            List<Candidate> candidates = DBA.getCandidateVotes();

            while (candidates.Count > 0)
            {
                Candidate top = candidates[0];
                for (int i = 1; i<candidates.Count; i++)
                {
                    if(candidates[i].BordaCount > top.BordaCount)
                    {
                        top = candidates[i];
                    }
                }
                listBox1.Items.Add(top.ToString(true));
                candidates.Remove(top);
            }
        }
    }
}
