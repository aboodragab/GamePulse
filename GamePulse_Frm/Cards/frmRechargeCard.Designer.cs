namespace GamePulse_Frm.Cards
{
    partial class frmRechargeCard
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
            this.button1 = new System.Windows.Forms.Button();
            this.Current = new System.Windows.Forms.Label();
            this.lblNewBalance = new System.Windows.Forms.Label();
            this.cmbOffer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAmount = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlCardInfo1 = new GamePulse_Frm.Cards.ctrlCardInfo();
            this.chbUseOffer = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(475, 425);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Charge";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Current
            // 
            this.Current.AutoSize = true;
            this.Current.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Current.Location = new System.Drawing.Point(12, 370);
            this.Current.Name = "Current";
            this.Current.Size = new System.Drawing.Size(266, 37);
            this.Current.TabIndex = 2;
            this.Current.Text = "Current Balance :";
            // 
            // lblNewBalance
            // 
            this.lblNewBalance.AutoSize = true;
            this.lblNewBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewBalance.Location = new System.Drawing.Point(93, 407);
            this.lblNewBalance.Name = "lblNewBalance";
            this.lblNewBalance.Size = new System.Drawing.Size(86, 37);
            this.lblNewBalance.TabIndex = 3;
            this.lblNewBalance.Text = "[???]";
            // 
            // cmbOffer
            // 
            this.cmbOffer.Enabled = false;
            this.cmbOffer.FormattingEnabled = true;
            this.cmbOffer.Location = new System.Drawing.Point(19, 301);
            this.cmbOffer.Name = "cmbOffer";
            this.cmbOffer.Size = new System.Drawing.Size(175, 28);
            this.cmbOffer.TabIndex = 4;
            this.cmbOffer.SelectedIndexChanged += new System.EventHandler(this.cmbOffer_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 273);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select the offer :";
            // 
            // cmbAmount
            // 
            this.cmbAmount.FormattingEnabled = true;
            this.cmbAmount.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50"});
            this.cmbAmount.Location = new System.Drawing.Point(386, 301);
            this.cmbAmount.Name = "cmbAmount";
            this.cmbAmount.Size = new System.Drawing.Size(178, 28);
            this.cmbAmount.TabIndex = 6;
            this.cmbAmount.SelectedIndexChanged += new System.EventHandler(this.cmbAmount_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(381, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Select the amount :";
            // 
            // ctrlCardInfo1
            // 
            this.ctrlCardInfo1.Location = new System.Drawing.Point(0, 0);
            this.ctrlCardInfo1.Name = "ctrlCardInfo1";
            this.ctrlCardInfo1.Size = new System.Drawing.Size(635, 253);
            this.ctrlCardInfo1.TabIndex = 0;
            // 
            // chbUseOffer
            // 
            this.chbUseOffer.AutoSize = true;
            this.chbUseOffer.Location = new System.Drawing.Point(19, 335);
            this.chbUseOffer.Name = "chbUseOffer";
            this.chbUseOffer.Size = new System.Drawing.Size(100, 24);
            this.chbUseOffer.TabIndex = 8;
            this.chbUseOffer.Text = "with offer";
            this.chbUseOffer.UseVisualStyleBackColor = true;
            this.chbUseOffer.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(369, 425);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 34);
            this.button2.TabIndex = 9;
            this.button2.Text = "close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmRechargeCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 472);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.chbUseOffer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbAmount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbOffer);
            this.Controls.Add(this.lblNewBalance);
            this.Controls.Add(this.Current);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrlCardInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRechargeCard";
            this.Text = "frmRechargeCard";
            this.Load += new System.EventHandler(this.frmRechargeCard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlCardInfo ctrlCardInfo1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Current;
        private System.Windows.Forms.Label lblNewBalance;
        private System.Windows.Forms.ComboBox cmbOffer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbUseOffer;
        private System.Windows.Forms.Button button2;
    }
}