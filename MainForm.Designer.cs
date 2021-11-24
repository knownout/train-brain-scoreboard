
namespace TrainBrainScoreBoard
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.button_openTableFile = new System.Windows.Forms.Button();
            this.textBox_filePath = new System.Windows.Forms.TextBox();
            this.label_static_teamsCountDescription = new System.Windows.Forms.Label();
            this.label_teamsCount = new System.Windows.Forms.Label();
            this.groupBox_controlsGroup = new System.Windows.Forms.GroupBox();
            this.checkBox_replaceNumberWithTeamName = new System.Windows.Forms.CheckBox();
            this.label_static_f11KeyInfo = new System.Windows.Forms.Label();
            this.label_static_escKeyInfo = new System.Windows.Forms.Label();
            this.label_static_rwsNumberSelectorsDelimiter = new System.Windows.Forms.Label();
            this.label_static_totalWinnersCountLabel = new System.Windows.Forms.Label();
            this.numberSelect_totalWinnersCount = new System.Windows.Forms.NumericUpDown();
            this.label_static_totalTeamsListCountLabel = new System.Windows.Forms.Label();
            this.numberSelect_totalTeams = new System.Windows.Forms.NumericUpDown();
            this.buttons_randomSelectWinners = new System.Windows.Forms.Button();
            this.checkBox_teamsSelectRandomOrder = new System.Windows.Forms.CheckBox();
            this.label_selectedTableGameName = new System.Windows.Forms.Label();
            this.button_showTeamsTable = new System.Windows.Forms.Button();
            this.label_static_selectMonitorLabel = new System.Windows.Forms.Label();
            this.comboBox_displayMonitorSelect = new System.Windows.Forms.ComboBox();
            this.checkBox_fullscreenFormsWindowedDisplay = new System.Windows.Forms.CheckBox();
            this.checkBox_changeFullscreenFormsRealtimeUpdate = new System.Windows.Forms.CheckBox();
            this.label_static_cpuUsageWarning = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox_controlsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberSelect_totalWinnersCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberSelect_totalTeams)).BeginInit();
            this.SuspendLayout();
            // 
            // button_openTableFile
            // 
            this.button_openTableFile.Location = new System.Drawing.Point(12, 11);
            this.button_openTableFile.Name = "button_openTableFile";
            this.button_openTableFile.Size = new System.Drawing.Size(122, 42);
            this.button_openTableFile.TabIndex = 0;
            this.button_openTableFile.Text = "Открыть таблицу";
            this.button_openTableFile.UseVisualStyleBackColor = true;
            this.button_openTableFile.Click += new System.EventHandler(this.OpenFileHandler);
            // 
            // textBox_filePath
            // 
            this.textBox_filePath.Location = new System.Drawing.Point(140, 12);
            this.textBox_filePath.Name = "textBox_filePath";
            this.textBox_filePath.ReadOnly = true;
            this.textBox_filePath.Size = new System.Drawing.Size(313, 23);
            this.textBox_filePath.TabIndex = 1;
            this.textBox_filePath.Text = "Откройте файл, чтобы продолжить";
            this.toolTip.SetToolTip(this.textBox_filePath, "Путь к открытому файлу, поле только\r\nдля чтения. Для обновления файла\r\nиспользуйт" +
        "е кнопку");
            // 
            // label_static_teamsCountDescription
            // 
            this.label_static_teamsCountDescription.AutoSize = true;
            this.label_static_teamsCountDescription.Location = new System.Drawing.Point(140, 38);
            this.label_static_teamsCountDescription.Name = "label_static_teamsCountDescription";
            this.label_static_teamsCountDescription.Size = new System.Drawing.Size(119, 15);
            this.label_static_teamsCountDescription.TabIndex = 2;
            this.label_static_teamsCountDescription.Text = "Количество команд:";
            // 
            // label_teamsCount
            // 
            this.label_teamsCount.AutoSize = true;
            this.label_teamsCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_teamsCount.Location = new System.Drawing.Point(254, 38);
            this.label_teamsCount.Name = "label_teamsCount";
            this.label_teamsCount.Size = new System.Drawing.Size(27, 15);
            this.label_teamsCount.TabIndex = 3;
            this.label_teamsCount.Text = "N/a";
            // 
            // groupBox1
            // 
            this.groupBox_controlsGroup.Controls.Add(this.checkBox_replaceNumberWithTeamName);
            this.groupBox_controlsGroup.Controls.Add(this.label_static_f11KeyInfo);
            this.groupBox_controlsGroup.Controls.Add(this.label_static_escKeyInfo);
            this.groupBox_controlsGroup.Controls.Add(this.label_static_rwsNumberSelectorsDelimiter);
            this.groupBox_controlsGroup.Controls.Add(this.label_static_totalWinnersCountLabel);
            this.groupBox_controlsGroup.Controls.Add(this.numberSelect_totalWinnersCount);
            this.groupBox_controlsGroup.Controls.Add(this.label_static_totalTeamsListCountLabel);
            this.groupBox_controlsGroup.Controls.Add(this.numberSelect_totalTeams);
            this.groupBox_controlsGroup.Controls.Add(this.buttons_randomSelectWinners);
            this.groupBox_controlsGroup.Controls.Add(this.checkBox_teamsSelectRandomOrder);
            this.groupBox_controlsGroup.Controls.Add(this.label_selectedTableGameName);
            this.groupBox_controlsGroup.Controls.Add(this.button_showTeamsTable);
            this.groupBox_controlsGroup.Location = new System.Drawing.Point(12, 182);
            this.groupBox_controlsGroup.Name = "groupBox1";
            this.groupBox_controlsGroup.Size = new System.Drawing.Size(441, 228);
            this.groupBox_controlsGroup.TabIndex = 5;
            this.groupBox_controlsGroup.TabStop = false;
            this.groupBox_controlsGroup.Text = "Управление";
            // 
            // checkBox_replaceNumberWithTeamName
            // 
            this.checkBox_replaceNumberWithTeamName.AutoSize = true;
            this.checkBox_replaceNumberWithTeamName.Location = new System.Drawing.Point(7, 202);
            this.checkBox_replaceNumberWithTeamName.Name = "checkBox_replaceNumberWithTeamName";
            this.checkBox_replaceNumberWithTeamName.Size = new System.Drawing.Size(240, 19);
            this.checkBox_replaceNumberWithTeamName.TabIndex = 16;
            this.checkBox_replaceNumberWithTeamName.Text = "Заменить номер на название команды";
            this.checkBox_replaceNumberWithTeamName.UseVisualStyleBackColor = true;
            // 
            // label_static_f11KeyInfo
            // 
            this.label_static_f11KeyInfo.Location = new System.Drawing.Point(134, 96);
            this.label_static_f11KeyInfo.Name = "label_static_f11KeyInfo";
            this.label_static_f11KeyInfo.Size = new System.Drawing.Size(301, 37);
            this.label_static_f11KeyInfo.TabIndex = 15;
            this.label_static_f11KeyInfo.Text = "Для изменения полноэкранного состояния формы используйте клавишу F11";
            // 
            // label_static_escKeyInfo
            // 
            this.label_static_escKeyInfo.Location = new System.Drawing.Point(134, 59);
            this.label_static_escKeyInfo.Name = "label_static_escKeyInfo";
            this.label_static_escKeyInfo.Size = new System.Drawing.Size(301, 37);
            this.label_static_escKeyInfo.TabIndex = 14;
            this.label_static_escKeyInfo.Text = "Для сокрытия полноэкранных форм используйте клавишу ESC";
            // 
            // label_static_rwsNumberSelectorsDelimiter
            // 
            this.label_static_rwsNumberSelectorsDelimiter.AutoSize = true;
            this.label_static_rwsNumberSelectorsDelimiter.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label_static_rwsNumberSelectorsDelimiter.Location = new System.Drawing.Point(197, 175);
            this.label_static_rwsNumberSelectorsDelimiter.Name = "label_static_rwsNumberSelectorsDelimiter";
            this.label_static_rwsNumberSelectorsDelimiter.Size = new System.Drawing.Size(31, 15);
            this.label_static_rwsNumberSelectorsDelimiter.TabIndex = 13;
            this.label_static_rwsNumberSelectorsDelimiter.Text = "<=>";
            // 
            // label_static_totalWinnersCountLabel
            // 
            this.label_static_totalWinnersCountLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label_static_totalWinnersCountLabel.Location = new System.Drawing.Point(230, 139);
            this.label_static_totalWinnersCountLabel.Name = "label_static_totalWinnersCountLabel";
            this.label_static_totalWinnersCountLabel.Size = new System.Drawing.Size(85, 30);
            this.label_static_totalWinnersCountLabel.TabIndex = 12;
            this.label_static_totalWinnersCountLabel.Text = "Количество победителей";
            // 
            // numberSelect_totalWinnersCount
            // 
            this.numberSelect_totalWinnersCount.Enabled = false;
            this.numberSelect_totalWinnersCount.Location = new System.Drawing.Point(230, 172);
            this.numberSelect_totalWinnersCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberSelect_totalWinnersCount.Name = "numberSelect_totalWinnersCount";
            this.numberSelect_totalWinnersCount.Size = new System.Drawing.Size(61, 23);
            this.numberSelect_totalWinnersCount.TabIndex = 11;
            this.numberSelect_totalWinnersCount.ThousandsSeparator = true;
            this.numberSelect_totalWinnersCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label_static_totalTeamsListCountLabel
            // 
            this.label_static_totalTeamsListCountLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label_static_totalTeamsListCountLabel.Location = new System.Drawing.Point(134, 139);
            this.label_static_totalTeamsListCountLabel.Name = "label_static_totalTeamsListCountLabel";
            this.label_static_totalTeamsListCountLabel.Size = new System.Drawing.Size(75, 30);
            this.label_static_totalTeamsListCountLabel.TabIndex = 10;
            this.label_static_totalTeamsListCountLabel.Text = "Количество участников";
            // 
            // numberSelect_totalTeams
            // 
            this.numberSelect_totalTeams.Enabled = false;
            this.numberSelect_totalTeams.Location = new System.Drawing.Point(134, 172);
            this.numberSelect_totalTeams.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberSelect_totalTeams.Name = "numberSelect_totalTeams";
            this.numberSelect_totalTeams.Size = new System.Drawing.Size(61, 23);
            this.numberSelect_totalTeams.TabIndex = 9;
            this.numberSelect_totalTeams.ThousandsSeparator = true;
            this.numberSelect_totalTeams.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttons_randomSelectWinners
            // 
            this.buttons_randomSelectWinners.Enabled = false;
            this.buttons_randomSelectWinners.Location = new System.Drawing.Point(6, 155);
            this.buttons_randomSelectWinners.Name = "buttons_randomSelectWinners";
            this.buttons_randomSelectWinners.Size = new System.Drawing.Size(122, 41);
            this.buttons_randomSelectWinners.TabIndex = 8;
            this.buttons_randomSelectWinners.Text = "Выбрать победителей";
            this.buttons_randomSelectWinners.UseVisualStyleBackColor = true;
            this.buttons_randomSelectWinners.Click += new System.EventHandler(this.SelectWinnersButton_ClickHandler);
            // 
            // checkBox_teamsSelectRandomOrder
            // 
            this.checkBox_teamsSelectRandomOrder.AutoSize = true;
            this.checkBox_teamsSelectRandomOrder.Enabled = false;
            this.checkBox_teamsSelectRandomOrder.Location = new System.Drawing.Point(134, 37);
            this.checkBox_teamsSelectRandomOrder.Name = "checkBox_teamsSelectRandomOrder";
            this.checkBox_teamsSelectRandomOrder.Size = new System.Drawing.Size(215, 19);
            this.checkBox_teamsSelectRandomOrder.TabIndex = 6;
            this.checkBox_teamsSelectRandomOrder.Text = "Отображать в случайном пордяке";
            this.toolTip.SetToolTip(this.checkBox_teamsSelectRandomOrder, "Если опция включена, команды\r\nбудут отображаться в случайном\r\nпорядке (сортировка" +
        " не изменится)\r\n\r\nВнимание! Переключение опции\r\nпри открытой форме приведет\r\nк п" +
        "ерерисовке формы со\r\nсбросом значений");
            this.checkBox_teamsSelectRandomOrder.UseVisualStyleBackColor = true;
            // 
            // label_selectedTableGameName
            // 
            this.label_selectedTableGameName.AutoSize = true;
            this.label_selectedTableGameName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label_selectedTableGameName.Location = new System.Drawing.Point(6, 19);
            this.label_selectedTableGameName.Name = "label_selectedTableGameName";
            this.label_selectedTableGameName.Size = new System.Drawing.Size(203, 15);
            this.label_selectedTableGameName.TabIndex = 7;
            this.label_selectedTableGameName.Text = "Откройте файл, чтобы продолжить";
            // 
            // button_showTeamsTable
            // 
            this.button_showTeamsTable.Enabled = false;
            this.button_showTeamsTable.Location = new System.Drawing.Point(6, 37);
            this.button_showTeamsTable.Name = "button_showTeamsTable";
            this.button_showTeamsTable.Size = new System.Drawing.Size(122, 41);
            this.button_showTeamsTable.TabIndex = 5;
            this.button_showTeamsTable.Text = "Показать таблицу";
            this.button_showTeamsTable.UseVisualStyleBackColor = true;
            // 
            // label_static_selectMonitorLabel
            // 
            this.label_static_selectMonitorLabel.Location = new System.Drawing.Point(12, 63);
            this.label_static_selectMonitorLabel.Name = "label_static_selectMonitorLabel";
            this.label_static_selectMonitorLabel.Size = new System.Drawing.Size(166, 35);
            this.label_static_selectMonitorLabel.TabIndex = 6;
            this.label_static_selectMonitorLabel.Text = "Монитор для отображения полноэкранных форм";
            // 
            // comboBox1
            // 
            this.comboBox_displayMonitorSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_displayMonitorSelect.FormattingEnabled = true;
            this.comboBox_displayMonitorSelect.Location = new System.Drawing.Point(184, 69);
            this.comboBox_displayMonitorSelect.Name = "comboBox1";
            this.comboBox_displayMonitorSelect.Size = new System.Drawing.Size(269, 23);
            this.comboBox_displayMonitorSelect.TabIndex = 7;
            this.toolTip.SetToolTip(this.comboBox_displayMonitorSelect, "Монитор, на котором будет отображена \r\nследующая открытая полноэкранная форма");
            // 
            // checkBox_fullscreenFormsWindowedDisplay
            // 
            this.checkBox_fullscreenFormsWindowedDisplay.AutoSize = true;
            this.checkBox_fullscreenFormsWindowedDisplay.Location = new System.Drawing.Point(12, 101);
            this.checkBox_fullscreenFormsWindowedDisplay.Name = "checkBox_fullscreenFormsWindowedDisplay";
            this.checkBox_fullscreenFormsWindowedDisplay.Size = new System.Drawing.Size(338, 19);
            this.checkBox_fullscreenFormsWindowedDisplay.TabIndex = 8;
            this.checkBox_fullscreenFormsWindowedDisplay.Text = "Отображать полноэкранные формы в оконном режиме";
            this.toolTip.SetToolTip(this.checkBox_fullscreenFormsWindowedDisplay, "Если опция включена, полноэкранные\r\nформы будут изначально запускаться\r\nв режиме " +
        "окна. В любом случае,\r\nражим отображения формы можно\r\nбудет изменить клавишей F1" +
        "1");
            this.checkBox_fullscreenFormsWindowedDisplay.UseVisualStyleBackColor = true;
            // 
            // checkBox_changeFullscreenFormsRealtimeUpdate
            // 
            this.checkBox_changeFullscreenFormsRealtimeUpdate.AutoSize = true;
            this.checkBox_changeFullscreenFormsRealtimeUpdate.Location = new System.Drawing.Point(12, 126);
            this.checkBox_changeFullscreenFormsRealtimeUpdate.Name = "checkBox_changeFullscreenFormsRealtimeUpdate";
            this.checkBox_changeFullscreenFormsRealtimeUpdate.Size = new System.Drawing.Size(387, 19);
            this.checkBox_changeFullscreenFormsRealtimeUpdate.TabIndex = 9;
            this.checkBox_changeFullscreenFormsRealtimeUpdate.Text = "Обновлять полноэкранные формы во время изменения размера";
            this.toolTip.SetToolTip(this.checkBox_changeFullscreenFormsRealtimeUpdate, resources.GetString("checkBox_changeFullscreenFormsRealtimeUpdate.ToolTip"));
            this.checkBox_changeFullscreenFormsRealtimeUpdate.UseVisualStyleBackColor = true;
            // 
            // label_static_cpuUsageWarning
            // 
            this.label_static_cpuUsageWarning.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_static_cpuUsageWarning.ForeColor = System.Drawing.Color.Red;
            this.label_static_cpuUsageWarning.Location = new System.Drawing.Point(12, 144);
            this.label_static_cpuUsageWarning.Name = "label_static_cpuUsageWarning";
            this.label_static_cpuUsageWarning.Size = new System.Drawing.Size(422, 35);
            this.label_static_cpuUsageWarning.TabIndex = 10;
            this.label_static_cpuUsageWarning.Tag = "";
            this.label_static_cpuUsageWarning.Text = "Включение данной опции приведет к повышенной нагрузке на CPU. Не рекомендуется на" +
    " слишком слабых устройствах *";
            this.toolTip.SetToolTip(this.label_static_cpuUsageWarning, resources.GetString("label_static_cpuUsageWarning.ToolTip"));
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(468, 422);
            this.Controls.Add(this.label_static_cpuUsageWarning);
            this.Controls.Add(this.checkBox_changeFullscreenFormsRealtimeUpdate);
            this.Controls.Add(this.checkBox_fullscreenFormsWindowedDisplay);
            this.Controls.Add(this.comboBox_displayMonitorSelect);
            this.Controls.Add(this.label_static_selectMonitorLabel);
            this.Controls.Add(this.groupBox_controlsGroup);
            this.Controls.Add(this.label_teamsCount);
            this.Controls.Add(this.label_static_teamsCountDescription);
            this.Controls.Add(this.textBox_filePath);
            this.Controls.Add(this.button_openTableFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "TBSB Параметры";
            this.groupBox_controlsGroup.ResumeLayout(false);
            this.groupBox_controlsGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberSelect_totalWinnersCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberSelect_totalTeams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_filePath;

        private System.Windows.Forms.GroupBox groupBox_controlsGroup;

        private System.Windows.Forms.Button button_openTableFile;
        private System.Windows.Forms.Button buttons_randomSelectWinners;
        private System.Windows.Forms.Button button_showTeamsTable;

        private System.Windows.Forms.Label label_static_teamsCountDescription;
        private System.Windows.Forms.Label label_teamsCount;
        private System.Windows.Forms.Label label_selectedTableGameName;

        private System.Windows.Forms.Label label_static_rwsNumberSelectorsDelimiter;
        private System.Windows.Forms.Label label_static_totalWinnersCountLabel;
        private System.Windows.Forms.Label label_static_totalTeamsListCountLabel;
        private System.Windows.Forms.Label label_static_selectMonitorLabel;
        private System.Windows.Forms.Label label_static_escKeyInfo;
        private System.Windows.Forms.Label label_static_cpuUsageWarning;
        private System.Windows.Forms.Label label_static_f11KeyInfo;

        private System.Windows.Forms.NumericUpDown numberSelect_totalTeams;
        private System.Windows.Forms.NumericUpDown numberSelect_totalWinnersCount;

        private System.Windows.Forms.ComboBox comboBox_displayMonitorSelect;

        private System.Windows.Forms.CheckBox checkBox_fullscreenFormsWindowedDisplay;
        private System.Windows.Forms.CheckBox checkBox_changeFullscreenFormsRealtimeUpdate;
        private System.Windows.Forms.CheckBox checkBox_teamsSelectRandomOrder;
        private System.Windows.Forms.CheckBox checkBox_replaceNumberWithTeamName;

        private System.Windows.Forms.ToolTip toolTip;
    }
}

