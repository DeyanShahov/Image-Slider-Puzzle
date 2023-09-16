namespace Image_Slider_Puzzle
{
    public class LanguageChanger
    {
        private Dictionary<ToolStripMenuItem, Dictionary<Language, string>> btnList = new Dictionary<ToolStripMenuItem, Dictionary<Language, string>>();
   
        public void ChangeLanguage(Language language)
        {
            foreach (var item in btnList)
            {
                item.Key.Text = item.Value[language];
            }
        }

        public void SortDataForLanguageDictionary(List<ToolStripMenuItem> toolStripMenuItems, Dictionary<Language, string[]> possibleLanguagesWords)
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

            btnList = objectList;
        }
    }

    public enum Language
    {
        English,
        Bulgarian
    }
}
