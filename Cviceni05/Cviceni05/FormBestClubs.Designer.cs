namespace Cviceni05
{
    partial class FormBestClubs
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.labelBestClubs = new System.Windows.Forms.Label();
            this.labelGoals = new System.Windows.Forms.Label();
            this.labelAssists = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 90);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(571, 97);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // labelBestClubs
            // 
            this.labelBestClubs.AutoSize = true;
            this.labelBestClubs.Location = new System.Drawing.Point(13, 13);
            this.labelBestClubs.Name = "labelBestClubs";
            this.labelBestClubs.Size = new System.Drawing.Size(60, 13);
            this.labelBestClubs.TabIndex = 1;
            this.labelBestClubs.Text = "Best Clubs:";
            // 
            // labelGoals
            // 
            this.labelGoals.AutoSize = true;
            this.labelGoals.Location = new System.Drawing.Point(80, 13);
            this.labelGoals.Name = "labelGoals";
            this.labelGoals.Size = new System.Drawing.Size(46, 13);
            this.labelGoals.TabIndex = 2;
            this.labelGoals.Text = "Goals: 0";
            // 
            // labelAssists
            // 
            this.labelAssists.AutoSize = true;
            this.labelAssists.Location = new System.Drawing.Point(80, 37);
            this.labelAssists.Name = "labelAssists";
            this.labelAssists.Size = new System.Drawing.Size(51, 13);
            this.labelAssists.TabIndex = 3;
            this.labelAssists.Text = "Assists: 0";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(508, 61);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // FormBestClubs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 199);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelAssists);
            this.Controls.Add(this.labelGoals);
            this.Controls.Add(this.labelBestClubs);
            this.Controls.Add(this.listView1);
            this.Name = "FormBestClubs";
            this.Text = "FormBestClubs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label labelBestClubs;
        private System.Windows.Forms.Label labelGoals;
        private System.Windows.Forms.Label labelAssists;
        private System.Windows.Forms.Button buttonOK;
    }
}