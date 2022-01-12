﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TrainBrainScoreBoard
{
    public partial class TableDisplay : Form
    {
        #pragma warning disable CA2211

        public static int teamShowIndex = 0;
        List<int> randomOrder_shownIndexes = new();
        Random rand = new();

        // Стандартный шрифт

        // Стандартная белая кисть
        private readonly SolidBrush whiteBrush = new(Color.White);

        #pragma warning restore CA2211

        public TableDisplay()
        {
            InitializeComponent();

            DoubleBuffered = true;

            /**
             * Процедура отрисовки элемента данных таблицы команд
             */
            Func<bool> redrawTableEntries = () =>
            {
                Refresh();
                for (int i = 0; i < teamShowIndex; i++)
                    DrawTableEntries(CreateGraphics(), getRelativeWidth(Width), i);

                return true;
            };

            /**
             * Добавление обработчиков событий
             */

            KeyPress += (s, e) => { if (e.KeyChar == (char)Keys.Escape) Close(); };
            FormClosing += (s, e) =>  { e.Cancel = true; teamShowIndex = 0; randomOrder_shownIndexes = new(); Hide(); };
            Shown += (e, s) => { teamShowIndex = 0; randomOrder_shownIndexes = new(); };
            ResizeEnd += (e, s) => redrawTableEntries();

            Resize += (e, s) =>
            {
                if (Storage.fullscreenFormsRealtimeUpdate) redrawTableEntries();
            };
        }

        /**
         * Метод отрисовки градиента и названия текущей игры
         */
        private void GradientPanelPaint(object sender, PaintEventArgs e)
        {
            // Отрисовка градиента как фона панели
            /*System.Drawing.Drawing2D.LinearGradientBrush linearGradientBrush = new(new Point(0, 0), new Point(e.ClipRectangle.Width, e.ClipRectangle.Height), 
                Color.FromArgb(255, 27, 27, 39), 
                Color.FromArgb(255, 112, 18, 19));

            e.Graphics.FillRectangle(linearGradientBrush, new Rectangle(0, 0, e.ClipRectangle.Width, e.ClipRectangle.Height));*/

            // Отрисовка текста названия текущей игры
            StringFormat format = new();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.DrawString(
                Storage.workTable.Rows[0].ItemArray[0].ToString(),
                new Font("Comfortaa", 40.0f, FontStyle.Bold),
                new SolidBrush(Color.White),
                new Rectangle(0, 0, e.ClipRectangle.Width, e.ClipRectangle.Height), 
                format
            );
        }

        /**
         * Отрисовка ячеек таблицы и заголовка на форме
         */
        private void FormPaint(object sender, PaintEventArgs e)
        {
            tableHeaderPanel.Visible = Storage.showTableHeaders;
            // Общее кол-во строк таблицы
            int totalRows = Storage.workTable.Rows.Count - (!Storage.showTableHeaders ? 2 : 1);

            double rawRowHeight = (ClientRectangle.Height - gradientPanel.Height) / totalRows;

            // Высота одной строки
            int rowHeight = (int)Math.Round(rawRowHeight, MidpointRounding.AwayFromZero);

            // Измененме высоты заголовка таблицы
            tableHeaderPanel.Height = rowHeight;

            // Создание кистей
            SolidBrush darkTransparentBrush = new(Color.FromArgb(158, 190, 231));
            SolidBrush whiteBrush = new(Color.FromArgb(208, 225, 255));

            // Отрисовка ячеек
            for(int i = (!Storage.showTableHeaders ? 0 : 1); i < totalRows; i++)
            {
                int relativeHeight = tableHeaderPanel.Height + gradientPanel.Height + (rowHeight * (i - 1));
                int h = rowHeight;
                if (i == totalRows - 1) h = Height - relativeHeight;

                e.Graphics.FillRectangle(i % 2 == 0 ? darkTransparentBrush : whiteBrush, new Rectangle(0, relativeHeight, Width, h));
            }
        }

        /**
         * Метод отрисовки заголовков таблицы
         */
        private void TableHeaderPaint(object sender, PaintEventArgs e)
        {
            if (!Storage.showTableHeaders) return;

            List<int> relative = getRelativeWidth(Width);
            Font font = Storage.defaultFont;

            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            StringFormat format = new();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            e.Graphics.DrawString("Команды", new Font("Comfortaa", font.Size + 10, FontStyle.Bold), whiteBrush, new RectangleF(0, 0, relative[2], e.ClipRectangle.Height), format);

            for (int i = 0; i < relative[1]; i++)
                e.Graphics.DrawString($"{i + 1}", new Font("Comfortaa", font.Size + 10, FontStyle.Bold), whiteBrush, new RectangleF(relative[2] + (relative[0] * i), 0, relative[0], e.ClipRectangle.Height), format);

            e.Graphics.DrawString("Баллы", new Font("Comfortaa", font.Size + 10, FontStyle.Bold), whiteBrush, new RectangleF(e.ClipRectangle.Width - relative[3] * 3, 0, relative[3], e.ClipRectangle.Height), format);
            e.Graphics.DrawString("Слжн", new Font("Comfortaa", font.Size + 10, FontStyle.Bold), whiteBrush, new RectangleF(e.ClipRectangle.Width - relative[3] * 2, 0, relative[3], e.ClipRectangle.Height), format);
            e.Graphics.DrawString("Место", new Font("Comfortaa", font.Size + 10, FontStyle.Bold), whiteBrush, new RectangleF(e.ClipRectangle.Width - relative[3], 0, relative[3], e.ClipRectangle.Height), format);
        }

        /**
         * Метод для получения ширины строк таблицы команд
         */
        private List<int> getRelativeWidth (int totalWidth)
        {
            // Контейнер значений ширины элементов
            List<int> relativeWidth;

            // Ширина строки (для строк с числами)
            int numericRowWidth = (int)Math.Round(totalWidth * 0.05);

            // Общее количество строк (для строк с числами)
            int totalNumericRows = Storage.workTable.Columns.Count - 2;

            // Оставшееся свободное место
            int freeSpace = totalWidth - totalNumericRows * numericRowWidth;

            // Ширина строки названия команд
            int teamsNameWidth = (int)Math.Round(freeSpace * 0.5);

            // Ширина для двух оставшихся строк
            int placeWidth = (int)Math.Round(((freeSpace - teamsNameWidth) * 1.0) * 0.333);

            relativeWidth = new List<int>() { 
                numericRowWidth,
                totalNumericRows,
                teamsNameWidth,
                placeWidth
            };

            return relativeWidth;
        }

        /**
         * Обработчик события нажатия на кнопку
         */
        private void KeyDownEventHandler(object sender, KeyEventArgs e)
        {
            List<int> relative = getRelativeWidth(Width);

            switch (e.KeyCode)
            {
                // Если нажата клавиша F11, изменить состояние окна
                case Keys.F11:
                    bool sizableState = Storage.TableDisplay.FormBorderStyle == FormBorderStyle.Sizable;

                    Storage.TableDisplay.FormBorderStyle = sizableState ? FormBorderStyle.None : FormBorderStyle.Sizable;
                    Storage.TableDisplay.WindowState = sizableState ? FormWindowState.Maximized : FormWindowState.Normal;

                    Refresh();
                    for (int i = 0; i < teamShowIndex; i++) DrawTableEntries(CreateGraphics(), getRelativeWidth(Width), i);

                    break;

                // Отобразить следующую команду
                case Keys.Up:
                    if(Storage.teamsShowInRandomOreder)
                    {
                        if (randomOrder_shownIndexes.Count >= Storage.workTable.Rows.Count - 1) break;
                        int res = rand.Next(0, Storage.workTable.Rows.Count - 1);

                        while (randomOrder_shownIndexes.Contains(res))
                            res = rand.Next(0, Storage.workTable.Rows.Count - 1);

                        DrawTableEntries(CreateGraphics(), relative, res);
                        randomOrder_shownIndexes.Add(res);

                        break;
                    }

                    if (teamShowIndex == Storage.workTable.Rows.Count - 2) break;
                    DrawTableEntries(CreateGraphics(), relative, teamShowIndex);
                    teamShowIndex += 1;

                    break;

                // Скрыть отображенную команду (шаг назад)
                case Keys.Down:
                    if (Storage.teamsShowInRandomOreder)
                    {
                        if (randomOrder_shownIndexes.Count == 0) break;
                        Refresh();
                        randomOrder_shownIndexes.RemoveAt(randomOrder_shownIndexes.Count - 1);
                        foreach (int index in randomOrder_shownIndexes)
                            DrawTableEntries(CreateGraphics(), relative, index);

                        break;
                    }

                    if (teamShowIndex == 0) break;
                    teamShowIndex -= 1;
                    Refresh();
                    for (int i = 0; i < teamShowIndex; i++) 
                        DrawTableEntries(CreateGraphics(), relative, i);

                    break;
            }
        }

        /**
         * Метод отрисовки данных таблицы для каждой команды
         */
        private void DrawTableEntries (Graphics g, List<int> relative, int index)
        {
            // Общее кол-во строк таблицы
            int totalRows = Storage.workTable.Rows.Count - (!Storage.showTableHeaders ? 2 : 1);

            double rawRowHeight = (ClientRectangle.Height - gradientPanel.Height) / totalRows;

            // Высота одной строки
            int rowHeight = (int)Math.Round(rawRowHeight, MidpointRounding.AwayFromZero);

            int totalTeams = Storage.workTable.Rows.Count - 2;
            Font font = Storage.defaultFont;

            int relativeTeamIndex = totalTeams - index;
            if (relativeTeamIndex <= 0 || relativeTeamIndex > totalTeams) return;

            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            StringFormat formatTeams = new StringFormat();
            formatTeams.LineAlignment = StringAlignment.Center;
            formatTeams.Alignment = StringAlignment.Near;

            int yStartPoint = (rowHeight + gradientPanel.Height + rowHeight * relativeTeamIndex) - rowHeight * (!Storage.showTableHeaders ? 2 : 1);
            SolidBrush brush = new SolidBrush(Color.Black);

            // Отрисовка названия команды
            g.DrawString(
                Storage.workTable.Rows[relativeTeamIndex].ItemArray[0].ToString(),
                new Font("Comfortaa", font.Size + 15, FontStyle.Bold), brush, new Rectangle(20, yStartPoint, relative[2], tableHeaderPanel.Height),
                formatTeams
            );

            // Отрисовка числовых значений
            for (int i = 0; i < Storage.workTable.Columns.Count - 2; i++)
            {
                g.DrawString(
                    Storage.workTable.Rows[relativeTeamIndex].ItemArray[1 + i].ToString(), new Font("Comfortaa", font.Size + 5, FontStyle.Regular),
                    brush, new Rectangle(relative[2] + relative[0] * i, yStartPoint, relative[0], rowHeight), format
                );
            }

            // Отрисовка очков
            g.DrawString(
                Storage.workTable.Rows[relativeTeamIndex].ItemArray[Storage.workTable.Columns.Count - 1].ToString(),
                new Font("Comfortaa", font.Size + 5, FontStyle.Regular), brush,
                new Rectangle((Width - relative[3] * 3), yStartPoint, relative[3], rowHeight),
                format
            );

            g.DrawString(
                Math.Round(double.Parse(Storage.workTable.Rows[relativeTeamIndex].ItemArray[Storage.workTable.Columns.Count - 1].ToString()) *
                Storage.complexMultiplier, 1).ToString(),
                new Font("Comfortaa", font.Size + 5, FontStyle.Regular), brush,
                new Rectangle((Width - relative[3] * 2), yStartPoint, relative[3], rowHeight),
                format
            );

            Font placeFont = new(font, FontStyle.Bold);
            SolidBrush bgBrush = new(Color.Red);

            if (totalTeams - index <= 3)
            {
                g.FillRectangle(bgBrush, new Rectangle((Width - relative[3]), yStartPoint, relative[3], rowHeight));
            }

            // Отрисовка места
            g.DrawString(
                relativeTeamIndex.ToString(), new Font("Comfortaa", font.Size + 5, FontStyle.Bold), brush,
                new Rectangle((Width - relative[3]), yStartPoint, relative[3], rowHeight),
                format
            );
        }
    }
}
