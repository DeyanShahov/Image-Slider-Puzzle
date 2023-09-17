namespace Image_Slider_Puzzle
{
    public class LanguageChanger
    {
        private Dictionary<ToolStripMenuItem, Dictionary<Language, string>> menuItemList = new Dictionary<ToolStripMenuItem, Dictionary<Language, string>>();
        private Dictionary<Button, Dictionary<Language, string>> btnList = new Dictionary<Button, Dictionary<Language, string>>();
        private Dictionary<Control, Dictionary<Language, string>> groupBoxListLabels = new Dictionary<Control, Dictionary<Language, string>>();

        public void ChangeLanguage(Language language)
        {
            foreach (var item in menuItemList)
            {
                item.Key.Text = item.Value[language];
            }

            foreach (var item in btnList)
            {
                item.Key.Text = item.Value[language];
            }

            foreach (var item in groupBoxListLabels)
            {
                item.Key.Text = item.Value[language];
            }
        }

        internal void SortDataForLanguageMenuItems(List<ToolStripMenuItem> toolStripMenuItems, Dictionary<Language, string[]> possibleLanguagesWords)
        {
            var objectList = new Dictionary<ToolStripMenuItem, Dictionary<Language, string>>();

            for (int i = 0; i < toolStripMenuItems.Count; i++)
            {
                foreach (var key in possibleLanguagesWords.Keys)
                {
                    if (!objectList.ContainsKey(toolStripMenuItems[i]))
                    {
                        objectList.Add(toolStripMenuItems[i], new Dictionary<Language, string>());
                        objectList[toolStripMenuItems[i]].Add(key, possibleLanguagesWords[key][i]);
                    }
                    else
                    {
                        objectList[toolStripMenuItems[i]].Add(key, possibleLanguagesWords[key][i]);
                    }
                }
            }

            menuItemList = objectList;
        }

        internal void SortDataForLanguageBtnItems(List<Button> buttonItems, Dictionary<Language, string[]> possibleLanguagesWords)
        {
            var objectList = new Dictionary<Button, Dictionary<Language, string>>();

            for (int i = 0; i < buttonItems.Count; i++)
            {
                foreach (var key in possibleLanguagesWords.Keys)
                {
                    if (!objectList.ContainsKey(buttonItems[i]))
                    {
                        objectList.Add(buttonItems[i], new Dictionary<Language, string>());
                        objectList[buttonItems[i]].Add(key, possibleLanguagesWords[key][i]);
                    }
                    else
                    {
                        objectList[buttonItems[i]].Add(key, possibleLanguagesWords[key][i]);
                    }
                }
            }

            btnList = objectList;
        }

        internal void SortDataForLanguageGroupBoxItems(List<Control> groupBoxesLabelsItems, Dictionary<Language, string[]> possibleLanguagesWords)
        {
            var objectList = new Dictionary<Control, Dictionary<Language, string>>();

            for (int i = 0; i < groupBoxesLabelsItems.Count; i++)
            {
                foreach (var key in possibleLanguagesWords.Keys)
                {
                    if (!objectList.ContainsKey(groupBoxesLabelsItems[i]))
                    {
                        objectList.Add(groupBoxesLabelsItems[i], new Dictionary<Language, string>());
                        objectList[groupBoxesLabelsItems[i]].Add(key, possibleLanguagesWords[key][i]);
                    }
                    else
                    {
                        objectList[groupBoxesLabelsItems[i]].Add(key, possibleLanguagesWords[key][i]);
                    }
                }
            }

            groupBoxListLabels = objectList;
        }

        internal string ReturnCorrectWord(string wordToCheck, Language languageCurrent)
        {
            Dictionary<string, string> languageStrings;

            if (languageCurrent == Language.English) languageStrings = StringData.EnglishStrings;
            else if(languageCurrent == Language.German) languageStrings = StringData.GermanStrings;
            else if(languageCurrent == Language.Chinese) languageStrings = StringData.ChineseStrings;
            else languageStrings = StringData.BulgarianStrings;

            return languageStrings[wordToCheck];
        }
    }


    public enum Language
    {
        English,
        Bulgarian,
        German,
        Chinese
    }
}
