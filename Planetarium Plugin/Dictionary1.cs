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
    class Dictionary
    {
        string dictionaryName = "";
        string location = "";
        string phrase = "";
        PlanetariumDB_API api = new PlanetariumDB_API();
        PowerPoint.Presentation presentation;
      

     /**  private void CreateDictionary(string dictionary, string location)
        {

            if (!api.dictionary_exists(dictionaryName))
            {
                if (dictionaryName != "")
                {
                    
                    presentation = Globals.ThisAddIn.Application.ActivePresentation;
                    string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    location = filePath + "\\Dictionaries\\" + dictionaryName;

                    presentation.SaveAs(location, Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, Microsoft.Office.Core.MsoTriState.msoTrue);
                    presentation.Save();

                    api.addDictionary(dictionaryName, location + ".pptx");

                    MessageBox.Show("Dictionary added. To proceed to adding slides please click on the slide displayed on the left");

                }
            }
            else
            {
                MessageBox.Show("Already exists");
            }
        }

       private void AddSlide(string dictionary, string phrase, TextBox txtSlideNumber)
       {
           if (phrase != "")
           {
               if (dictionaryName != "")
               {
                   try
                   {
                       if (!api.keyword_exists(dictionaryName, phrase) && !api.keyword_exists(dictionaryName, Int32.Parse(txtSlideNumber.Tag.ToString())))
                       {
                           api.addKeyword(dictionaryName, phrase.ToLower(), Int32.Parse(txtSlideNumber.Tag.ToString()));
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
       }*/


        public Dictionary(string location, string dictionary) {

            
        }

       public void OpenDictionary(PowerPoint.Presentation presentation, string dictionary, string location) {

           presentation = Globals.ThisAddIn.Application.Presentations.Open(location);
           presentation = Globals.ThisAddIn.Application.ActivePresentation;
  
       }

       private void closeDictionary(string dictionary, string location)
       {

           presentation = Globals.ThisAddIn.Application.ActivePresentation;
           presentation.Close();

       }

       public void reInitialisePresentation()
       {
           if (Globals.ThisAddIn.Application.ActivePresentation != null)
           {
               Globals.ThisAddIn.Application.ActivePresentation.Close();

               PowerPoint.Application plugin = Globals.ThisAddIn.Application;
               PowerPoint.Presentation presentation = plugin.Presentations.Add(Office.MsoTriState.msoTrue);

               PowerPoint.Slides slides = presentation.Slides;
               PowerPoint.Slide slide = slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutCustom);

               presentation = Globals.ThisAddIn.Application.ActivePresentation;
           }
           else { }
       }
    /**   private void LoadDictionaries(ComboBox cmbDictionaries)
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

       private void reloadDictionaries(ComboBox combobox)
       {
           List<Dictionary> dic = api.getAllDictionaries();

           if (combobox.Items.Count != 0)
           {
               combobox.Items.Clear();
           }

           combobox.Items.Add("");

           foreach (Dictionary d in dic)
           {
               combobox.Items.Add(d.Type);
           }

           combobox.SelectedIndex = 0;
       }

       private void UpdateDictionary(string keyword, TextBox txtSlideNumber, ComboBox cmbDictionary)
       {
           if (keyword != "")
           {
               if (api.keyword_exists(dictionaryName, Int32.Parse(txtSlideNumber.Tag.ToString())))
               {
                   api.updateKeywordPhrase(keyword, keyword.ToLower(), cmbDictionary.SelectedItem.ToString());
                   keyword = api.getKeyword(cmbDictionary.SelectedItem.ToString(), Int32.Parse(txtSlideNumber.Tag.ToString()));
                   MessageBox.Show("Keyword Updated");
               }
               else
               {
                   if (!api.keyword_exists(dictionaryName, keyword) && !api.keyword_exists(dictionaryName, Int32.Parse(txtSlideNumber.Tag.ToString())))
                   {
                       api.addKeyword(cmbDictionary.SelectedItem.ToString(), keyword.ToLower(), Int32.Parse(txtSlideNumber.Tag.ToString()));
                       keyword = api.getKeyword(cmbDictionary.SelectedItem.ToString(), Int32.Parse(txtSlideNumber.Tag.ToString()));
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
               MessageBox.Show("Keyword Cannot Be Blank");
           }
       }

       private void RenameDictionary(string currentName, string newName)
       {

           currentName = dictionaryName;
           if (newName != "")
           {
               if (api.dictionary_exists(dictionaryName))
               {
                   string rename = newName;

                   api.updateDictionary(dictionaryName, rename);
                   MessageBox.Show("Dictionary Name Updated");
                   //reloadDictionaries();
                 //  cmbDictionaries.SelectedText = rename; //???
                 //  txtOldName.Text = rename;
                  // dictionaryName = rename;
                  // txtRename.Clear();
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
           //else dictionary name alerady exists
       }

       private void RemoveDictionary(ComboBox dictionary)
       {
           PlanetariumDB_API api = new PlanetariumDB_API();

           if (dictionary.SelectedIndex != -1)
           {
               api.removeDictionary(dictionary.SelectedItem.ToString());
           }

           MessageBox.Show("Dictionary deleted");
           reloadDictionaries(dictionary);
       }
     
       public void NavigateSlides(string phrase)
       {
          
           int id = api.getKeyword(dictionaryName, phrase).Slide_Num;
           int index = 0;

           if (presentation != null)
           {
               try
               {
                   foreach (PowerPoint.Slide slide in presentation.Slides)
                   {

                       if (id == slide.SlideID)
                       {

                           index = slide.SlideIndex;
                           if (index != 0)
                           {

                               presentation.SlideShowWindow.View.GotoSlide(index);
                           }
                       }
                   }
               }
               catch (System.Runtime.InteropServices.COMException ex)
               {


               }
           }
       }

       public void ActivateSlideShow()
       {
           
           presentation = Globals.ThisAddIn.Application.Presentations.Open(location, Office.MsoTriState.msoFalse, Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue);
           presentation = Globals.ThisAddIn.Application.ActivePresentation;
           presentation.SlideShowSettings.Run();
           presentation.SlideShowWindow.Activate(); //opporunity for a COM exception
       }*/


       }

}
