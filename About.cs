using System.Windows.Forms;

namespace TrainBrainScoreBoard
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();

            label_currentVersion.Text = Program.CurrentProgrammVersion;
            label_lastVersion.Text = Program.LatestProgrammVersion;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", "http://github.com/re-knownout/");
        }

        private void About_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
