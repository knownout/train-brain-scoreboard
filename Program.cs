using System;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using Newtonsoft.Json.Linq;

namespace TrainBrainScoreBoard
{
    static class Program
    {
        // При изменении версии необходимо изменять ее тут, иначе
        // программа будет пытаться обновиться при каждом запуске
        public static string CurrentProgrammVersion = "1.2.0";

        public static string LatestProgrammVersion = "N/a";
        public static string UpdateDownloadURL = "null";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (System.IO.File.Exists(@"update.bat"))
                System.IO.File.Delete(@"update.bat");

            WebClient wc = new();
            wc.Headers.Add("user-agent", "request");

            JObject json = JObject.Parse(wc.DownloadString("https://api.github.com/repos/re-knownout/train-brain-scoreboard/releases/latest"));
            LatestProgrammVersion = json["tag_name"].ToString().Replace("v", "");
            UpdateDownloadURL = json["assets"][0]["browser_download_url"].ToString();

            if (CurrentProgrammVersion == LatestProgrammVersion) Application.Run(new MainForm());
            else Application.Run(new AppUpdater());
        }
    }

    /**
     * Хранилище данных приложения
     * 
     * Внимание! Не обновляте данные внутри этого блока, 
     * все изменения данных происходят программно
     */
    public static class Storage
    {
        #pragma warning disable CA2211

        // Состояние управляющих элементов
        public static bool controlsActiveState = false;

        // Поток открытого файла таблицы
        public static System.IO.Stream tablesFile = null;

        // Текущий рабочий лист документа
        public static System.Data.DataTable workTable = null;

        /* 
         * Глобальные параметры приложения
         */

        // Отображение команд в случайном порядке
        public static bool teamsShowInRandomOreder = false;

        // Заменять случайные числа на имена команд
        public static bool replaceRandomNumbersWithTeamNames = false;

        // Отображать полноэкранные формы изначально в оконном режиме
        public static bool fullscrennFormsWindowedDisplay = false;

        // Обновлять полноэкранные формы в реальном времени (нагрузка на CPU)
        public static bool fullscreenFormsRealtimeUpdate = false;

        /*
         * Формы приложения
         */

        // Форма отображения команд
        public static TableDisplay TableDisplay = new();

        // Форма выбора случайного (случайных) победителя
        public static WinnerSelect WinnerSelect = new();

        public static About About = new();

        /*
         * Числовые переменные
         */

        // Текущий дисплей для отображения полноэкранных форм
        public static int currentSelectedDisplay = 0;

        // Максимальное количество победителей в выобре случайного победителя
        public static int maxWinnersCount = 1;

        // Кол-во команд в выборе случайного победителя
        public static int teamsCount = 0;

        public static Font defaultFont = new("Segoe UI", 14.0f, FontStyle.Bold);
        public static float minFontSize = 16.0f;
        public static float maxFontSize = 28.0f;

        public static double complexMultiplier = 1.0;

        /*
         * Текстовые переменные (сообщения, названия кнопок/меток и т.д.)
         */

        public static readonly string openFileButton_openMode = "Открыть таблицу";
        public static readonly string openFileButton_closeMode = "Закрыть таблицу";
        public static readonly string label_currentTableGameName_empty = "Откройте файл, чтобы продолжить";
        public static readonly string textBox_fileName_empty = "Откройте файл, чтобы продолжить";

        #pragma warning restore CA2211
    }
}
