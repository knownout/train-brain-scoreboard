using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TrainBrainScoreBoard
{
    public partial class WinnerSelect : Form
    {
        private Timer _timer;
        private bool _timer_state = false;

        private int _iteration = 0;

        private List<int> except;

        public WinnerSelect()
        {
            InitializeComponent();
            numberLabel.Visible = false;
            winnerText.Visible = false;

            DoubleBuffered = true;
            numberLabel.Tag = 0;
            except = new();

            _timer = new Timer()
            {
                Enabled = false,
                Interval = 150
            };

            _timer.Tick += (object sender, EventArgs e) =>
            {
                int nextVal = rand.Next(1, Storage.winners_total + 1);

                while (nextVal == int.Parse(numberLabel.Tag.ToString()) || except.Contains(nextVal))
                    nextVal = rand.Next(1, Storage.winners_total + 1);

                if(Storage.replaceNum_withName)
                {
                    numberLabel.Text = Storage.workTable.Rows[nextVal].ItemArray[0].ToString();
                } else numberLabel.Text = nextVal.ToString();

                numberLabel.Tag = nextVal;
            };
        }

        private void WinnerSelect_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            _iteration = 0;
            _timer_state = false;
            _timer.Stop();
            except = new();

            numberLabel.Visible = false;
            winnerText.Visible = false;

            Hide();
        }

        private void WinnerSelect_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape) Close();
        }


        private static Random rand = new Random();
        private void WinnerSelect_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Up)
            {
                if (Storage.winners_max <= _iteration) return;

                if(_timer_state)
                {
                    _timer.Stop();
                    winnerText.Visible = true;
                    _timer_state = false;

                    if(Storage.winners_max > _iteration)
                    {
                        except.Add(int.Parse(numberLabel.Tag.ToString()));
                        _iteration += 1;
                    }
                } else
                {
                    numberLabel.Visible = true;
                    winnerText.Visible = false;

                    _timer.Stop();
                    _timer.Start();
                    _timer_state = true;
                }
            }
        }

        private void WinnerSelect_VisibleChanged(object sender, EventArgs e)
        {
            if (Storage.replaceNum_withName)
                numberLabel.Font = new System.Drawing.Font(numberLabel.Font.FontFamily, 64.0f, numberLabel.Font.Style);
        }
    }
}
