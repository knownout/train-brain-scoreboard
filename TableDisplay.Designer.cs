
namespace TrainBrainScoreBoard
{
    partial class TableDisplay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableHeaderPanel = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gradientPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // tableHeaderPanel
            // 
            this.tableHeaderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableHeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.tableHeaderPanel.Location = new System.Drawing.Point(0, 100);
            this.tableHeaderPanel.Name = "tableHeaderPanel";
            this.tableHeaderPanel.Size = new System.Drawing.Size(827, 43);
            this.tableHeaderPanel.TabIndex = 0;
            this.tableHeaderPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TableHeaderPaint);
            // 
            // gradientPanel
            // 
            this.gradientPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gradientPanel.BackColor = System.Drawing.Color.Gray;
            this.gradientPanel.BackgroundImage = global::TrainBrainScoreBoard.Properties.Resources.background;
            this.gradientPanel.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel.Name = "gradientPanel";
            this.gradientPanel.Size = new System.Drawing.Size(827, 100);
            this.gradientPanel.TabIndex = 1;
            this.gradientPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GradientPanelPaint);
            // 
            // TableDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(827, 595);
            this.Controls.Add(this.gradientPanel);
            this.Controls.Add(this.tableHeaderPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "TableDisplay";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Таблица команд";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormPaint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownEventHandler);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel tableHeaderPanel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel gradientPanel;
    }
}