using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
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

            button_openTableFile.Text = Storage.openFileButton_openMode;

            label_selectedTableGameName.ForeColor = Color.Gray;

            Storage.maxWinnersCount = (int)Math.Round(numberSelect_totalWinnersCount.Value);

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

            // Обработчик события изменения состояния переменной вывода команд в случайном порядке
            checkBox_teamsSelectRandomOrder.CheckedChanged += (s, e) =>
            {
                Storage.teamsShowInRandomOreder = checkBox_teamsSelectRandomOrder.Checked;
                Storage.TableDisplay.Refresh();
                TableDisplay.teamShowIndex = 0;
            };

            // Обработчик события клика по кнопке открытия таблицы команд
            button_showTeamsTable.Click += (s, e) =>
            {
                if (Storage.fullscrennFormsWindowedDisplay) Storage.TableDisplay.FormBorderStyle = FormBorderStyle.Sizable;
                else Storage.TableDisplay.FormBorderStyle = FormBorderStyle.None;

                Storage.TableDisplay.WindowState = FormWindowState.Minimized;
                Storage.TableDisplay.Location = Screen.AllScreens[Storage.currentSelectedDisplay].WorkingArea.Location;

                Storage.TableDisplay.Show();

                Storage.TableDisplay.WindowState = FormWindowState.Normal;
                Storage.TableDisplay.WindowState = FormWindowState.Maximized;
            };

            // Обработчики изменения глобальных параметров приложения
            checkBox_fullscreenFormsWindowedDisplay.CheckedChanged += (s, e) => 
                Storage.fullscrennFormsWindowedDisplay = checkBox_fullscreenFormsWindowedDisplay.Checked;

            checkBox_changeFullscreenFormsRealtimeUpdate.CheckedChanged += (s, e) => 
                Storage.fullscreenFormsRealtimeUpdate = checkBox_changeFullscreenFormsRealtimeUpdate.Checked;

            comboBox_displayMonitorSelect.SelectedIndexChanged += (s, e) => 
                Storage.currentSelectedDisplay = comboBox_displayMonitorSelect.SelectedIndex;

            checkBox_replaceNumberWithTeamName.CheckedChanged += (s, e) =>
            {
                Storage.replaceRandomNumbersWithTeamNames = checkBox_replaceNumberWithTeamName.Checked;
                numberSelect_totalTeams.Enabled = !checkBox_replaceNumberWithTeamName.Checked;

                Storage.teamsCount = checkBox_replaceNumberWithTeamName.Checked
                    ? (Storage.workTable.Rows.Count - 2)
                    : (int)Math.Round(numberSelect_totalTeams.Value);
            };

            // Обработчики изменений данных для генератора случайных чисел
            numberSelect_totalTeams.ValueChanged += (s, e) => Storage.teamsCount = (int)Math.Round(numberSelect_totalTeams.Value);
            numberSelect_totalWinnersCount.ValueChanged += (s, e) => 
                Storage.maxWinnersCount = (int)Math.Round(numberSelect_totalWinnersCount.Value);
        }
        
        /**
         * Метод для частичной повторной инициализации (сброса параметров)
         * главной формы и хранилища данных
         */
        private void ReinitializeFormState ()
        {
            button_openTableFile.Text = Storage.openFileButton_openMode;

            textBox_filePath.Text = Storage.textBox_fileName_empty;

            label_teamsCount.Text = "N/a";

            label_selectedTableGameName.Text = Storage.label_currentTableGameName_empty;
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
                /*
                 * ВНИМАНИЕ! В данный момент в работу берется последний лист документа
                 */

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

                // Добавление последней таблицы в хранилище
                Storage.workTable = dataSet.Tables[dataSet.Tables.Count - 1];
                float fontSize = (14.0f * 2) / ((Storage.workTable.Rows.Count - 2) / 4);

                Storage.defaultFont = new Font(Storage.defaultFont.FontFamily, fontSize > Storage.maxFontSize 
                    ? Storage.maxFontSize 
                    : (fontSize < Storage.minFontSize ? Storage.minFontSize : fontSize), 
                Storage.defaultFont.Style);

                Storage.complexMultiplier = double.Parse(Storage.workTable.Rows[Storage.workTable.Rows.Count - 1].ItemArray[0].ToString());

                // Обновление кнопок и меток
                button_openTableFile.Text = Storage.openFileButton_closeMode;
                textBox_filePath.Text = openFileDialog.FileName;

                // Обновление состояния управляющих элементов
                Storage.controlsActiveState = true;
                UpdateControlsState();

                // Изменение меток
                label_teamsCount.Text = (Storage.workTable.Rows.Count - 2).ToString();
                label_selectedTableGameName.Text = Storage.workTable.Rows[0].ItemArray[0].ToString();
                label_selectedTableGameName.ForeColor = Color.DarkGreen;

                // Изменение начального значения количества команд
                numberSelect_totalTeams.Value = (Storage.workTable.Rows.Count - 2);

                // Завершения процедуры чтения из файла (файл остается открытым)
                excelDataReader.Close();
            }
            catch (Exception exception)
            {
                // След ошибки
                var stackTraceArray = exception.StackTrace.Split("\n");

                // Последний след ошибки
                var lastTrace = stackTraceArray[stackTraceArray.Length - 1];

                // Дополнительная локализованная информация по ошибке
                var messageInfo = "";
                if (exception.Message.Contains("The process cannot access the file"))
                    messageInfo = ": файл занят другим процессом";

                // Обновление потока в хранилище
                if (Storage.tablesFile != null) Storage.tablesFile = null;
                Storage.controlsActiveState = false;

                ReinitializeFormState();
                
                // Вывод отформатированного сообщения
                MessageBox.Show("Ошибка чтения файла" + messageInfo + "\n\n" + exception.Message + "\n\n"
                    + lastTrace, "Ошибка чтения файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /**
         * Метод обработки нажатия пользователем
         * на кнопку выбора случайного победителя
         */
        private void SelectWinnersButton_ClickHandler(object sender, EventArgs e)
        {
            // Обновление типа границы окна
            Storage.WinnerSelect.FormBorderStyle = Storage.fullscrennFormsWindowedDisplay 
                ? FormBorderStyle.Sizable 
                : FormBorderStyle.None;

            // Перемещение окна на определенный пользователем монитор
            Storage.WinnerSelect.WindowState = FormWindowState.Minimized;
            Storage.WinnerSelect.Location = Screen.AllScreens[Storage.currentSelectedDisplay].WorkingArea.Location;

            Storage.WinnerSelect.Show();

            Storage.WinnerSelect.WindowState = FormWindowState.Normal;
            Storage.WinnerSelect.WindowState = FormWindowState.Maximized;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Storage.About.Show();
        }
    }
}
