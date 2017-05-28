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
    public partial class BallotFrm2 : Form
    {
        private List<string> ballot = new List<string>();
        public BallotFrm2()
        {
            InitializeComponent();
        }

        private void BallotFrm2_Load(object sender, EventArgs e)
        {
            List<string> candidates = DBA.getCandidates();
            foreach(string c in candidates)
            {
                CandidateList.Items.Add(c);
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            int index = CandidateList.SelectedIndex;
            if (index > -1 && ballot.Count < 4)
            {
                ballot.Add(CandidateList.Items[index].ToString());

                BallotBox.Items.Add(ballot.Count + ": " + ballot.Last());
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            int index = BallotBox.SelectedIndex;
            if (index > -1)
            {
                ballot.Remove(BallotBox.Items[index].ToString().Substring(3));

                BallotBox.Items.Clear();
                for (int i = 1; i <= ballot.Count; i++)
                {
                    BallotBox.Items.Add(i + ": " + ballot[i - 1]);
                }
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            BallotBox.Items.Clear();
            ballot.Clear();
        }

        private void Cast_Click(object sender, EventArgs e)
        {
            if(ballot.Count > 1)
            {
                if (ballot.Count < 4)
                {
                    for (int i = ballot.Count; i < 4; i++)
                    {
                        ballot.Add("");
                    }
                }
                Ballot ball = new Ballot(ballot);
                if (ball.NotSame())
                {
                    if (DBA.castBallot(ball))
                    {
                        BallotsView view = new BallotsView();
                        view.ShowDialog();
                    }
                }
            }
        }
    }
}
