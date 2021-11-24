using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ExcelDataReader;

namespace TrainBrainScoreBoard
{
    public partial class MainForm : Form
    {
        /**
         * Метод для обновления состояния элементов
         * управления открытым файлом
         */
        public void UpdateControlsState()
        {
            button_showTeamsTable.Enabled = Storage.controlsActiveState;
            buttons_randomSelectWinners.Enabled = Storage.controlsActiveState;

            checkBox_teamsSelectRandomOrder.Enabled = Storage.controlsActiveState;

            numberSelect_totalWinnersCount.Enabled = Storage.controlsActiveState;
            if (!checkBox_replaceNumberWithTeamName.Checked) numberSelect_totalTeams.Enabled = Storage.controlsActiveState;
            else numberSelect_totalTeams.Enabled = false;

            checkBox_replaceNumberWithTeamName.Enabled = Storage.controlsActiveState;
        }

        public MainForm()
        {
            InitializeComponent();

            // Начальное состояние элементов управления
            Storage.controlsActiveState = false;

            button_openTableFile.Text = Storage.buttonOpen_openText;

            label_selectedTableGameName.ForeColor = Color.Gray;

            Storage.winners_max = (int)Math.Round(numberSelect_totalWinnersCount.Value);

            // Обновление списка мониторов текущей системы
            comboBox_displayMonitorSelect.Items.Clear();
            for (int i = 0; i < Screen.AllScreens.Length; i ++)
            {
                // Получение монитора с определенным индексом и его наименования в системе
                Screen screen = Screen.AllScreens[i];
                string[] deviceNameArray = screen.DeviceName.Split("\\");

                comboBox_displayMonitorSelect.Items.Add(
                    // Название монитора (бел лишних символов)
                    deviceNameArray[deviceNameArray.Length - 1]
                    
                    // Разрешенеие монитора
                    + " (" + screen.Bounds.Width + "x" + screen.Bounds.Height + ")"
                );
            }

            // Изначально выбран первый полученный монитор
            comboBox_displayMonitorSelect.SelectedIndex = 0;

            // Обновление состояния управляющих элементов
            UpdateControlsState();

            /*
             * Добавление событий
             */

            checkBox_teamsSelectRandomOrder.CheckedChanged += (s, e) =>
            {
                Storage.tableOpen_randomOrder = checkBox_teamsSelectRandomOrder.Checked;
                Storage.TableDisplay.Refresh();
                TableDisplay.teamShowIndex = 0;
            };

            button_showTeamsTable.Click += (s, e) =>
            {
                if (Storage.windowMode_display) Storage.TableDisplay.FormBorderStyle = FormBorderStyle.Sizable;
                else Storage.TableDisplay.FormBorderStyle = FormBorderStyle.None;

                Storage.TableDisplay.WindowState = FormWindowState.Minimized;
                Storage.TableDisplay.Location = Screen.AllScreens[Storage.selectedMonitor].WorkingArea.Location;

                Storage.TableDisplay.Show();

                Storage.TableDisplay.WindowState = FormWindowState.Normal;
                Storage.TableDisplay.WindowState = FormWindowState.Maximized;
            };

            checkBox_fullscreenFormsWindowedDisplay.CheckedChanged += (s, e) => Storage.windowMode_display = checkBox_fullscreenFormsWindowedDisplay.Checked;
            checkBox_changeFullscreenFormsRealtimeUpdate.CheckedChanged += (s, e) => Storage.realTime_update = checkBox_changeFullscreenFormsRealtimeUpdate.Checked;

            comboBox_displayMonitorSelect.SelectedIndexChanged += (s, e) => Storage.selectedMonitor = comboBox_displayMonitorSelect.SelectedIndex;

            checkBox_replaceNumberWithTeamName.CheckedChanged += (s, e) =>
            {
                Storage.replaceNum_withName = checkBox_replaceNumberWithTeamName.Checked;
                numberSelect_totalTeams.Enabled = !checkBox_replaceNumberWithTeamName.Checked;

                Storage.winners_total = checkBox_replaceNumberWithTeamName.Checked
                    ? (Storage.workTable.Rows.Count - 1)
                    : (int)Math.Round(numberSelect_totalTeams.Value);
            };
        }
        
