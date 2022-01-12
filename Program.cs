using System;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using Newtonsoft.Json.Linq;

namespace TrainBrainScoreBoard
{
    static class Program
    {
        // ��� ��������� ������ ���������� �������� �� ���, �����
        // ��������� ����� �������� ���������� ��� ������ �������
        public static string CurrentProgrammVersion = "1.2.4";

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

            try
            {
                WebClient wc = new();
                wc.Headers.Add("user-agent", "request");

                JObject json = JObject.Parse(wc.DownloadString("https://api.github.com/repos/re-knownout/train-brain-scoreboard/releases/latest"));
                LatestProgrammVersion = json["tag_name"].ToString().Replace("v", "");
                UpdateDownloadURL = json["assets"][0]["browser_download_url"].ToString();

                if (CurrentProgrammVersion == LatestProgrammVersion) Application.Run(new MainForm());
                else Application.Run(new AppUpdater());
            } catch (Exception) { Application.Run(new MainForm()); }
        }
    }

    /**
     * ��������� ������ ����������
     * 
     * ��������! �� ��������� ������ ������ ����� �����, 
     * ��� ��������� ������ ���������� ����������
     */
    public static class Storage
    {
        #pragma warning disable CA2211

        // ��������� ����������� ���������
        public static bool controlsActiveState = false;

        // ����� ��������� ����� �������
        public static System.IO.Stream tablesFile = null;

        // ������� ������� ���� ���������
        public static System.Data.DataTable workTable = null;

        public static bool showTableHeaders = true;

        /* 
         * ���������� ��������� ����������
         */

        // ����������� ������ � ��������� �������
        public static bool teamsShowInRandomOreder = false;

        // �������� ��������� ����� �� ����� ������
        public static bool replaceRandomNumbersWithTeamNames = false;

        // ���������� ������������� ����� ���������� � ������� ������
        public static bool fullscrennFormsWindowedDisplay = false;

        // ��������� ������������� ����� � �������� ������� (�������� �� CPU)
        public static bool fullscreenFormsRealtimeUpdate = false;

        /*
         * ����� ����������
         */

        // ����� ����������� ������
        public static TableDisplay TableDisplay = new();

        // ����� ������ ���������� (���������) ����������
        public static WinnerSelect WinnerSelect = new();

        public static About About = new();

        /*
         * �������� ����������
         */

        // ������� ������� ��� ����������� ������������� ����
        public static int currentSelectedDisplay = 0;

        // ������������ ���������� ����������� � ������ ���������� ����������
        public static int maxWinnersCount = 1;

        // ���-�� ������ � ������ ���������� ����������
        public static int teamsCount = 0;

        public static Font defaultFont = new("Segoe UI", 14.0f, FontStyle.Bold);
        public static float minFontSize = 16.0f;
        public static float maxFontSize = 28.0f;

        public static double complexMultiplier = 1.0;

        /*
         * ��������� ���������� (���������, �������� ������/����� � �.�.)
         */

        public static readonly string openFileButton_openMode = "������� �������";
        public static readonly string openFileButton_closeMode = "������� �������";
        public static readonly string label_currentTableGameName_empty = "�������� ����, ����� ����������";
        public static readonly string textBox_fileName_empty = "�������� ����, ����� ����������";

        #pragma warning restore CA2211
    }
}
