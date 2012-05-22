namespace Planetarium_Plugin
{
    partial class RenameDictionary
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlRenameDictionary = new System.Windows.Forms.Panel();
            this.cmdRenameSave = new System.Windows.Forms.Button();
            this.txtOldName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pnlDictionary = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDictionaries = new System.Windows.Forms.ComboBox();
            this.cmdSaveChanges = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.pnlRenameDictionary.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.pnlDictionary.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlRenameDictionary);
            this.groupBox1.Location = new System.Drawing.Point(3, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 138);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rename a dictionary";
            // 
            // pnlRenameDictionary
            // 
            this.pnlRenameDictionary.Controls.Add(this.cmdRenameSave);
            this.pnlRenameDictionary.Controls.Add(this.txtOldName);
            this.pnlRenameDictionary.Controls.Add(this.label2);
            this.pnlRenameDictionary.Controls.Add(this.txtRename);
            this.pnlRenameDictionary.Controls.Add(this.label1);
            this.pnlRenameDictionary.Location = new System.Drawing.Point(8, 19);
            this.pnlRenameDictionary.Name = "pnlRenameDictionary";
            this.pnlRenameDictionary.Size = new System.Drawing.Size(181, 112);
            this.pnlRenameDictionary.TabIndex = 10;
            // 
            // cmdRenameSave
            // 
            this.cmdRenameSave.Location = new System.Drawing.Point(50, 80);
            this.cmdRenameSave.Name = "cmdRenameSave";
            this.cmdRenameSave.Size = new System.Drawing.Size(94, 25);
            this.cmdRenameSave.TabIndex = 4;
            this.cmdRenameSave.Text = "Rename";
            this.cmdRenameSave.UseVisualStyleBackColor = true;
            this.cmdRenameSave.Click += new System.EventHandler(this.cmdRenameSave_Click);
            // 
            // txtOldName
            // 
            this.txtOldName.Location = new System.Drawing.Point(81, 20);
            this.txtOldName.Name = "txtOldName";
            this.txtOldName.ReadOnly = true;
            this.txtOldName.Size = new System.Drawing.Size(92, 20);
            this.txtOldName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Current Name:";
            // 
            // txtRename
            // 
            this.txtRename.Location = new System.Drawing.Point(70, 46);
            this.txtRename.Name = "txtRename";
            this.txtRename.Size = new System.Drawing.Size(103, 20);
            this.txtRename.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Name:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pnlDictionary);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(195, 77);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dictionaries";
            // 
            // pnlDictionary
            // 
            this.pnlDictionary.Controls.Add(this.label4);
            this.pnlDictionary.Controls.Add(this.cmbDictionaries);
            this.pnlDictionary.Location = new System.Drawing.Point(12, 19);
            this.pnlDictionary.Name = "pnlDictionary";
            this.pnlDictionary.Size = new System.Drawing.Size(177, 55);
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
            // cmbDictionaries
            // 
            this.cmbDictionaries.FormattingEnabled = true;
            this.cmbDictionaries.Location = new System.Drawing.Point(9, 27);
            this.cmbDictionaries.Name = "cmbDictionaries";
            this.cmbDictionaries.Size = new System.Drawing.Size(164, 21);
            this.cmbDictionaries.TabIndex = 6;
            this.cmbDictionaries.SelectedIndexChanged += new System.EventHandler(this.cmbDictionaries_SelectedIndexChanged);
            this.cmbDictionaries.Click += new System.EventHandler(this.cmbDictionaries_Click);
            // 
            // cmdSaveChanges
            // 
            this.cmdSaveChanges.Location = new System.Drawing.Point(61, 230);
            this.cmdSaveChanges.Name = "cmdSaveChanges";
            this.cmdSaveChanges.Size = new System.Drawing.Size(94, 26);
            this.cmdSaveChanges.TabIndex = 14;
            this.cmdSaveChanges.Text = "Finish";
            this.cmdSaveChanges.UseVisualStyleBackColor = true;
            this.cmdSaveChanges.Click += new System.EventHandler(this.cmdSaveChanges_Click);
            // 
            // RenameDictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.cmdSaveChanges);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "RenameDictionary";
            this.Size = new System.Drawing.Size(202, 356);
            this.Load += new System.EventHandler(this.RenameDictionary_Load);
            this.groupBox1.ResumeLayout(false);
            this.pnlRenameDictionary.ResumeLayout(false);
            this.pnlRenameDictionary.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.pnlDictionary.ResumeLayout(false);
            this.pnlDictionary.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnlRenameDictionary;
        private System.Windows.Forms.Button cmdRenameSave;
        private System.Windows.Forms.TextBox txtOldName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel pnlDictionary;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDictionaries;
        private System.Windows.Forms.Button cmdSaveChanges;
    }
}
