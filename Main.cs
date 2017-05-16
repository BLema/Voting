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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Vote_Click(object sender, EventArgs e)
        {
            BallotFrm ball = new BallotFrm();
            ball.ShowDialog();
        }

        private void Borda_Click(object sender, EventArgs e)
        {
            BordaResults borda = new BordaResults();
            borda.ShowDialog();
        }

        private void Ranked_Click(object sender, EventArgs e)
        {
            RankedResults ranked = new RankedResults();
            ranked.ShowDialog();
        }
    }
}
