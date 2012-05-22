using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Planetarium_Plugin
{
    class PlanetariumDB_API
    {
        /// <summary>
        /// function to add a dictionary to the database
        /// </summary>
        /// <param name="type">The name of the dictionary</param>
        /// <param name="Slide_URL">Where the Silde is store</param>
        public void addDictionary(string type, string Slide_URL)
        {
            using (PlanetariumDataContext db = new PlanetariumDataContext())
            {

                Dictionary dictionary = new Dictionary { Type = type, Slide_URL = Slide_URL };
                db.Dictionaries.InsertOnSubmit(dictionary);
                db.SubmitChanges();
            }
        }
        /// <summary>
        /// function to remove a dictionary from the database
        /// with related slide in the keyword dictionary
        /// </summary>
        /// <param name="type">the name of the dictionary to remove</param>
        public void removeDictionary(string type)
        {
            using (var db = new PlanetariumDataContext())
            {
                try
                {
                    var result = db.Dictionaries.Single(a => a.Type.Equals(type));

                    int id = result.Dictionary_ID;

                    List<Keyword> keywords = new List<Keyword>();

                    keywords = (from a in db.Keywords
                                where a.Dictionary_ID == id
                                select a).ToList();

                    db.Keywords.DeleteAllOnSubmit(keywords);
                    db.SubmitChanges();
                    db.Dictionaries.DeleteOnSubmit(result);
                    db.SubmitChanges();
                }
                catch (Exception)
                {

                }
            }
        }
        /// <summary>
        /// function to update the dictionary given the name of the dictionary to update
        /// </summary>
        /// <param name="type">name of dictionary to update</param>
        /// <param name="newType">new name to replace in the dictionary</param>
        public void updateDictionary(string type, string newType)
        {
            using (var db = new PlanetariumDataContext())
            {
                var result = db.Dictionaries.Single(a => a.Type.Equals(type));

                result.Type = newType;

                db.SubmitChanges();
            }
        }
        /// <summary>
        /// function to update the dictionary URL
        /// </summary>
        /// <param name="type">the name of the dictionary to update</param>
        /// <param name="newSlide_URL">new slide name to replace in for the dictionary</param>
        public void updateDictionaryURL(string type, string newSlide_URL)
        {
            using (var db = new PlanetariumDataContext())
            {
                var result = db.Dictionaries.Single(a => a.Type.Equals(type));
                result.Slide_URL = newSlide_URL;
                db.SubmitChanges();
            }
        }

        public bool dictionary_exists(string type)
        {

            using (var db = new PlanetariumDataContext())
            {
                List<string> dictionaries = (from a in db.Dictionaries
                                             select a.Type).ToList();

                return dictionaries.Contains(type);
            }
        }
        /// <summary>
        /// function that returns the dictionary specified
        /// </summary>
        /// <param name="type">the name of the dictionary to return</param>
        /// <returns>Dictionary</returns>
        public Dictionary getDictionary(string type)
        {
            using (var db = new PlanetariumDataContext())
            {
                var result = db.Dictionaries.Single(a => a.Type.Equals(type));

                return result;
            }
        }
        /// <summary>
        /// function that returns all the dictionary in the database
        /// </summary>
        /// <returns> List of Dictionary</returns>
        public List<Dictionary> getAllDictionaries()
        {
            using (var db = new PlanetariumDataContext())
            {
                var result = (from a in db.Dictionaries
                              select a).ToList();

                return result;
            }
        }
        /// <summary>
        /// function that returns a list of all keywords for the given dictionary
        /// </summary>
        /// <param name="type">name of the dictionary to return keywords</param>
        /// <returns>List of keywords</returns>
        public List<Keyword> getAllKeywordsInDictionary(string type)
        {
            using (var db = new PlanetariumDataContext())
            {
                Dictionary dictionary = db.Dictionaries.Single(a => a.Type.Equals(type));
                List<Keyword> keywords = (from a in db.Keywords
                                          where a.Dictionary_ID == dictionary.Dictionary_ID
                                          select a).ToList();

                return keywords;
            }
        }
        /// <summary>
        /// function that return a list of string off all the keywords in the dictionary
        /// </summary>
        /// <param name="type">name of the dictionary to get keywords from</param>
        /// <returns>List of strings</returns>
        public List<string> getAllStringKeywordsInDictionary(string type)
        {
            using (var db = new PlanetariumDataContext())
            {
                Dictionary dictionary = db.Dictionaries.Single(a => a.Type.Equals(type));
                List<string> keywords = (from a in db.Keywords
                                         where a.Dictionary_ID == dictionary.Dictionary_ID
                                         select a.Phrase).ToList();

                return keywords;
            }
        }

        /// <summary>
        /// function that adds a keyword to the specified dictionary
        /// </summary>
        /// <param name="dictionary">dictionary to add keyword to</param>
        /// <param name="phrase">the phrase to add to the dictionary specified</param>
        /// <param name="slide_num">the number of the slide</param>
        public void addKeyword(string dictionary, string phrase, int slide_num)
        {
            using (var db = new PlanetariumDataContext())
            {
                Dictionary cat = db.Dictionaries.Single(a => a.Type.Equals(dictionary));
                Keyword key = new Keyword { Dictionary_ID = cat.Dictionary_ID, Phrase = phrase, Slide_Num = slide_num };

                db.Keywords.InsertOnSubmit(key);
                db.SubmitChanges();

            }
        }
        /// <summary>
        /// function that removes a keyword from a dictionary
        /// </summary>
        /// <param name="phrase">phrase to remove of the specified dictionary</param>
        /// <param name="dictionary">dictionary to remove it to</param>
        public void removeKeyword(string phrase, string dictionary)
        {
            using (var db = new PlanetariumDataContext())
            {
                try
                {
                    Keyword key = db.Keywords.Single(a => a.Dictionary.Type.Equals(dictionary) && a.Phrase.Equals(phrase));
                    int slide_num = key.Slide_Num;

                    if (slide_num == getAllKeywordsInDictionary(dictionary).Count)
                    {
                        db.Keywords.DeleteOnSubmit(key);
                        db.SubmitChanges();
                    }
                    else
                    {
                        db.Keywords.DeleteOnSubmit(key);
                        db.SubmitChanges();
                        var list = from a in db.Keywords where a.Slide_Num > slide_num select a;

                        foreach (var n in list)
                        {
                            n.Slide_Num -= 1;
                            db.SubmitChanges();
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
        }
        /// <summary>
        /// function to update the phrase for a given keyword in a dictionary
        /// </summary>
        /// <param name="phrase">old phrase to update</param>
        /// <param name="newPhrase">new phrase to update to</param>
        /// <param name="dictionary">name of dictionary to update</param>
        public void updateKeywordPhrase(string phrase, string newPhrase, string dictionary)
        {

            using (var db = new PlanetariumDataContext())
            {
                Keyword key = db.Keywords.Single(a => a.Phrase.Equals(phrase) && a.Dictionary.Type.Equals(dictionary));
                key.Phrase = newPhrase;
                db.SubmitChanges();
            }
        }
        /// <summary>
        /// Checks if a particular phrase is in a particular dictionary
        /// </summary>
        /// <param name="type"> Dictionary to look into</param>
        /// <param name="phrase"> phrase to look for</param>
        /// <returns> true if the phrase exists, otherwise false </returns>
        public bool keyword_exists(string type, string phrase)
        {

            using (var db = new PlanetariumDataContext())
            {
                Dictionary dictionary = getDictionary(type);
                List<string> keywords = (from a in db.Keywords
                                         where a.Dictionary_ID == dictionary.Dictionary_ID
                                         select a.Phrase).ToList();

                return keywords.Contains(phrase);
            }
        }
        /// <summary>
        /// Checks if a particular phrase is in a particular dictionary using the phrase ID
        /// </summary>
        /// <param name="type"> Dictionary to look into </param>
        /// <param name="slide_id">ID of the slide </param>
        /// <returns> true if the phrase exists, otherwise false </returns>
        public bool keyword_exists(string type, int slide_id)
        {

            using (var db = new PlanetariumDataContext())
            {
                Dictionary dictionary = getDictionary(type);
                List<Int32> keywords = (from a in db.Keywords
                                        where a.Dictionary_ID == dictionary.Dictionary_ID
                                        select a.Slide_Num).ToList();

                return keywords.Contains(slide_id);
            }
        }
        //working
        /*public void updateKeywordSlide(string phrase, int slide_num, string dictionary)
        {
            using (var db = new PlanetariumDataContext())
            {
                Keyword key = db.Keywords.Single(a =>a.Phrase.Equals(phrase) && a.Dictionary.Type == dictionary);
                key.Slide_Num = slide_num;

                db.SubmitChanges();
            }
        }
        */

        /// <summary>
        /// Retrieves a keyword for a particular dictionary from the database
        /// </summary>
        /// <param name="type">Dictionary name </param>
        /// <param name="phrase">Keyword ID </param>
        /// <returns></returns>
        public Keyword getKeyword(string type, string phrase)
        {
            using (var db = new PlanetariumDataContext())
            {
                Dictionary dictionary = db.Dictionaries.Single(a => a.Type.Equals(type));
                Keyword keyword = db.Keywords.Single(n => n.Dictionary_ID == dictionary.Dictionary_ID && n.Phrase.Equals(phrase));
                return keyword;
            }
        }

        /// <summary>
        /// Retrieves a keyword for a particular dictionary from the database using its ID
        /// </summary>
        /// <param name="type">Dictionary name</param>
        /// <param name="slide_id">Keyword ID</param>
        /// <returns></returns>
        public string getKeyword(string type, int slide_id)
        {
            using (var db = new PlanetariumDataContext())
            {
                Dictionary dictionary = db.Dictionaries.Single(a => a.Type.Equals(type));
                Keyword keyword = db.Keywords.Single(n => n.Dictionary_ID == dictionary.Dictionary_ID && n.Slide_Num.Equals(slide_id));
                return keyword.Phrase;
            }
        }

    }
}
