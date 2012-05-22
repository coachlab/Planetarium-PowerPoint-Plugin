namespace Planetarium_Plugin
{
    partial class RemoveDictionary
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbDictionary = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdRemoveDictionary = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbDictionary);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmdRemoveDictionary);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 89);
            this.panel1.TabIndex = 15;
            // 
            // cmbDictionary
            // 
            this.cmbDictionary.FormattingEnabled = true;
            this.cmbDictionary.Location = new System.Drawing.Point(6, 27);
            this.cmbDictionary.Name = "cmbDictionary";
            this.cmbDictionary.Size = new System.Drawing.Size(171, 21);
            this.cmbDictionary.TabIndex = 17;
            this.cmbDictionary.Click += new System.EventHandler(this.cmbDictionary_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Dictionary name:";
            // 
            // cmdRemoveDictionary
            // 
            this.cmdRemoveDictionary.Location = new System.Drawing.Point(34, 54);
            this.cmdRemoveDictionary.Name = "cmdRemoveDictionary";
            this.cmdRemoveDictionary.Size = new System.Drawing.Size(113, 23);
            this.cmdRemoveDictionary.TabIndex = 16;
            this.cmdRemoveDictionary.Text = "Remove Dictionary";
            this.cmdRemoveDictionary.UseVisualStyleBackColor = true;
            this.cmdRemoveDictionary.Click += new System.EventHandler(this.cmdRemoveDictionary_Click);
            // 
            // RemoveDictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "RemoveDictionary";
            this.Size = new System.Drawing.Size(186, 201);
            this.Load += new System.EventHandler(this.RemoveDictionary_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbDictionary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdRemoveDictionary;

    }
}
