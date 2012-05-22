namespace Planetarium_Plugin
{
    partial class Presentation
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
            this.grpNotifications = new System.Windows.Forms.GroupBox();
            this.rdbDisableNotifications = new System.Windows.Forms.RadioButton();
            this.rdbEnableNotifications = new System.Windows.Forms.RadioButton();
            this.cmdDictionary = new System.Windows.Forms.ComboBox();
            this.label = new System.Windows.Forms.Label();
            this.cmdStartPresentation = new System.Windows.Forms.Button();
            this.Accuracy = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.grpNotifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Accuracy)).BeginInit();
            this.SuspendLayout();
            // 
            // grpNotifications
            // 
            this.grpNotifications.Controls.Add(this.rdbDisableNotifications);
            this.grpNotifications.Controls.Add(this.rdbEnableNotifications);
            this.grpNotifications.Location = new System.Drawing.Point(15, 60);
            this.grpNotifications.Name = "grpNotifications";
            this.grpNotifications.Size = new System.Drawing.Size(168, 71);
            this.grpNotifications.TabIndex = 5;
            this.grpNotifications.TabStop = false;
            this.grpNotifications.Text = "Notifications";
            // 
            // rdbDisableNotifications
            // 
            this.rdbDisableNotifications.AutoSize = true;
            this.rdbDisableNotifications.Checked = true;
            this.rdbDisableNotifications.Location = new System.Drawing.Point(7, 44);
            this.rdbDisableNotifications.Name = "rdbDisableNotifications";
            this.rdbDisableNotifications.Size = new System.Drawing.Size(119, 17);
            this.rdbDisableNotifications.TabIndex = 1;
            this.rdbDisableNotifications.TabStop = true;
            this.rdbDisableNotifications.Text = "Disable notifications";
            this.rdbDisableNotifications.UseVisualStyleBackColor = true;
            this.rdbDisableNotifications.CheckedChanged += new System.EventHandler(this.rdbDisableNotifications_CheckedChanged);
            // 
            // rdbEnableNotifications
            // 
            this.rdbEnableNotifications.AutoSize = true;
            this.rdbEnableNotifications.Location = new System.Drawing.Point(7, 20);
            this.rdbEnableNotifications.Name = "rdbEnableNotifications";
            this.rdbEnableNotifications.Size = new System.Drawing.Size(117, 17);
            this.rdbEnableNotifications.TabIndex = 0;
            this.rdbEnableNotifications.Text = "Enable notifications";
            this.rdbEnableNotifications.UseVisualStyleBackColor = true;
            this.rdbEnableNotifications.CheckedChanged += new System.EventHandler(this.rdbEnableNotifications_CheckedChanged);
            // 
            // cmdDictionary
            // 
            this.cmdDictionary.FormattingEnabled = true;
            this.cmdDictionary.Location = new System.Drawing.Point(15, 32);
            this.cmdDictionary.Name = "cmdDictionary";
            this.cmdDictionary.Size = new System.Drawing.Size(168, 21);
            this.cmdDictionary.TabIndex = 4;
            this.cmdDictionary.SelectedIndexChanged += new System.EventHandler(this.cmdDictionary_SelectedIndexChanged);
            this.cmdDictionary.Click += new System.EventHandler(this.cmdDictionary_Click);
            this.cmdDictionary.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmdDictionary_KeyPress);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(12, 15);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(54, 13);
            this.label.TabIndex = 3;
            this.label.Text = "Dictionary";
            // 
            // cmdStartPresentation
            // 
            this.cmdStartPresentation.Location = new System.Drawing.Point(38, 176);
            this.cmdStartPresentation.Name = "cmdStartPresentation";
            this.cmdStartPresentation.Size = new System.Drawing.Size(117, 23);
            this.cmdStartPresentation.TabIndex = 6;
            this.cmdStartPresentation.Text = "Start Presentation";
            this.cmdStartPresentation.UseVisualStyleBackColor = true;
            this.cmdStartPresentation.Click += new System.EventHandler(this.cmdStartPresentation_Click);
            // 
            // Accuracy
            // 
            this.Accuracy.Location = new System.Drawing.Point(115, 141);
            this.Accuracy.Name = "Accuracy";
            this.Accuracy.Size = new System.Drawing.Size(68, 20);
            this.Accuracy.TabIndex = 7;
            this.Accuracy.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Speech accuracy:";
            // 
            // Presentation
            // 
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Accuracy);
            this.Controls.Add(this.cmdStartPresentation);
            this.Controls.Add(this.grpNotifications);
            this.Controls.Add(this.cmdDictionary);
            this.Controls.Add(this.label);
            this.Name = "Presentation";
            this.Size = new System.Drawing.Size(195, 343);
            this.Load += new System.EventHandler(this.Presentation_Load);
            this.grpNotifications.ResumeLayout(false);
            this.grpNotifications.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Accuracy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDictionary;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gpbNotifications;
        private System.Windows.Forms.RadioButton rdbOff;
        private System.Windows.Forms.RadioButton rdbEnable;
        private System.Windows.Forms.GroupBox grpNotifications;
        private System.Windows.Forms.RadioButton rdbDisableNotifications;
        private System.Windows.Forms.RadioButton rdbEnableNotifications;
        private System.Windows.Forms.ComboBox cmdDictionary;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button cmdStartPresentation;
        private System.Windows.Forms.NumericUpDown Accuracy;
        private System.Windows.Forms.Label label3;
    }
}
