namespace Voting
{
    partial class RankedResults
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBox2
            // 
            this.listBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Location = new System.Drawing.Point(12, 13);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(572, 244);
            this.listBox2.TabIndex = 0;
            // 
            // RankedResults
            // 
            this.ClientSize = new System.Drawing.Size(596, 273);
            this.Controls.Add(this.listBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RankedResults";
            this.Text = "RankedResults";
            this.Load += new System.EventHandler(this.RankedResults_Load_1);
            this.ResumeLayout(false);

        }

        #endregion
        
        private System.Windows.Forms.ListBox listBox2;
    }
}