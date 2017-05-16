namespace Voting
{
    partial class Main
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
            this.Vote = new System.Windows.Forms.Button();
            this.Borda = new System.Windows.Forms.Button();
            this.Ranked = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Vote
            // 
            this.Vote.Location = new System.Drawing.Point(70, 35);
            this.Vote.Name = "Vote";
            this.Vote.Size = new System.Drawing.Size(133, 49);
            this.Vote.TabIndex = 0;
            this.Vote.Text = "Vote";
            this.Vote.UseVisualStyleBackColor = true;
            this.Vote.Click += new System.EventHandler(this.Vote_Click);
            // 
            // Borda
            // 
            this.Borda.Location = new System.Drawing.Point(70, 100);
            this.Borda.Name = "Borda";
            this.Borda.Size = new System.Drawing.Size(133, 46);
            this.Borda.TabIndex = 1;
            this.Borda.Text = "Borda";
            this.Borda.UseVisualStyleBackColor = true;
            this.Borda.Click += new System.EventHandler(this.Borda_Click);
            // 
            // Ranked
            // 
            this.Ranked.Location = new System.Drawing.Point(70, 164);
            this.Ranked.Name = "Ranked";
            this.Ranked.Size = new System.Drawing.Size(132, 47);
            this.Ranked.TabIndex = 2;
            this.Ranked.Text = "Ranked";
            this.Ranked.UseVisualStyleBackColor = true;
            this.Ranked.Click += new System.EventHandler(this.Ranked_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 244);
            this.Controls.Add(this.Ranked);
            this.Controls.Add(this.Borda);
            this.Controls.Add(this.Vote);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Vote;
        private System.Windows.Forms.Button Borda;
        private System.Windows.Forms.Button Ranked;
    }
}