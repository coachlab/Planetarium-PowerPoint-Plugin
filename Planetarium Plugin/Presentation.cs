/// <summary>
/// Class name: Presentation
/// Date: 9-4-2012
/// Description: Shows the presentation chosen and navigates according to recognised keywords
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
using System.Speech.Recognition;

namespace Planetarium_Plugin
{
    public partial class Presentation : UserControl
    {
        PlanetariumDB_API api = new PlanetariumDB_API();
        string dictionaryName;
        string location;
        string phrase;        

        public Presentation()
        {
            InitializeComponent();
        }

        private void Presentation_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Initialises name and location of dictionary to be used
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDictionary_SelectedIndexChanged(object sender, EventArgs e)
        {

            location = api.getDictionary(cmdDictionary.SelectedItem.ToString()).Slide_URL;
            dictionaryName = cmdDictionary.SelectedItem.ToString();

        }
        
        /// <summary>
        /// Starts the presentation in full screen mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdStartPresentation_Click(object sender, EventArgs e)
        {
            try
            {
                SpeechRecognitionEngine sr = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-GB"));
                SpeechRecognition speech = new SpeechRecognition(sr, api.getAllStringKeywordsInDictionary(cmdDictionary.SelectedItem.ToString()), location, dictionaryName, Accuracy.Value);
                speech.Start();
            }
            catch (NullReferenceException)
            {

            }
        }

        /// <summary>
        /// loads dictionaries into combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDictionary_Click(object sender, EventArgs e)
        {
            List<Dictionary> dic = api.getAllDictionaries();

            if (cmdDictionary.Items.Count != 0)
            {
                cmdDictionary.Items.Clear();
            }

            foreach (Dictionary d in dic)
            {
                cmdDictionary.Items.Add(d.Type);
            }
        }

        /// <summary>
        /// Allows the user to enable notifications
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbEnableNotifications_CheckedChanged(object sender, EventArgs e)
        {

            Globals.ThisAddIn.notification = true;
        }

        /// <summary>
        /// Allows the user to disable notifications
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbDisableNotifications_CheckedChanged(object sender, EventArgs e)
        {
            Globals.ThisAddIn.notification = false;
        }

        private void cmdDictionary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'a')
            MessageBox.Show("testing");
        }
    }
}
