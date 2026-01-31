namespace GamePulse_Frm.Games
{
    partial class frmGameInfo
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
            this.ctrlGamesInfo1 = new GamePulse_Frm.Games.ctrlGamesInfo();
            this.SuspendLayout();
            // 
            // ctrlGamesInfo1
            // 
            this.ctrlGamesInfo1.Location = new System.Drawing.Point(13, 6);
            this.ctrlGamesInfo1.Name = "ctrlGamesInfo1";
            this.ctrlGamesInfo1.Size = new System.Drawing.Size(565, 238);
            this.ctrlGamesInfo1.TabIndex = 0;
            // 
            // frmGameInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 250);
            this.Controls.Add(this.ctrlGamesInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmGameInfo";
            this.Text = "frmGameInfo";
            this.Load += new System.EventHandler(this.frmGameInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private ctrlGamesInfo ctrlGamesInfo1;
    }
}