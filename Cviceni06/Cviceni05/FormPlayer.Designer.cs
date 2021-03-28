namespace Cviceni05
{
    partial class FormPlayer
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
            this.labelName = new System.Windows.Forms.Label();
            this.labelClub = new System.Windows.Forms.Label();
            this.labelGoals = new System.Windows.Forms.Label();
            this.labelAssists = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.comboBoxClub = new System.Windows.Forms.ComboBox();
            this.numericUpDownGoals = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAssists = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGoals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAssists)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(13, 13);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(41, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name: ";
            // 
            // labelClub
            // 
            this.labelClub.AutoSize = true;
            this.labelClub.Location = new System.Drawing.Point(16, 47);
            this.labelClub.Name = "labelClub";
            this.labelClub.Size = new System.Drawing.Size(34, 13);
            this.labelClub.TabIndex = 1;
            this.labelClub.Text = "Club: ";
            // 
            // labelGoals
            // 
            this.labelGoals.AutoSize = true;
            this.labelGoals.Location = new System.Drawing.Point(13, 78);
            this.labelGoals.Name = "labelGoals";
            this.labelGoals.Size = new System.Drawing.Size(40, 13);
            this.labelGoals.TabIndex = 2;
            this.labelGoals.Text = "Goals: ";
            // 
            // labelAssists
            // 
            this.labelAssists.AutoSize = true;
            this.labelAssists.Location = new System.Drawing.Point(13, 106);
            this.labelAssists.Name = "labelAssists";
            this.labelAssists.Size = new System.Drawing.Size(40, 13);
            this.labelAssists.TabIndex = 3;
            this.labelAssists.Text = "Assits: ";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(13, 134);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(106, 134);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(61, 13);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(121, 20);
            this.textBoxName.TabIndex = 6;
            // 
            // comboBoxClub
            // 
            this.comboBoxClub.FormattingEnabled = true;
            this.comboBoxClub.Location = new System.Drawing.Point(61, 47);
            this.comboBoxClub.Name = "comboBoxClub";
            this.comboBoxClub.Size = new System.Drawing.Size(121, 21);
            this.comboBoxClub.TabIndex = 7;
            // 
            // numericUpDownGoals
            // 
            this.numericUpDownGoals.Location = new System.Drawing.Point(61, 78);
            this.numericUpDownGoals.Name = "numericUpDownGoals";
            this.numericUpDownGoals.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownGoals.TabIndex = 8;
            // 
            // numericUpDownAssists
            // 
            this.numericUpDownAssists.Location = new System.Drawing.Point(61, 105);
            this.numericUpDownAssists.Name = "numericUpDownAssists";
            this.numericUpDownAssists.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownAssists.TabIndex = 9;
            // 
            // FormPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 166);
            this.Controls.Add(this.numericUpDownAssists);
            this.Controls.Add(this.numericUpDownGoals);
            this.Controls.Add(this.comboBoxClub);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelAssists);
            this.Controls.Add(this.labelGoals);
            this.Controls.Add(this.labelClub);
            this.Controls.Add(this.labelName);
            this.Name = "FormPlayer";
            this.Text = "Player";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGoals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAssists)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelClub;
        private System.Windows.Forms.Label labelGoals;
        private System.Windows.Forms.Label labelAssists;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.ComboBox comboBoxClub;
        private System.Windows.Forms.NumericUpDown numericUpDownGoals;
        private System.Windows.Forms.NumericUpDown numericUpDownAssists;
    }
}