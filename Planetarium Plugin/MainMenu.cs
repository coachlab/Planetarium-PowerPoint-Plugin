/// <summary>
/// Class name: Main menu
/// Date: 9-4-2012
/// Description: Handles display of main ribbon
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Office.Tools.Ribbon;
using Tools = Microsoft.Office.Tools;
using Office = Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using System.Runtime.ExceptionServices;

namespace Planetarium_Plugin
{
    public partial class MainMenu
    {
        string currentlyViewed = "";
        PlanetariumDB_API api = new PlanetariumDB_API();
        Tools.CustomTaskPane presentation;
        Tools.CustomTaskPane addDictionary;
        Tools.CustomTaskPane removeDictionary;
        Tools.CustomTaskPane updateDictionary;
        Tools.CustomTaskPane renameDictionary;

        Presentation presentations = new Presentation();
        AddDictionary addDictionaries = new AddDictionary();
        RemoveDictionary removeDictionaries = new RemoveDictionary();
        UpdateDictionary updateDictionaries = new UpdateDictionary();
        RenameDictionary renameDictionaries = new RenameDictionary();

        private void MainMenu_Load(object sender, RibbonUIEventArgs e)
        {
            presentation = Globals.ThisAddIn.CustomTaskPanes.Add(presentations, "Presentation");
            addDictionary = Globals.ThisAddIn.CustomTaskPanes.Add(addDictionaries, "Add Dictionaries");
            removeDictionary = Globals.ThisAddIn.CustomTaskPanes.Add(removeDictionaries, "Remove Dictionaries");
            updateDictionary = Globals.ThisAddIn.CustomTaskPanes.Add(updateDictionaries, "Update Dictionaries");
            renameDictionary = Globals.ThisAddIn.CustomTaskPanes.Add(renameDictionaries, "Rename Dictionaries");
          
            //Slide change event handler
            try
            {
                
                Globals.ThisAddIn.Application.SlideSelectionChanged += Application_SlideSelectionChanged;
               
            }
            catch (AccessViolationException ex)
            {
                
                
            }
           
        }

        [HandleProcessCorruptedStateExceptions]

        //slide change function
        void Application_SlideSelectionChanged(PowerPoint.SlideRange SldRange)
        {
            try
            {

                if (SldRange != null)
                {
                    if (currentlyViewed == "add")
                    {
                        try
                        {
                            addDictionaries.showSlideNumber(SldRange.SlideID.ToString(), SldRange.SlideNumber.ToString());
                            

                       }
                        catch (System.AccessViolationException ex) { }

                    }
                    else if (currentlyViewed == "update")
                    {
                        updateDictionaries.showSlideNumber(SldRange.SlideID.ToString(), SldRange.SlideNumber.ToString());
                    }

                }
            }
            catch (AccessViolationException avEx)
            {

            }
            catch (Exception ex)
            {

            }
        }

        private void cmdStart_Click(object sender, RibbonControlEventArgs e)
        {
            addDictionary.Visible = false;
            removeDictionary.Visible = false;
            updateDictionary.Visible = false;
            presentation.Visible = true;
            renameDictionary.Visible = false;
            currentlyViewed = "start";
        }

        private void cmdAddDictionary_Click(object sender, RibbonControlEventArgs e)
        {
            removeDictionary.Visible = false;
            updateDictionary.Visible = false;
            renameDictionary.Visible = false;
            presentation.Visible = false;
            addDictionary.Visible = true;
            currentlyViewed = "add";
        }

        private void cmdUpdateDictionary_Click(object sender, RibbonControlEventArgs e)
        {
            removeDictionary.Visible = false;
            presentation.Visible = false;
            addDictionary.Visible = false;
            renameDictionary.Visible = false;
            updateDictionary.Visible = true;
            currentlyViewed = "update";
        }

        private void cmdDeleteDictionary_Click(object sender, RibbonControlEventArgs e)
        {
            presentation.Visible = false;
            addDictionary.Visible = false;
            updateDictionary.Visible = false;
            renameDictionary.Visible = false;
            removeDictionary.Visible = true;
            currentlyViewed = "delete";
        }

        private void cmdHelp_Click(object sender, RibbonControlEventArgs e)
        {
            System.Diagnostics.Process.Start(Path.GetFullPath("myPVRS.chm"));
     
        }

        private void cmdAboutUs_Click(object sender, RibbonControlEventArgs e)
        {
            AboutBox1 b = new AboutBox1();
            b.Show();
        }

        private void cmdRenameDictionary_Click(object sender, RibbonControlEventArgs e)
        {
            presentation.Visible = false;
            addDictionary.Visible = false;
            updateDictionary.Visible = false;
            renameDictionary.Visible = true;
            removeDictionary.Visible = false;
            currentlyViewed = "rename";
        }
        
    }
}
