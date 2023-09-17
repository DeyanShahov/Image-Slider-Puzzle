namespace Image_Slider_Puzzle
{
    public class LanguageChanger
    {
        private Dictionary<string, string> englishStrings = new Dictionary<string, string>
        {
            {"Moves Made:", "Moves Made:"},
            {"Switch", "Switch" },
            {"Resume", "Resume" },
            {"Pause", "Pause" },
            {"Congratulations...\nYour Win\nTime Elapsed : ", "Congratulations...\nYour Win\nTime Elapsed : " },
            {"s.\nTotal Moves Made : ", "s.\nTotal Moves Made : " },
            {"Time is Up\nTry Again", "Time is Up\nTry Again" },
            {"Are You Sure To Restart ?", "Are You Sure To Restart ?" },
            {"Are You Sure To Quit ?", "Are You Sure To Quit ?" }
        };

        private Dictionary<string, string> bulgarianStrings = new Dictionary<string, string>
        {
            {"Moves Made:", "Направени Ходове:"},
            {"Switch", "Размени" },
            {"Resume", "Продължи" },
            {"Pause", "Пауза" },
            {"Congratulations...\nYour Win\nTime Elapsed : ", "Поздравления...\nТи Победи\nИзминало Време : " },
            {"s.\nTotal Moves Made : ", "s.\nПълен брой ходове : " },
            {"Time is Up\nTry Again", "Времето изтече\nОпитай пак" },
            {"Are You Sure To Restart ?", "Сигурни ли сте за Рестарта ?" },
            {"Are You Sure To Quit ?", "Сигурни ли сте за Напускането ?" }
        };

        private Dictionary<string, string> germanStrings = new Dictionary<string, string>
        {
            {"Moves Made:", "Nur auf Deutsch" },
            {"Switch", "Austauschen" },
            {"Resume", "Fortsetzen" },
            {"Pause", "Pause" },
            {"Congratulations...\nYour Win\nTime Elapsed : ", "Glückwünsche...\nDein Sieg\nVergangene Zeit : " },
            {"s.\nTotal Moves Made : ", "s.\nGesamtanzahl der Züge : " },
            {"Time is Up\nTry Again", "Die Zeit ist abgelaufen\nVersuch es erneut" },
            {"Are You Sure To Restart ?", "Sind Sie sicher, dass Sie neu starten möchten?" },
            {"Are You Sure To Quit ?", "Sind Sie sicher, dass Sie beenden möchten?" }
        };


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

            if (languageCurrent == Language.English) languageStrings = englishStrings;
            if (languageCurrent == Language.German) languageStrings = germanStrings;
            else languageStrings = bulgarianStrings;

            return languageStrings[wordToCheck];
        }
    }


    public enum Language
    {
        English,
        Bulgarian,
        German
    }
}
