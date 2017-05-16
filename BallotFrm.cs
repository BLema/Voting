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
    public partial class BallotFrm : Form
    {
        private List<string> candidates = null;
        public BallotFrm()
        {
            InitializeComponent();
        }

        private void BallotFrm_Load(object sender, EventArgs e)
        {
            candidates = DBA.getCandidates();
            foreach (ComboBox c in this.Controls.OfType<ComboBox>())
            {
                foreach (string s in candidates)
                    c.Items.Add(s);
            }
        }

        private void Cast_Click(object sender, EventArgs e)
        {
            if (candidate1.SelectedIndex > -1 && 
                candidate2.SelectedIndex > -1)
            {
                Ballot ball = new Ballot(candidate1.Text, candidate2.Text, candidate3.Text, candidate4.Text);
                if (ball.NotSame())
                {
                    if (DBA.castBallot(ball))
                    {
                        BallotsView view = new BallotsView();
                        view.ShowDialog();
                    }
                }
                else
                {
                    header.Text = "Cannot pick same candidate more than once.";
                }
            }
            else
            {
                header.Text = "Vote for more candidates.";
            }
        }
        
    }
}
