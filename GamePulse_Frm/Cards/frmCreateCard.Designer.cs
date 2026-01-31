namespace GamePulse_Frm
{
    partial class frmCreateCard
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRFID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.btnCreateCard = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create New Card";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(385, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Card Number (Barcode/RFID)";
            // 
            // txtRFID
            // 
            this.txtRFID.Location = new System.Drawing.Point(21, 116);
            this.txtRFID.Name = "txtRFID";
            this.txtRFID.Size = new System.Drawing.Size(654, 26);
            this.txtRFID.TabIndex = 1;
            this.txtRFID.Validating += new System.ComponentModel.CancelEventHandler(this.txtRFID_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Initial Balance ($)";
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(21, 218);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(654, 26);
            this.txtBalance.TabIndex = 1;
            this.txtBalance.Validating += new System.ComponentModel.CancelEventHandler(this.txtBalance_Validating);
            // 
            // btnCreateCard
            // 
            this.btnCreateCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateCard.Location = new System.Drawing.Point(21, 256);
            this.btnCreateCard.Name = "btnCreateCard";
            this.btnCreateCard.Size = new System.Drawing.Size(654, 74);
            this.btnCreateCard.TabIndex = 3;
            this.btnCreateCard.Text = "Create Card";
            this.btnCreateCard.UseVisualStyleBackColor = true;
            this.btnCreateCard.Click += new System.EventHandler(this.btnCreateCard_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmCreateCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 335);
            this.Controls.Add(this.btnCreateCard);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.txtRFID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmCreateCard";
            this.Text = "frmCreateCard";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRFID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Button btnCreateCard;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}