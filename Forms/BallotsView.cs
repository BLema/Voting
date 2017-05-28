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
    public partial class BallotsView : Form
    {
        public BallotsView()
        {
            InitializeComponent();
        }

        private void BallotsView_Load(object sender, EventArgs e)
        {
            List<Ballot> ballots = DBA.getBallots();
            foreach (Ballot b in ballots)
            {
                string ball = "";
                foreach (string candidate in b.Candidates)
                {
                    ball += (candidate.Trim().Length == 0 ? "none":candidate.Trim()) + 
                        " | ";
                }
                listBox1.Items.Add(ball);
            }
        }
    }
}
