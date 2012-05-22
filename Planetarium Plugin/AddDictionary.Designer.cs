namespace Planetarium_Plugin
{
    partial class AddDictionary
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
        /// show the slide number of the selected slide on the user controller for adding a dictionary
        /// </summary>
        /// <param name="id">the slide id of the selected slide</param>
        /// <param name="num">the slide number of the selected slide</param>
        public void showSlideNumber(string id, string num)
        {
            txtSlideNumber.Tag = id;
            txtSlideNumber.Text = num;
            
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdAddSlide = new System.Windows.Forms.Button();
            this.txtPhrase = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSlideNumber = new System.Windows.Forms.TextBox();
            this.pnlAssociations = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlDictionary = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdCreateDictionary = new System.Windows.Forms.Button();
            this.txtDictionary = new System.Windows.Forms.TextBox();
            this.cmdFinish = new System.Windows.Forms.Button();
            this.pnlAssociations.SuspendLayout();
            this.pnlDictionary.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdAddSlide
            // 
            this.cmdAddSlide.Location = new System.Drawing.Point(31, 84);
            this.cmdAddSlide.Name = "cmdAddSlide";
            this.cmdAddSlide.Size = new System.Drawing.Size(114, 23);
            this.cmdAddSlide.TabIndex = 4;
            this.cmdAddSlide.UseVisualStyleBackColor = true;
            this.cmdAddSlide.Click += new System.EventHandler(this.cmdAddSlide_Click_1);
            // 
            // txtPhrase
            // 
            this.txtPhrase.Location = new System.Drawing.Point(6, 58);
            this.txtPhrase.Name = "txtPhrase";
            this.txtPhrase.Size = new System.Drawing.Size(157, 20);
            this.txtPhrase.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Keywords:";
            // 
            // txtSlideNumber
            // 
            this.txtSlideNumber.Enabled = false;
            this.txtSlideNumber.Location = new System.Drawing.Point(80, 10);
            this.txtSlideNumber.Name = "txtSlideNumber";
            this.txtSlideNumber.Size = new System.Drawing.Size(83, 20);
            this.txtSlideNumber.TabIndex = 1;
            this.txtSlideNumber.TextChanged += new System.EventHandler(this.txtSlideNumber_TextChanged);
            // 
            // pnlAssociations
            // 
            this.pnlAssociations.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlAssociations.Controls.Add(this.cmdAddSlide);
            this.pnlAssociations.Controls.Add(this.txtPhrase);
            this.pnlAssociations.Controls.Add(this.label3);
            this.pnlAssociations.Controls.Add(this.txtSlideNumber);
            this.pnlAssociations.Controls.Add(this.label2);
            this.pnlAssociations.Location = new System.Drawing.Point(9, 102);
            this.pnlAssociations.Name = "pnlAssociations";
            this.pnlAssociations.Size = new System.Drawing.Size(174, 118);
            this.pnlAssociations.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Slide number:";
            // 
            // pnlDictionary
            // 
            this.pnlDictionary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDictionary.Controls.Add(this.label1);
            this.pnlDictionary.Controls.Add(this.cmdCreateDictionary);
            this.pnlDictionary.Controls.Add(this.txtDictionary);
            this.pnlDictionary.Location = new System.Drawing.Point(9, 12);
            this.pnlDictionary.Name = "pnlDictionary";
            this.pnlDictionary.Size = new System.Drawing.Size(174, 84);
            this.pnlDictionary.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Dictionary name:";
            // 
            // cmdCreateDictionary
            // 
            this.cmdCreateDictionary.Location = new System.Drawing.Point(31, 51);
            this.cmdCreateDictionary.Name = "cmdCreateDictionary";
            this.cmdCreateDictionary.Size = new System.Drawing.Size(114, 23);
            this.cmdCreateDictionary.TabIndex = 9;
            this.cmdCreateDictionary.Text = "Create Dictionary";
            this.cmdCreateDictionary.UseVisualStyleBackColor = true;
            this.cmdCreateDictionary.Click += new System.EventHandler(this.cmdCreateDictionary_Click);
            // 
            // txtDictionary
            // 
            this.txtDictionary.Location = new System.Drawing.Point(6, 25);
            this.txtDictionary.Name = "txtDictionary";
            this.txtDictionary.Size = new System.Drawing.Size(154, 20);
            this.txtDictionary.TabIndex = 8;
            // 
            // cmdFinish
            // 
            this.cmdFinish.Location = new System.Drawing.Point(40, 226);
            this.cmdFinish.Name = "cmdFinish";
            this.cmdFinish.Size = new System.Drawing.Size(114, 23);
            this.cmdFinish.TabIndex = 9;
            this.cmdFinish.Text = "Finish";
            this.cmdFinish.UseVisualStyleBackColor = true;
            this.cmdFinish.Click += new System.EventHandler(this.cmdFinish_Click);
            // 
            // AddDictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdFinish);
            this.Controls.Add(this.pnlDictionary);
            this.Controls.Add(this.pnlAssociations);
            this.Name = "AddDictionary";
            this.Size = new System.Drawing.Size(191, 282);
            this.pnlAssociations.ResumeLayout(false);
            this.pnlAssociations.PerformLayout();
            this.pnlDictionary.ResumeLayout(false);
            this.pnlDictionary.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdAddSlide;
        private System.Windows.Forms.TextBox txtPhrase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSlideNumber;
        private System.Windows.Forms.Panel pnlAssociations;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlDictionary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdCreateDictionary;
        private System.Windows.Forms.TextBox txtDictionary;
        private System.Windows.Forms.Button cmdFinish;
    }
}
