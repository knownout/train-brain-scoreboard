
namespace TrainBrainScoreBoard
{
    partial class WinnerSelect
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
            this.numberLabel = new System.Windows.Forms.Label();
            this.winnerText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // numberLabel
            // 
            this.numberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numberLabel.BackColor = System.Drawing.Color.Transparent;
            this.numberLabel.Font = new System.Drawing.Font("Comfortaa", 164.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numberLabel.ForeColor = System.Drawing.Color.Black;
            this.numberLabel.Location = new System.Drawing.Point(3, 96);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(882, 375);
            this.numberLabel.TabIndex = 0;
            this.numberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // winnerText
            // 
            this.winnerText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.winnerText.AutoEllipsis = true;
            this.winnerText.BackColor = System.Drawing.Color.Transparent;
            this.winnerText.Font = new System.Drawing.Font("Comfortaa", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.winnerText.ForeColor = System.Drawing.Color.Black;
            this.winnerText.Location = new System.Drawing.Point(3, 55);
            this.winnerText.MaximumSize = new System.Drawing.Size(10000, 128);
            this.winnerText.Name = "winnerText";
            this.winnerText.Size = new System.Drawing.Size(882, 128);
            this.winnerText.TabIndex = 1;
            this.winnerText.Text = "ПОБЕДИТЕЛЬ";
            this.winnerText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WinnerSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TrainBrainScoreBoard.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(881, 591);
            this.Controls.Add(this.winnerText);
            this.Controls.Add(this.numberLabel);
            this.DoubleBuffered = true;
            this.MinimizeBox = false;
            this.Name = "WinnerSelect";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Выбор победителя";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WinnerSelect_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.WinnerSelect_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WinnerSelect_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.Label winnerText;
    }
}