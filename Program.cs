using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;

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

    public class Storage
    {
        public static bool controlsActiveState = false;
        public static System.IO.Stream tablesFile = null;

        public static System.Data.DataTable workTable = null;

        public static bool tableOpen_randomOrder = false;
        public static bool windowMode_display = false;
        public static bool realTime_update = false;
        public static bool replaceNum_withName = false;

        public static Form TableDisplay = new TableDisplay();
        public static Form WinnerSelect = new WinnerSelect();

        public static int selectedMonitor = 0;

        public static int winners_max = 1;
        public static int winners_total = 0;

        public static readonly string buttonOpen_openText = "Открыть таблицу";
        public static readonly string buttonOpen_closeText = "Закрыть таблицу";
        public static readonly string textBox_filePath_none = "Откройте файл, чтобы продолжить";

        public static readonly string label_gameData_none = "Откройте файл, чтобы продолжить";
    }
}