        /**
         * Метод для частичной повторной инициализации (сброса параметров)
         * главной формы и хранилища данных
         */
        private void ReinitializeFormState ()
        {
            button_openTableFile.Text = Storage.buttonOpen_openText;

            textBox_filePath.Text = Storage.textBox_filePath_none;

            label_teamsCount.Text = "N/a";

            label_selectedTableGameName.Text = Storage.label_gameData_none;
            label_selectedTableGameName.ForeColor = Color.Gray;

            Storage.tablesFile = null;
            Storage.controlsActiveState = false;
            Storage.workTable = null;

            UpdateControlsState();
        }

        private void OpenFileHandler(object sender, EventArgs e)
        {
            if (Storage.tablesFile != null)
            {
                Storage.tablesFile.Close();

                numberSelect_totalTeams.Value = 1;
                numberSelect_totalWinnersCount.Value = 1;

                ReinitializeFormState();
                Storage.TableDisplay.Hide();
                return;
            }

            OpenFileDialog openFileDialog = new();

            openFileDialog.Filter = "Таблица Microsoft Excel|*.xls*";

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                // Добавление провайдера кодировки (для 1251)
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                // Добавление потока файла таблицы в хранилище
                Storage.tablesFile = openFileDialog.OpenFile();

                // Чтение данных из таблицы
                IExcelDataReader excelDataReader = ExcelReaderFactory.CreateReader(Storage.tablesFile);
                DataSet dataSet = excelDataReader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    UseColumnDataType = true,

                    FilterSheet = (tableReader, sheetIndex) => true,

                    ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                    {
                        EmptyColumnNamePrefix = "Column",
                        UseHeaderRow = false,

                        ReadHeaderRow = (rowReader) => rowReader.Read(),
                        FilterRow = (rowReader) => true,
                        FilterColumn = (rowReader, columnIndex) => true
                    }
                });

                Storage.workTable = dataSet.Tables[dataSet.Tables.Count - 1];

                button_openTableFile.Text = Storage.buttonOpen_closeText;
                textBox_filePath.Text = openFileDialog.FileName;

                Storage.controlsActiveState = true;
                UpdateControlsState();

                label_teamsCount.Text = (Storage.workTable.Rows.Count - 1).ToString();
                label_selectedTableGameName.Text = Storage.workTable.Rows[0].ItemArray[0].ToString();
                label_selectedTableGameName.ForeColor = Color.DarkGreen;
                numberSelect_totalTeams.Value = (Storage.workTable.Rows.Count - 1);

                excelDataReader.Close();
            }
            catch (Exception exception)
            {
                var stackTraceArray = exception.StackTrace.Split("\n");
                var lastTrace = stackTraceArray[stackTraceArray.Length - 1];

                var messageInfo = "";
                if (exception.Message.Contains("The process cannot access the file"))
                    messageInfo = ": файл занят другим процессом";

                if (Storage.tablesFile != null) Storage.tablesFile = null;
                Storage.controlsActiveState = false;
                ReinitializeFormState();

                MessageBox.Show("Ошибка чтения файла" + messageInfo + "\n\n" + exception.Message + "\n\n"
                    + lastTrace, "Ошибка чтения файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SelectWinnersButton_ClickHandler(object sender, EventArgs e)
        {
            if (Storage.windowMode_display) Storage.WinnerSelect.FormBorderStyle = FormBorderStyle.Sizable;
            else Storage.WinnerSelect.FormBorderStyle = FormBorderStyle.None;

            Storage.WinnerSelect.WindowState = FormWindowState.Minimized;
            Storage.WinnerSelect.Location = Screen.AllScreens[Storage.selectedMonitor].WorkingArea.Location;

            Storage.WinnerSelect.Show();

            Storage.WinnerSelect.WindowState = FormWindowState.Normal;
            Storage.WinnerSelect.WindowState = FormWindowState.Maximized;
        }

        private void SelectWinnersTotalTeamsCountSelect_ValueChanged(object sender, EventArgs e)
        {
            Storage.winners_total = (int)Math.Round(numberSelect_totalTeams.Value);
        }

        private void SelectWinnersTotalWinnersCountSelect_ValueChanged(object sender, EventArgs e)
        {
            Storage.winners_max = (int)Math.Round(numberSelect_totalWinnersCount.Value);
        }
    }
}
