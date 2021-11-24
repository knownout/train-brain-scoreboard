using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TrainBrainScoreBoard
{
    public partial class WinnerSelect : Form
    {
        // Таймер обновления случайного числа
        private Timer numberTickTimer;

        // Текущее состояние таймера
        private bool numberTickTimerState = false;

        // Текущая итерация формы
        private int currentIteration = 0;

        // Исключения из генератора случайных чисел (для выбора нескольких победителей)
        private List<int> exceptFromRandomGenerator;

        private static readonly Random rand = new();

        public WinnerSelect()
        {
            InitializeComponent();

            DoubleBuffered = true;

            numberLabel.Visible = false;
            winnerText.Visible = false;

            numberLabel.Tag = 0;

            exceptFromRandomGenerator = new();

            numberTickTimer = new Timer()
            {
                Enabled = false,

                // Время между тиками таймера в миллисекундах
                Interval = 150
            };

            // Функция генерации случайных чисел на каждый тик таймера
            numberTickTimer.Tick += (object sender, EventArgs e) =>
            {
                int nextVal = rand.Next(1, Storage.teamsCount + 1);

                while (nextVal == int.Parse(numberLabel.Tag.ToString()) || exceptFromRandomGenerator.Contains(nextVal))
                    nextVal = rand.Next(1, Storage.teamsCount + 1);

                if(Storage.replaceRandomNumbersWithTeamNames)
                {
                    numberLabel.Text = Storage.workTable.Rows[nextVal].ItemArray[0].ToString();
                } else numberLabel.Text = nextVal.ToString();

                numberLabel.Tag = nextVal;
            };

            KeyPress += (s, e) => { if (e.KeyChar == (char)Keys.Escape) Close(); };
        }

        private void WinnerSelect_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Отмена нативного события
            e.Cancel = true;

            // Сброс значений
            currentIteration = 0;
            numberTickTimerState = false;
            numberTickTimer.Stop();
            exceptFromRandomGenerator = new();

            numberLabel.Visible = false;
            winnerText.Visible = false;

            // Сокрытие формы
            Hide();
        }

        /**
         * Обработчик события нажатия на кнопку
         */
        private void WinnerSelect_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (Storage.maxWinnersCount <= currentIteration) break;
                    if (numberTickTimerState)
                    {
                        numberTickTimer.Stop();
                        winnerText.Visible = true;
                        numberTickTimerState = false;

                        if (Storage.maxWinnersCount > currentIteration)
                        {
                            exceptFromRandomGenerator.Add(int.Parse(numberLabel.Tag.ToString()));
                            currentIteration += 1;
                        }

                        break;
                    }

                    numberLabel.Visible = true;
                    winnerText.Visible = false;

                    numberTickTimer.Stop();
                    numberTickTimer.Start();
                    numberTickTimerState = true;

                    break;

                // Если нажата клавиша F11, изменить состояние окна
                case Keys.F11:
                    bool sizableState = Storage.WinnerSelect.FormBorderStyle == FormBorderStyle.Sizable;

                    Storage.WinnerSelect.FormBorderStyle = sizableState ? FormBorderStyle.None : FormBorderStyle.Sizable;
                    Storage.WinnerSelect.WindowState = sizableState ? FormWindowState.Maximized : FormWindowState.Normal;

                    Refresh();
                    break;
            }
        }

        /**
         * Обновление размера шрифта для разных типов отображения
         */
        private void WinnerSelect_VisibleChanged(object sender, EventArgs e)
        {
            if (Storage.replaceRandomNumbersWithTeamNames)
                numberLabel.Font = new System.Drawing.Font(numberLabel.Font.FontFamily, 64.0f, numberLabel.Font.Style);
        }
    }
}
