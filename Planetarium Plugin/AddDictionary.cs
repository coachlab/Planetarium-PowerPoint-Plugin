
/// <summary>
/// Class name: AddDicitonary
/// Date: 9-4-2012
/// Description: All operations for adding a dictionary
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
    public partial class AddDictionary : UserControl
    {
        PlanetariumDB_API api = new PlanetariumDB_API();
        string dictionaryName = "";
        string location = "";
        PowerPoint.Presentation pres;
        /// <summary>
        /// Constructor for adddictionary class
        /// </summary>
        public AddDictionary()
        {
            InitializeComponent();
            pnlDictionary.Enabled = true;
            pnlAssociations.Enabled = false;
            cmdAddSlide.Text = "Add Slide";
        }

        /// <summary>
        /// Handles button for creating dictionaries
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCreateDictionary_Click(object sender, EventArgs e)
        {

            dictionaryName = txtDictionary.Text;

            if (!api.dictionary_exists(dictionaryName))
            {
                if (dictionaryName != "")
                {
                    
                    pres = Globals.ThisAddIn.Application.ActivePresentation;
                    string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    location = filePath + "\\Dictionaries\\" + dictionaryName;

                    pres.SaveAs(location, Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, Microsoft.Office.Core.MsoTriState.msoTrue);
                    pres.Save();

                    api.addDictionary(dictionaryName, location + ".pptx");

                    MessageBox.Show("Dictionary added. To proceed to adding slides please click on the slide displayed on the left");
                    pnlAssociations.Enabled = true;
                    pnlDictionary.Enabled = false;

                }
            }
            else
            {
                MessageBox.Show("Already exists");
            }
        }

        /// <summary>
        /// Handles button for adding slides
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddSlide_Click_1(object sender, EventArgs e)
        {
            if (txtPhrase.Text != "")
            {
                if (dictionaryName != "")
                {
                    try
                    {
                        if (!api.keyword_exists(dictionaryName, txtPhrase.Text) && !api.keyword_exists(dictionaryName, Int32.Parse(txtSlideNumber.Tag.ToString())))
                        {
                            api.addKeyword(dictionaryName, txtPhrase.Text.ToLower(), Int32.Parse(txtSlideNumber.Tag.ToString()));
                            MessageBox.Show("Slide added");
                        }

                        else
                        {
                            MessageBox.Show("Keyword Cannot Be Updated! - Use the Update Panel");
                        }
                    }
                    catch (NullReferenceException ex) { }

                }
                else
                {
                    MessageBox.Show("Please enter a keyword");
                }

            }
        }


        /// <summary>
        /// Clean up panel after saving a dictionary
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdFinish_Click(object sender, EventArgs e)
        {
            pres.Save();
            pnlDictionary.Enabled = true;
            pnlAssociations.Enabled = false;
            txtDictionary.Clear();
            txtPhrase.Clear();
        }

        /// <summary>
        /// Display the keyword for the selected slide
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSlideNumber_TextChanged(object sender, EventArgs e)
        {
            txtPhrase.Clear();

            if (txtDictionary.Text != null)
            {
               txtPhrase.Text = api.getKeyword(txtDictionary.Text, Int32.Parse(txtSlideNumber.Tag.ToString()));

            }
        }

    }
}
