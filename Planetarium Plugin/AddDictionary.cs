
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
using System.IO;
using System.Windows.Forms;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;
using System.Text.RegularExpressions;

namespace Planetarium_Plugin
{
    public partial class AddDictionary : UserControl
    {
        PlanetariumDB_API api = new PlanetariumDB_API();
        string dictionaryName = "";
        string location = "";
        PowerPoint.Presentation presentation;

        string filePath = Path.GetFullPath("/Planetarium Speech Recognition/Dictionaries");
        /// <summary>
        /// Constructor for adddictionary class
        /// </summary>
        public AddDictionary()
        {
            InitializeComponent();
            pnlDictionary.Enabled = true;
            pnlAssociations.Enabled = false;
            cmdAddSlide.Text = "Add Slide";


            if (!System.IO.Directory.Exists(filePath)); 
            {
                System.IO.Directory.CreateDirectory(filePath); 
            }
            

        }

        /// <summary>
        /// Handles button for creating dictionaries
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCreateDictionary_Click(object sender, EventArgs e)
        {

            dictionaryName = txtDictionary.Text;
            //dictionaryName = txtDictionary.Text.ToLower(); ?

            if (!api.dictionary_exists(dictionaryName))
            {
                if (dictionaryName != "")
                {

                    presentation = Globals.ThisAddIn.Application.ActivePresentation;

                    location = filePath + "\\" + dictionaryName;

                    presentation.SaveAs(location, Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, Microsoft.Office.Core.MsoTriState.msoTrue);
                    presentation.Save();

                    api.addDictionary(dictionaryName, location + ".pptx");

                    MessageBox.Show("Dictionary added. To proceed to adding slides please click on the slide displayed on the left pane");

                    pnlAssociations.Enabled = true;
                    pnlDictionary.Enabled = false;

                }
                else 
                {
                    MessageBox.Show("Dictionary name cannot be blank - Please enter a dictionary name");
                }
            }
            else
            {
                MessageBox.Show("\""+ dictionaryName + "\"" + " dictionary already exists");
            }
        }

        /// <summary>
        /// Handles button for adding slides
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddSlide_Click_1(object sender, EventArgs e)
        {
           try{

            if (txtPhrase.Text != "")
            {
                if (dictionaryName != "")
                {
                    if (Regex.IsMatch(txtPhrase.Text, @"^[a-zA-Z]+$"))
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
                    else 
                    {
                        MessageBox.Show("Keyword can only contain letters");
                    }
                    }

                }
                else
                {
                    MessageBox.Show("Please enter a keyword");
                }

            }
           catch (NullReferenceException ex)
           {
               MessageBox.Show("Please click on the slide in panel"); //make more firendly
           }
        }


        /// <summary>
        /// Clean up panel after saving a dictionary
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdFinish_Click(object sender, EventArgs e)
        {
            try
            {
                presentation.Save();
                pnlDictionary.Enabled = true;
                pnlAssociations.Enabled = false;
                txtDictionary.Clear();
                txtPhrase.Clear();

                if (presentation != null)
                {
                    presentation.Close();

                    PowerPoint.Application pptApp = Globals.ThisAddIn.Application;
                    PowerPoint.Presentation newPresentation = pptApp.Presentations.Add(Office.MsoTriState.msoTrue);

                    PowerPoint.Slides slides = newPresentation.Slides;
                    PowerPoint.Slide slide = slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutCustom);

                    newPresentation = Globals.ThisAddIn.Application.ActivePresentation;
                }
             
            }
            catch (NullReferenceException ex) {
                MessageBox.Show("No changes made");
            }catch(System.Runtime.InteropServices.COMException ex){

            }
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
