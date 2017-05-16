namespace Voting
{
    partial class BallotFrm
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
            this.candidate1 = new System.Windows.Forms.ComboBox();
            this.candidate2 = new System.Windows.Forms.ComboBox();
            this.candidate3 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.candidate4 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Cast = new System.Windows.Forms.Button();
            this.header = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // candidate1
            // 
            this.candidate1.FormattingEnabled = true;
            this.candidate1.Location = new System.Drawing.Point(51, 65);
            this.candidate1.Name = "candidate1";
            this.candidate1.Size = new System.Drawing.Size(294, 28);
            this.candidate1.TabIndex = 0;
            // 
            // candidate2
            // 
            this.candidate2.FormattingEnabled = true;
            this.candidate2.Location = new System.Drawing.Point(51, 109);
            this.candidate2.Name = "candidate2";
            this.candidate2.Size = new System.Drawing.Size(294, 28);
            this.candidate2.TabIndex = 1;
            // 
            // candidate3
            // 
            this.candidate3.FormattingEnabled = true;
            this.candidate3.Location = new System.Drawing.Point(51, 152);
            this.candidate3.Name = "candidate3";
            this.candidate3.Size = new System.Drawing.Size(294, 28);
            this.candidate3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "2:";
            // 
            // candidate4
            // 
            this.candidate4.FormattingEnabled = true;
            this.candidate4.Location = new System.Drawing.Point(51, 195);
            this.candidate4.Name = "candidate4";
            this.candidate4.Size = new System.Drawing.Size(294, 28);
            this.candidate4.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "3:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "4:";
            // 
            // Cast
            // 
            this.Cast.Location = new System.Drawing.Point(51, 246);
            this.Cast.Name = "Cast";
            this.Cast.Size = new System.Drawing.Size(140, 36);
            this.Cast.TabIndex = 8;
            this.Cast.Text = "Cast";
            this.Cast.UseVisualStyleBackColor = true;
            this.Cast.Click += new System.EventHandler(this.Cast_Click);
            // 
            // header
            // 
            this.header.AutoSize = true;
            this.header.Location = new System.Drawing.Point(50, 21);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(0, 20);
            this.header.TabIndex = 9;
            // 
            // BallotFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 299);
            this.Controls.Add(this.header);
            this.Controls.Add(this.Cast);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.candidate4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.candidate3);
            this.Controls.Add(this.candidate2);
            this.Controls.Add(this.candidate1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BallotFrm";
            this.Text = "Ballot";
            this.Load += new System.EventHandler(this.BallotFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox candidate1;
        private System.Windows.Forms.ComboBox candidate2;
        private System.Windows.Forms.ComboBox candidate3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox candidate4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Cast;
        private System.Windows.Forms.Label header;
    }
}