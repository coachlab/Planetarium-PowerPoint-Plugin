namespace Planetarium_Plugin
{
    partial class UpdateDictionary
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

        /// <summary>
        /// show the slide number of the selected slide on the user controller for updating a dictionary
        /// </summary>
        /// <param name="id">the slide id of the selected slide</param>
        /// <param name="num">the slide number of the selected slide</param>
        public void showSlideNumber(string id, string num)
        {
            txtSlideNumber.Tag = id;
            txtSlideNumber.Text = num;
            txtKeyword.Clear();
            txtKeyword.Text = api.getKeyword(cmbDictionary.SelectedItem.ToString(),  System.Int32.Parse(txtSlideNumber.Tag.ToString()));
            keyword = txtKeyword.Text;

 
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdUpdateDictionary = new System.Windows.Forms.Button();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.pnlRenameSlide = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSlideNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdFinish = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pnlDictionary = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDictionary = new System.Windows.Forms.ComboBox();
            this.pnlRenameSlide.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.pnlDictionary.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdUpdateDictionary
            // 
            this.cmdUpdateDictionary.Location = new System.Drawing.Point(47, 71);
            this.cmdUpdateDictionary.Name = "cmdUpdateDictionary";
            this.cmdUpdateDictionary.Size = new System.Drawing.Size(113, 23);
            this.cmdUpdateDictionary.TabIndex = 4;
            this.cmdUpdateDictionary.Text = "Update keyword";
            this.cmdUpdateDictionary.UseVisualStyleBackColor = true;
            this.cmdUpdateDictionary.Click += new System.EventHandler(this.cmdUpdateDictionary_Click);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(60, 45);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(104, 20);
            this.txtKeyword.TabIndex = 3;
            // 
            // pnlRenameSlide
            // 
            this.pnlRenameSlide.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlRenameSlide.Controls.Add(this.cmdUpdateDictionary);
            this.pnlRenameSlide.Controls.Add(this.txtKeyword);
            this.pnlRenameSlide.Controls.Add(this.label6);
            this.pnlRenameSlide.Controls.Add(this.txtSlideNumber);
            this.pnlRenameSlide.Controls.Add(this.label5);
            this.pnlRenameSlide.Location = new System.Drawing.Point(6, 18);
            this.pnlRenameSlide.Name = "pnlRenameSlide";
            this.pnlRenameSlide.Size = new System.Drawing.Size(174, 102);
            this.pnlRenameSlide.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Keyword";
            // 
            // txtSlideNumber
            // 
            this.txtSlideNumber.Enabled = false;
            this.txtSlideNumber.Location = new System.Drawing.Point(80, 10);
            this.txtSlideNumber.Name = "txtSlideNumber";
            this.txtSlideNumber.Size = new System.Drawing.Size(84, 20);
            this.txtSlideNumber.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Slide number:";
            // 
            // cmdFinish
            // 
            this.cmdFinish.Location = new System.Drawing.Point(80, 232);
            this.cmdFinish.Name = "cmdFinish";
            this.cmdFinish.Size = new System.Drawing.Size(91, 23);
            this.cmdFinish.TabIndex = 8;
            this.cmdFinish.Text = "Finish";
            this.cmdFinish.UseVisualStyleBackColor = true;
            this.cmdFinish.Click += new System.EventHandler(this.cmdFinish_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnlRenameSlide);
            this.groupBox2.Location = new System.Drawing.Point(3, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(187, 128);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Change keyword";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pnlDictionary);
            this.groupBox3.Location = new System.Drawing.Point(3, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(187, 79);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dictionaries";
            // 
            // pnlDictionary
            // 
            this.pnlDictionary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDictionary.Controls.Add(this.label4);
            this.pnlDictionary.Controls.Add(this.cmbDictionary);
            this.pnlDictionary.Location = new System.Drawing.Point(6, 18);
            this.pnlDictionary.Name = "pnlDictionary";
            this.pnlDictionary.Size = new System.Drawing.Size(174, 57);
            this.pnlDictionary.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Select a dictionary";
            // 
            // cmbDictionary
            // 
            this.cmbDictionary.FormattingEnabled = true;
            this.cmbDictionary.Location = new System.Drawing.Point(6, 27);
            this.cmbDictionary.Name = "cmbDictionary";
            this.cmbDictionary.Size = new System.Drawing.Size(158, 21);
            this.cmbDictionary.TabIndex = 6;
            this.cmbDictionary.SelectionChangeCommitted += new System.EventHandler(this.cmbDictionary_SelectedIndexChanged);
            this.cmbDictionary.Click += new System.EventHandler(this.cmbDictionary_Click);
            // 
            // UpdateDictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmdFinish);
            this.Name = "UpdateDictionary";
            this.Size = new System.Drawing.Size(195, 342);
            this.Load += new System.EventHandler(this.UpdateDictionary_Load_1);
            this.pnlRenameSlide.ResumeLayout(false);
            this.pnlRenameSlide.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.pnlDictionary.ResumeLayout(false);
            this.pnlDictionary.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdUpdateDictionary;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Panel pnlRenameSlide;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSlideNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdFinish;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel pnlDictionary;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDictionary;
    }
}
