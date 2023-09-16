using System.ComponentModel;

namespace Image_Slider_Puzzle
{
    public class LanguageChanger
    {
        private readonly List<ToolStripMenuItem> btnList;

        private Dictionary<string, string> englishStrings = new Dictionary<string, string>()
        {
            {"fileToolStripMenuItem", "File"},
            {"openToolStripMenuItem", "Open"},
            {"GalleryToolStripMenuItem", "Gallery"},
            {"SettingsOpenClosedClickEvent", "Settings"},
            {"englishToolStripMenuItem", "English"},
            {"bulgarianToolStripMenuItem", "Bulgarian"},
            {"languageToolStripMenuItem", "Language"},
        };

        private Dictionary<string, string> bulgarianStrings = new Dictionary<string, string>()
        {
            {"fileToolStripMenuItem", "Файл"},
            {"openToolStripMenuItem", "Отвори"},
            {"GalleryToolStripMenuItem", "Галерия"},
            {"SettingsOpenClosedClickEvent", "Настройки"},
            {"englishToolStripMenuItem", "Английски"},
            {"bulgarianToolStripMenuItem", "Български"},
            {"languageToolStripMenuItem", "Език"}
        };

        public LanguageChanger(List<ToolStripMenuItem> btns)
        {

            this.btnList = btns;

        }



        public void ChangeLanguage(Language language)
        {
            Dictionary<string, string> languageStrings;

            if (language == Language.Bulgarian) languageStrings = bulgarianStrings;
            else languageStrings = englishStrings;

            //btnEnglish.Text = languageStrings["btnEnglish"];
            //btnBulgarian.Text = languageStrings["btnBulgarian"];
            //btn.Text = languageStrings[btn.Name];
            btnList.ForEach(btn => btn.Text = languageStrings[btn.Name]);
        }



        //public enum Language 
        //{
        //    English,
        //    Bulgarian
        //}
    }

}
