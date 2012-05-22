/// <summary>
/// Class name: RenameDictionary
/// Date: 9-4-2012
/// Description: Handles all operations of renaming a dictionary
/// </summary>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;

namespace Planetarium_Plugin
{
    public partial class RenameDictionary : UserControl
    {

        PlanetariumDB_API api = new PlanetariumDB_API();
        public string keyword = string.Empty;
        PowerPoint.Presentation presentation;
        string dictionaryName = "";
        string location = "";

        public RenameDictionary()
        {
            InitializeComponent();
            pnlDictionary.Enabled = true;
            pnlRenameDictionary.Enabled = false;
        }
        private void RenameDictionary_Load(object sender, EventArgs e)
        {
            
            List<Dictionary> dic = api.getAllDictionaries();

            if (cmbDictionaries.Items.Count != 0)
            {
                cmbDictionaries.Items.Clear();
            }

            foreach (Dictionary d in dic)
            {
                cmbDictionaries.Items.Add(d.Type);
            }
        }
        private void cmbDictionaries_Click(object sender, EventArgs e)
        {
           
            List<Dictionary> dic = api.getAllDictionaries();

            if (cmbDictionaries.Items.Count != 0)
            {
                cmbDictionaries.Items.Clear();
            }

            foreach (Dictionary d in dic)
            {
                cmbDictionaries.Items.Add(d.Type);
            }
        }
        private void cmbDictionaries_SelectedIndexChanged(object sender, EventArgs e)
        {

            dictionaryName = cmbDictionaries.SelectedItem.ToString();
            location = api.getDictionary(dictionaryName).Slide_URL;
            txtOldName.Text = dictionaryName;
          
            presentation = Globals.ThisAddIn.Application.Presentations.Open(location);
            presentation = Globals.ThisAddIn.Application.ActivePresentation;
            pnlDictionary.Enabled = false;
            pnlRenameDictionary.Enabled = true;
                    
        }
        private void cmdRenameSave_Click(object sender, EventArgs e)
        {
            if (txtRename.Text != "")
            {
                if (api.dictionary_exists(dictionaryName))
                {
                    string rename = txtRename.Text;
                    DialogResult r = MessageBox.Show("Are you sure you want to rename the " + dictionaryName + " dictionary \n to " +rename+ "?", "Delete Dictionary Confirmation", MessageBoxButtons.YesNo);
                    if (r.ToString().Equals("Yes"))
                    {
                        api.updateDictionary(dictionaryName, rename);
                        MessageBox.Show("Dictionary Name Updated");
                    }
                    
                    reload();
                    cmbDictionaries.SelectedText = rename; //???
                    txtOldName.Text = rename;
                    dictionaryName = rename;
                    
                }
                else
                {
                    MessageBox.Show("Dictionary does not exist");
                }
            }
            else
            {
                MessageBox.Show("Field cannot be Blank");
            }
            
        }

        private void cmdSaveChanges_Click(object sender, EventArgs e)
        {
            presentation.SaveAs(location, Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, Microsoft.Office.Core.MsoTriState.msoTrue);
            presentation.Save();
            txtOldName.Clear();
            txtRename.Clear();
            cmbDictionaries.SelectedIndex = -1;
            pnlDictionary.Enabled = true;
            pnlRenameDictionary.Enabled = false;
            presentation.Close();
        }
        

        private void reload()
        {
            List<Dictionary> dic = api.getAllDictionaries();

            if (cmbDictionaries.Items.Count != 0)
            {
                cmbDictionaries.Items.Clear();
            }
            cmbDictionaries.Text = "";
            cmbDictionaries.Items.Add("");

            foreach (Dictionary d in dic)
            {
                cmbDictionaries.Items.Add(d.Type);
            }

            //cmbDictionaries.SelectedIndex = 0;
        }

     

    }
}
