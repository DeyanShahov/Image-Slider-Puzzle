namespace Image_Slider_Puzzle
{
    public static class StringData
    {
        public static readonly string gameModNormal = "Normal";
        public static readonly string gameModHard = "Hard";
        public static readonly string gameModVeryHard = "VeryHard";
        public static readonly string victory = "VICTORY";
        public static readonly string directionLeft = "Left";
        public static readonly string directionRight = "Right";
        public static readonly string directionUp = "Up";
        public static readonly string directionDown = "Down";
        public static readonly string directionSwitch = "Switch";
        public static readonly string warningStartGame = "The Game has not started, at least one direct move is required.";
        public static readonly string warningNoSolution = "No Solution";
        public static readonly string messageNoFoundSolution = "No solution found in allowed attempts.";




        public static Dictionary<string, string> EnglishStrings = new Dictionary<string, string>
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

        public static Dictionary<string, string> BulgarianStrings = new Dictionary<string, string>
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

        public static Dictionary<string, string> GermanStrings = new Dictionary<string, string>
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

        public static Dictionary<string, string> ChineseStrings = new Dictionary<string, string>
        {
            {"Moves Made:", "只有在中文:" },
            {"Switch", "交换" },
            {"Resume", "继续" },
            {"Pause", "暂停" },
            {"Congratulations...\nYour Win\nTime Elapsed : ", "祝贺...\n你的胜利\n经过的时间 : " },
            {"s.\nTotal Moves Made : ", "s.\n总移动次数 : " },
            {"Time is Up\nTry Again", "时间到\n再试一次" },
            {"Are You Sure To Restart ?", "确定要重新开始吗？" },
            {"Are You Sure To Quit ?", "确定要退出吗？" }
        };
    }
}
