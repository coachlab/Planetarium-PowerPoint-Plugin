
/// <summary>
/// Class name: UpdateDictionary
/// Date: 9-4-2012
/// Description: Handles all operations of updating a dictionary
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
using System.Text.RegularExpressions;

namespace Planetarium_Plugin
{
    public partial class UpdateDictionary : UserControl
    {
        PlanetariumDB_API api = new PlanetariumDB_API();
        public string keyword = string.Empty;
        PowerPoint.Presentation presentation;
        string dictionaryName = "";
        string location = "";

        public UpdateDictionary()
        {
            InitializeComponent();
            pnlDictionary.Enabled = true;
            pnlRenameSlide.Enabled = false; 
            
        }
        /// <summary>
        /// Opens the dictionary whose name is selected on the combobox for update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDictionary_SelectedIndexChanged(object sender, EventArgs e)
        {

            dictionaryName = cmbDictionary.SelectedItem.ToString();
            location = api.getDictionary(dictionaryName).Slide_URL;

           // if (Globals.ThisAddIn.Application.ActivePresentation != null)
           // {
             //   presentation = Globals.ThisAddIn.Application.ActivePresentation;
              //  Globals.ThisAddIn.Application.ActivePresentation.Close();
           // }
           //// else
           // {
             Globals.ThisAddIn.Application.ActivePresentation.Close();
                presentation = Globals.ThisAddIn.Application.Presentations.Open(location);
                presentation = Globals.ThisAddIn.Application.ActivePresentation;
          // }
            pnlDictionary.Enabled = false;
            pnlRenameSlide.Enabled = true;
 
        }

       /// <summary>
       /// Handles loading of dictionaries into combobox
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void UpdateDictionary_Load_1(object sender, EventArgs e)
        {
            reload();
            List<Dictionary> dic = api.getAllDictionaries();

            if (cmbDictionary.Items.Count != 0)
            {
                cmbDictionary.Items.Clear();
            }

            foreach (Dictionary d in dic)
            {
                cmbDictionary.Items.Add(d.Type);
            }
        }

        /// <summary>
        /// reloads dicitonaries in the combobox so that added and removed dictionaries may reflect
        /// </summary>
        private void reload()
        {
            List<Dictionary> dic = api.getAllDictionaries();

            if (cmbDictionary.Items.Count != 0)
            {
                cmbDictionary.Items.Clear();
            }

            cmbDictionary.Items.Add("");

            foreach (Dictionary d in dic)
            {
                cmbDictionary.Items.Add(d.Type);
            }

            cmbDictionary.SelectedIndex = 0;
        }

        /// <summary>
        /// Updates the specified dictionary according to the information provided
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdUpdateDictionary_Click(object sender, EventArgs e)
        {
            if (txtKeyword.Text != "" && txtSlideNumber.Text!=string.Empty)
            {
                if(Regex.IsMatch(txtKeyword.Text, @"^[a-zA-Z]+$"))
                
                {
                if (api.keyword_exists(dictionaryName, Int32.Parse(txtSlideNumber.Tag.ToString())))
                {
                    api.updateKeywordPhrase(keyword, txtKeyword.Text.ToLower(), cmbDictionary.SelectedItem.ToString());
                    txtKeyword.Text = api.getKeyword(cmbDictionary.SelectedItem.ToString(), Int32.Parse(txtSlideNumber.Tag.ToString()));
                    MessageBox.Show("Keyword Updated");
                }
                else
                {
                    if (!api.keyword_exists(dictionaryName, txtKeyword.Text) && !api.keyword_exists(dictionaryName, Int32.Parse(txtSlideNumber.Tag.ToString())))
                    {
                        api.addKeyword(cmbDictionary.SelectedItem.ToString(), txtKeyword.Text.ToLower(), Int32.Parse(txtSlideNumber.Tag.ToString()));
                        txtKeyword.Text = api.getKeyword(cmbDictionary.SelectedItem.ToString(), Int32.Parse(txtSlideNumber.Tag.ToString()));
                        MessageBox.Show("Keyword Added");
                    }
                    else
                    {
                        MessageBox.Show("Cannot Update Keyword - Add keyword in Add Panel");
                    }
                }
                }
                else
                {
                 MessageBox.Show("Keyword can only contain letters");
                }

            }
            else
            {
                MessageBox.Show("Keyword Cannot Be Blank");
            }
        }

        private void cmbDictionary_Click(object sender, EventArgs e)
        {

            reload();
            List<Dictionary> dic = api.getAllDictionaries();

            if (cmbDictionary.Items.Count != 0)
            {
                cmbDictionary.Items.Clear();
            }

            foreach (Dictionary d in dic)
            {
                cmbDictionary.Items.Add(d.Type);
            }
        }

        private void cmdFinish_Click(object sender, EventArgs e)
        {
            
            if (presentation != null)
            {
                presentation.Save();
                presentation.Close();

                PowerPoint.Application pptApp = Globals.ThisAddIn.Application;
                PowerPoint.Presentation newPresentation = pptApp.Presentations.Add(Office.MsoTriState.msoTrue);

                PowerPoint.Slides slides = newPresentation.Slides;
                PowerPoint.Slide slide = slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

                newPresentation = Globals.ThisAddIn.Application.ActivePresentation;
                
                
            }
            cmbDictionary.SelectedIndex = -1;

            pnlDictionary.Enabled = true;

            pnlRenameSlide.Enabled = false;
            
        }

        private void cmbDictionary_Click_1(object sender, EventArgs e)
        {
            List<Dictionary> dic = api.getAllDictionaries();

            cmbDictionary.Items.Clear();

            foreach (Dictionary d in dic)
            {
                cmbDictionary.Items.Add(d.Type);
            }
        }
    }
}
