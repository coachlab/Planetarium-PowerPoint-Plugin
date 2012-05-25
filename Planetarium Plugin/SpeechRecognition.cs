/// <summary>
/// Class name: SpeechRecognition
/// Date: 9-4-2012
/// Description: SpeechReognition class
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Recognition;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;
using System.Diagnostics;

using System.Runtime.InteropServices;

namespace Planetarium_Plugin
{
    class SpeechRecognition
    {
        PlanetariumDB_API api = new PlanetariumDB_API();
        private SpeechRecognitionEngine Sr;
        private List<string> keywords;
        private string dictionaryName;
        private string location;
        private Microsoft.Office.Interop.PowerPoint.Presentation pres;
        private decimal accuracy = 0;
        
        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="sr">Receives a SpeechRegonition obj.</param>
        /// <param name="List<words>">List of words.</param>
        /// <param name="location">Location.</param>
        /// <param name="dictionaryName">The dictionary name.</param>
        public SpeechRecognition(SpeechRecognitionEngine sr, List<string> words, string location, string dictionaryName, decimal accuracy)
        {
            this.location = location;
            this.dictionaryName = dictionaryName;
            this.accuracy = accuracy;
            Sr = sr;
            Sr.SetInputToDefaultAudioDevice();
            keywords = words;
            Grammar g = BuildGrammar();
            Sr.LoadGrammar(g);
        }

        /// <summary>
        /// Buils the grammar for the dictionary 
        /// </summary>
        /// <returns>Grammar that is built from words.</returns>
        public Grammar BuildGrammar()
        {
            GrammarBuilder gB = new GrammarBuilder(); gB.Culture = new System.Globalization.CultureInfo("en-GB");
            gB.Append(getGrammar());
            Grammar g = new Grammar(gB);
            return g;
        }

        /// <summary>
        /// SpeechRecognition event
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The result.</param>
        /// 
        void sr_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence >= Convert.ToDouble(this.accuracy / 100))
            {
                string  temp = e.Result.Text.ToLower();
               
                if (keywords.Contains(temp))
                {
                    if (Globals.ThisAddIn.notification == true)
                    {
                        DialogResult yes = MessageBox.Show("Do you want to display slide matching '" + temp + "'","display", MessageBoxButtons.YesNo);

                        if (yes.ToString().Equals("Yes"))
                        {
                            ShowSlides(temp);
                        }
                        else
                        {
                            if (pres != null)
                            {
                               // pres.SlideShowWindow.View.State = PowerPoint.PpSlideShowState.ppSlideShowBlackScreen;  
                            }   
                        }    
                    }
                    else
                    {
                        ShowSlides(temp); 
                    }
                }
            }         
        }

        /// <summary>
        /// Converts words to grammar format
        /// </summary>
        /// <returns>Grammar as choices.</returns>
        public Choices getGrammar()
        {
            Choices grammar = new Choices();
            int a = keywords.Count();
            string[] temp = new string[a];
            for (int i = 0; i < a; i++)
            {
                temp[i] = keywords[i];
            }
            grammar.Add(temp);
            return grammar;
        }

        /// <summary>
        /// Start the speech recognition
        /// </summary>
        public void Start()
        {
            Sr.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sr_SpeechRecognized);
            Sr.RecognizeAsync(RecognizeMode.Multiple);
            StartSlideShow();
        }

        void StartSlideShow()
        {
            pres = Globals.ThisAddIn.Application.Presentations.Open(location, Office.MsoTriState.msoFalse, Office.MsoTriState.msoFalse, Office.MsoTriState.msoFalse);
            pres.SlideShowSettings.Run();
            pres.SlideShowWindow.Activate();
        }

        /// <summary>
        /// Display the slides
        /// </summary>
        /// <param name="phrase">the phrase that is spoken.</param>
        public void ShowSlides(string phrase)
        {
            int id = 0;
            if (!string.IsNullOrEmpty(phrase))
            {
                id = api.getKeyword(dictionaryName, phrase).Slide_Num;
            }

            int index = 0;

            try
            {
               if (pres.SlideShowWindow!=null)
                {
                    foreach (PowerPoint.Slide slide in pres.Slides)
                    {
                        if (id == slide.SlideID )
                        {
                            index = slide.SlideIndex;
                            pres.SlideShowWindow.View.GotoSlide(index);
                        }
                    }
                }
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                //Stop();
            }
        }

      

         /// <summary>
        /// Pause speech 
        /// </summary>
        public void Pause()
        {
            Sr.RecognizeAsyncStop();
        }

        /// <summary>
        /// Stop speech recognition
        /// </summary>
        public void Stop()
        {
            Sr.RecognizeAsyncStop();
            Sr.UnloadAllGrammars();
        }
    }
}
