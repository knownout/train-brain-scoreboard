using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainBrainScoreBoard
{
    public partial class TableDisplay : Form
    {
        public static int teamShowIndex = 0;
        private Font font = new("Segoe UI", 14.0f, FontStyle.Bold);
        private SolidBrush whiteBrush = new SolidBrush(Color.White);
        List<int> randomOrder_shownIndexes = new();

        public TableDisplay()
        {
            InitializeComponent();
            DoubleBuffered = true;

            SetStyle(ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true
            );

            KeyPress += (s, e) => { if (e.KeyChar == (char)Keys.Escape) Close(); };
            FormClosing += (s, e) =>
            {
                e.Cancel = true;
                teamShowIndex = 0;
                Hide();
            };
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.LinearGradientBrush linearGradientBrush = new(new Point(0, 0), new Point(e.ClipRectangle.Width, e.ClipRectangle.Height), 
                Color.FromArgb(255, 27, 27, 39), 
                Color.FromArgb(255, 112, 18, 19));

            e.Graphics.FillRectangle(linearGradientBrush, new Rectangle(0, 0, e.ClipRectangle.Width, e.ClipRectangle.Height));

            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.DrawString(
                Storage.workTable.Rows[0].ItemArray[0].ToString(),
                new Font("Segoe UI", 28.0f, FontStyle.Bold),
                new SolidBrush(Color.White),
                new Rectangle(0, 0, e.ClipRectangle.Width, e.ClipRectangle.Height), 
                format
            );
        }

        private void TableDisplay_Paint(object sender, PaintEventArgs e)
        {
            int totalRows = Storage.workTable.Rows.Count;

            double rawRowHeight = (ClientRectangle.Height - panel2.Height) / totalRows;
            int rowHeight = (int)Math.Round(rawRowHeight, MidpointRounding.AwayFromZero);

            panel1.Height = rowHeight;

            var darkBrush = new SolidBrush(Color.FromArgb(10, 10, 10, 10));
            var whiteBrush = new SolidBrush(Color.White);

            //e.Graphics.FillRectangle(whiteBrush, new Rectangle(0, 0, e.ClipRectangle.Width, e.ClipRectangle.Height));
            for(int i = 1; i < totalRows; i++)
            {
                int relativeHeight = panel1.Height + panel2.Height + (rowHeight * (i - 1));
                int h = rowHeight;
                if (i == totalRows - 1) h = Height - relativeHeight;

                e.Graphics.FillRectangle(i % 2 == 0 ? darkBrush : whiteBrush, new Rectangle(0, relativeHeight, Width, h));
            }
        }

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
            int placeWidth = (int)Math.Round(freeSpace * 0.25);

            relativeWidth = new List<int>() { 
                numericRowWidth,
                totalNumericRows,
                teamsNameWidth,
                placeWidth
            };

            return relativeWidth;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            List<int> relative = getRelativeWidth(Width);

            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            e.Graphics.DrawString("Команды", font, whiteBrush, new RectangleF(0, 0, relative[2], e.ClipRectangle.Height), format);

            for(int i = 0; i < relative[1]; i++)
                e.Graphics.DrawString($"{i + 1}", font, whiteBrush, new RectangleF(relative[2] + (relative[0] * i), 0, relative[0], e.ClipRectangle.Height), format);

            e.Graphics.DrawString("Очки", font, whiteBrush, new RectangleF(e.ClipRectangle.Width - relative[3] * 2, 0, relative[3], e.ClipRectangle.Height), format);
            e.Graphics.DrawString("Место", font, whiteBrush, new RectangleF(e.ClipRectangle.Width - relative[3], 0, relative[3], e.ClipRectangle.Height), format);
        }

        private void TableDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            List<int> relative = getRelativeWidth(Width);
            Random rand = new Random();

            switch (e.KeyCode)
            {
                case Keys.F11:
                    bool sizableState = Storage.TableDisplay.FormBorderStyle == FormBorderStyle.Sizable;

                    Storage.TableDisplay.FormBorderStyle = sizableState ? FormBorderStyle.None : FormBorderStyle.Sizable;
                    Storage.TableDisplay.WindowState = sizableState ? FormWindowState.Maximized : FormWindowState.Normal;

                    Refresh();
                    for (int i = 0; i < teamShowIndex; i++) drawFormData(CreateGraphics(), getRelativeWidth(Width), i);
                    break;

                case Keys.Up:
                    if(Storage.tableOpen_randomOrder)
                    {
                        if (randomOrder_shownIndexes.Count >= Storage.workTable.Rows.Count) break;
                        int res = rand.Next(0, Storage.workTable.Rows.Count);

                        while (randomOrder_shownIndexes.Contains(res))
                            res = rand.Next(0, Storage.workTable.Rows.Count);

                        drawFormData(g, relative, res);
                        randomOrder_shownIndexes.Add(res);
                        break;
                    }

                    if (teamShowIndex == Storage.workTable.Rows.Count - 1) break;
                    drawFormData(g, relative, teamShowIndex);
                    teamShowIndex += 1;
                    break;

                case Keys.Down:
                    if (Storage.tableOpen_randomOrder)
                    {
                        if (randomOrder_shownIndexes.Count == 0) break;
                        Refresh();
                        randomOrder_shownIndexes.RemoveAt(randomOrder_shownIndexes.Count - 1);
                        foreach (int index in this.randomOrder_shownIndexes)
                            drawFormData(g, relative, index);

                        break;
                    }

                    if (teamShowIndex == 0) break;
                    teamShowIndex -= 1;
                    Refresh();
                    for (int i = 0; i < teamShowIndex; i++) drawFormData(g, relative, i);
                    break;
            }
        }

        private void drawFormData (Graphics g, List<int> relative, int index)
        {
            int totalTeams = Storage.workTable.Rows.Count - 1;

            int relativeTeamIndex = totalTeams - index;
            if (relativeTeamIndex <= 0 || relativeTeamIndex > totalTeams) return;

            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            int yStartPoint = (panel1.Height + panel2.Height + panel1.Height * relativeTeamIndex) - panel1.Height;
            SolidBrush brush = new SolidBrush(Color.Black);

            g.DrawString(
                Storage.workTable.Rows[relativeTeamIndex].ItemArray[0].ToString(), font, brush, new Rectangle(0, yStartPoint, relative[2], panel1.Height), format
            );

            for (int i = 0; i < Storage.workTable.Columns.Count - 2; i++)
            {
                g.DrawString(
                    Storage.workTable.Rows[relativeTeamIndex].ItemArray[1 + i].ToString(), new Font(font.FontFamily, font.Size, FontStyle.Regular),
                    brush, new Rectangle(relative[2] + relative[0] * i, yStartPoint, relative[0], panel1.Height), format
                );
            }

            g.DrawString(
                Storage.workTable.Rows[relativeTeamIndex].ItemArray[Storage.workTable.Columns.Count - 1].ToString(),
                new Font(font.FontFamily, font.Size, FontStyle.Regular), brush,
                new Rectangle((Width - relative[3] * 2), yStartPoint, relative[3], panel1.Height),
                format
            );

            g.DrawString(
                relativeTeamIndex.ToString(), font, brush,
                new Rectangle((Width - relative[3]), yStartPoint, relative[3], panel1.Height),
                format
            );
        }

        private void TableDisplay_Shown(object sender, EventArgs e)
        {
            TableDisplay.teamShowIndex = 0;
            this.randomOrder_shownIndexes = new();
        }

        private void TableDisplay_ResizeEnd(object sender, EventArgs e)
        {
            Refresh();
            List<int> relative = getRelativeWidth(Width);
            for (int i = 0; i < TableDisplay.teamShowIndex; i++)
            {
                drawFormData(CreateGraphics(), relative, i);
            }

        }

        private void TableDisplay_Resize(object sender, EventArgs e)
        {
            if (!Storage.realTime_update) return;

            Refresh();
            List<int> relative = getRelativeWidth(Width);
            for (int i = 0; i < TableDisplay.teamShowIndex; i++)
            {
                drawFormData(CreateGraphics(), relative, i);
            }
        }
    }
}
