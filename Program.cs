using System;
using System.Windows.Forms;

namespace TrainBrainScoreBoard
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
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
        public static Form TableDisplay = new TableDisplay();

        // Форма выбора случайного (случайных) победителя
        public static Form WinnerSelect = new WinnerSelect();

        /*
         * Числовые переменные
         */

        // Текущий дисплей для отображения полноэкранных форм
        public static int currentSelectedDisplay = 0;

        // Максимальное количество победителей в выобре случайного победителя
        public static int maxWinnersCount = 1;

        // Кол-во команд в выборе случайного победителя
        public static int teamsCount = 0;

        public static float fontSize = 14.0f;

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
