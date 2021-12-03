using System.Windows.Forms;
using System.Net;
using System;
using System.IO;
using System.Linq;
using System.IO.Compression;
using System.Diagnostics;

namespace TrainBrainScoreBoard
{
    public partial class AppUpdater : Form
    {
        public AppUpdater()
        {
            InitializeComponent();

            label_CurrentVersion.Text = Program.CurrentProgrammVersion;
            label_LatestVersion.Text = Program.LatestProgrammVersion;
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebClient wc = new();
            wc.Headers.Add("user-agent", "request");

            string zipFileName = RandomString(10);

            wc.DownloadProgressChanged += (s, e) =>
            {
                progressBar1.Value = e.ProgressPercentage;
            };

            wc.DownloadFileCompleted += (s, e) =>
            {
                FileStream fs = new(zipFileName, FileMode.Open);
                ZipArchive zip = new(fs, ZipArchiveMode.Read); ;

                try
                {
                    ZipArchiveExtensions.ExtractToDirectory(zip, "./extract-update", true);
                    StreamWriter sw = new("update.bat");
                    sw.WriteLine(@"timeout 1");
                    sw.WriteLine(@"move /y extract-update\*.* .\");
                    sw.WriteLine(@"rmdir /S /Q extract-update");
                    sw.WriteLine(@"start TrainBrainScoreBoard.exe");

                    sw.Close();

                    Process.Start("update.bat");
                    Application.Exit();
                } catch (Exception) { }
                zip.Dispose();

                fs.Close();

                File.Delete(zipFileName);
            };

            wc.DownloadFileAsync(new Uri(Program.UpdateDownloadURL), zipFileName);

            button1.Enabled = false;
            button2.Enabled = false;
        }
    }
}
