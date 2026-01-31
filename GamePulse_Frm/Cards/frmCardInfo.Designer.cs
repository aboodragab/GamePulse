namespace GamePulse_Frm.Cards
{
    partial class frmCardInfo
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
            this.ctrlCardInfo1 = new GamePulse_Frm.Cards.ctrlCardInfo();
            this.SuspendLayout();
            // 
            // ctrlCardInfo1
            // 
            this.ctrlCardInfo1.Location = new System.Drawing.Point(12, 12);
            this.ctrlCardInfo1.Name = "ctrlCardInfo1";
            this.ctrlCardInfo1.Size = new System.Drawing.Size(487, 234);
            this.ctrlCardInfo1.TabIndex = 0;
            // 
            // frmCardInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 255);
            this.Controls.Add(this.ctrlCardInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCardInfo";
            this.Text = "frmCardInfo";
            this.Load += new System.EventHandler(this.frmCardInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlCardInfo ctrlCardInfo1;
    }
}