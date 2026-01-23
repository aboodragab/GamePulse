namespace GamePulse_Frm
{
    partial class frmDashboard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnTransactions = new System.Windows.Forms.Button();
            this.btnPlayDeduction = new System.Windows.Forms.Button();
            this.btnGameManagement = new System.Windows.Forms.Button();
            this.btnTopUp = new System.Windows.Forms.Button();
            this.btnCardManagement = new System.Windows.Forms.Button();
            this.pnlLogoSection = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblSubLogo = new System.Windows.Forms.Label();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.TotalRevenue = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblActiveCards = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblTodayPlays = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.timerDashboardRefresh = new System.Windows.Forms.Timer(this.components);
            this.pnlSidebar.SuspendLayout();
            this.pnlLogoSection.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(0, 112);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(315, 62);
            this.btnDashboard.TabIndex = 7;
            this.btnDashboard.Text = "  📊   Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.White;
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Controls.Add(this.btnReports);
            this.pnlSidebar.Controls.Add(this.btnTransactions);
            this.pnlSidebar.Controls.Add(this.btnPlayDeduction);
            this.pnlSidebar.Controls.Add(this.btnGameManagement);
            this.pnlSidebar.Controls.Add(this.btnTopUp);
            this.pnlSidebar.Controls.Add(this.btnCardManagement);
            this.pnlSidebar.Controls.Add(this.btnDashboard);
            this.pnlSidebar.Controls.Add(this.pnlLogoSection);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(315, 678);
            this.pnlSidebar.TabIndex = 2;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogout.Location = new System.Drawing.Point(0, 616);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(315, 62);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "  🚪   Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.White;
            this.btnReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnReports.Location = new System.Drawing.Point(0, 484);
            this.btnReports.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(315, 62);
            this.btnReports.TabIndex = 1;
            this.btnReports.Text = "  📈   Reports";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.UseVisualStyleBackColor = false;
            // 
            // btnTransactions
            // 
            this.btnTransactions.BackColor = System.Drawing.Color.White;
            this.btnTransactions.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTransactions.FlatAppearance.BorderSize = 0;
            this.btnTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransactions.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnTransactions.Location = new System.Drawing.Point(0, 422);
            this.btnTransactions.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnTransactions.Name = "btnTransactions";
            this.btnTransactions.Size = new System.Drawing.Size(315, 62);
            this.btnTransactions.TabIndex = 3;
            this.btnTransactions.Text = "  🧾   Transactions";
            this.btnTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransactions.UseVisualStyleBackColor = false;
            // 
            // btnPlayDeduction
            // 
            this.btnPlayDeduction.BackColor = System.Drawing.Color.White;
            this.btnPlayDeduction.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPlayDeduction.FlatAppearance.BorderSize = 0;
            this.btnPlayDeduction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayDeduction.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnPlayDeduction.Location = new System.Drawing.Point(0, 360);
            this.btnPlayDeduction.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnPlayDeduction.Name = "btnPlayDeduction";
            this.btnPlayDeduction.Size = new System.Drawing.Size(315, 62);
            this.btnPlayDeduction.TabIndex = 3;
            this.btnPlayDeduction.Text = "  ▶️   Play / Deduction";
            this.btnPlayDeduction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlayDeduction.UseVisualStyleBackColor = false;
            // 
            // btnGameManagement
            // 
            this.btnGameManagement.BackColor = System.Drawing.Color.White;
            this.btnGameManagement.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGameManagement.FlatAppearance.BorderSize = 0;
            this.btnGameManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGameManagement.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnGameManagement.Location = new System.Drawing.Point(0, 298);
            this.btnGameManagement.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnGameManagement.Name = "btnGameManagement";
            this.btnGameManagement.Size = new System.Drawing.Size(315, 62);
            this.btnGameManagement.TabIndex = 4;
            this.btnGameManagement.Text = "  🎮   Game Management";
            this.btnGameManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGameManagement.UseVisualStyleBackColor = false;
            // 
            // btnTopUp
            // 
            this.btnTopUp.BackColor = System.Drawing.Color.White;
            this.btnTopUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTopUp.FlatAppearance.BorderSize = 0;
            this.btnTopUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopUp.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnTopUp.Location = new System.Drawing.Point(0, 236);
            this.btnTopUp.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnTopUp.Name = "btnTopUp";
            this.btnTopUp.Size = new System.Drawing.Size(315, 62);
            this.btnTopUp.TabIndex = 5;
            this.btnTopUp.Text = "  $   Top-Up";
            this.btnTopUp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTopUp.UseVisualStyleBackColor = false;
            // 
            // btnCardManagement
            // 
            this.btnCardManagement.BackColor = System.Drawing.Color.White;
            this.btnCardManagement.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCardManagement.FlatAppearance.BorderSize = 0;
            this.btnCardManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCardManagement.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCardManagement.Location = new System.Drawing.Point(0, 174);
            this.btnCardManagement.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnCardManagement.Name = "btnCardManagement";
            this.btnCardManagement.Size = new System.Drawing.Size(315, 62);
            this.btnCardManagement.TabIndex = 6;
            this.btnCardManagement.Text = "  💳   Card Management";
            this.btnCardManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCardManagement.UseVisualStyleBackColor = false;
            // 
            // pnlLogoSection
            // 
            this.pnlLogoSection.Controls.Add(this.flowLayoutPanel1);
            this.pnlLogoSection.Controls.Add(this.panel3);
            this.pnlLogoSection.Controls.Add(this.lblLogo);
            this.pnlLogoSection.Controls.Add(this.lblSubLogo);
            this.pnlLogoSection.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogoSection.Location = new System.Drawing.Point(0, 0);
            this.pnlLogoSection.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlLogoSection.Name = "pnlLogoSection";
            this.pnlLogoSection.Size = new System.Drawing.Size(315, 112);
            this.pnlLogoSection.TabIndex = 8;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(314, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1065, 240);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Location = new System.Drawing.Point(315, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(362, 192);
            this.panel3.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(350, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 192);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(356, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(363, 192);
            this.panel2.TabIndex = 1;
            // 
            // lblLogo
            // 
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblLogo.Location = new System.Drawing.Point(21, 15);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(225, 58);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "Game Hall";
            // 
            // lblSubLogo
            // 
            this.lblSubLogo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubLogo.ForeColor = System.Drawing.Color.SlateGray;
            this.lblSubLogo.Location = new System.Drawing.Point(26, 75);
            this.lblSubLogo.Name = "lblSubLogo";
            this.lblSubLogo.Size = new System.Drawing.Size(225, 31);
            this.lblSubLogo.TabIndex = 1;
            this.lblSubLogo.Text = "Management System";
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.AllowUserToDeleteRows = false;
            this.dgvTransactions.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransactions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTransactions.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTransactions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTransactions.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTransactions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvTransactions.EnableHeadersVisualStyles = false;
            this.dgvTransactions.Location = new System.Drawing.Point(315, 420);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransactions.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTransactions.RowHeadersWidth = 62;
            this.dgvTransactions.RowTemplate.Height = 28;
            this.dgvTransactions.Size = new System.Drawing.Size(969, 258);
            this.dgvTransactions.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.lblTotalRevenue);
            this.panel4.Controls.Add(this.TotalRevenue);
            this.panel4.Location = new System.Drawing.Point(4, 5);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(308, 182);
            this.panel4.TabIndex = 0;
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.AutoSize = true;
            this.lblTotalRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRevenue.ForeColor = System.Drawing.Color.Green;
            this.lblTotalRevenue.Location = new System.Drawing.Point(46, 108);
            this.lblTotalRevenue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(206, 52);
            this.lblTotalRevenue.TabIndex = 0;
            this.lblTotalRevenue.Text = "0.00 JOD";
            // 
            // TotalRevenue
            // 
            this.TotalRevenue.AutoSize = true;
            this.TotalRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalRevenue.Location = new System.Drawing.Point(-3, 51);
            this.TotalRevenue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TotalRevenue.Name = "TotalRevenue";
            this.TotalRevenue.Size = new System.Drawing.Size(305, 52);
            this.TotalRevenue.TabIndex = 0;
            this.TotalRevenue.Text = "Total Revenue";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.Controls.Add(this.lblActiveCards);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Location = new System.Drawing.Point(321, 5);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(314, 182);
            this.panel5.TabIndex = 0;
            // 
            // lblActiveCards
            // 
            this.lblActiveCards.AutoSize = true;
            this.lblActiveCards.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveCards.ForeColor = System.Drawing.Color.Green;
            this.lblActiveCards.Location = new System.Drawing.Point(66, 102);
            this.lblActiveCards.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblActiveCards.Name = "lblActiveCards";
            this.lblActiveCards.Size = new System.Drawing.Size(175, 52);
            this.lblActiveCards.TabIndex = 0;
            this.lblActiveCards.Text = "0 Cards";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Active Cards";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Control;
            this.panel6.Controls.Add(this.lblTodayPlays);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Location = new System.Drawing.Point(648, 5);
            this.panel6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(314, 182);
            this.panel6.TabIndex = 0;
            // 
            // lblTodayPlays
            // 
            this.lblTodayPlays.AutoSize = true;
            this.lblTodayPlays.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodayPlays.ForeColor = System.Drawing.Color.Green;
            this.lblTodayPlays.Location = new System.Drawing.Point(87, 102);
            this.lblTodayPlays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTodayPlays.Name = "lblTodayPlays";
            this.lblTodayPlays.Size = new System.Drawing.Size(143, 52);
            this.lblTodayPlays.TabIndex = 0;
            this.lblTodayPlays.Text = "0 Play";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(292, 52);
            this.label2.TabIndex = 0;
            this.label2.Text = "Today\'s Plays";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.18033F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.81967F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 324F));
            this.tableLayoutPanel1.Controls.Add(this.panel6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(315, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(969, 192);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // timerDashboardRefresh
            // 
            this.timerDashboardRefresh.Enabled = true;
            this.timerDashboardRefresh.Interval = 1000;
            this.timerDashboardRefresh.Tick += new System.EventHandler(this.timerDashboardRefresh_Tick);
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 678);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dgvTransactions);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "frmDashboard";
            this.Text = "frmDashboard";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlLogoSection.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnTransactions;
        private System.Windows.Forms.Button btnPlayDeduction;
        private System.Windows.Forms.Button btnGameManagement;
        private System.Windows.Forms.Button btnTopUp;
        private System.Windows.Forms.Button btnCardManagement;
        private System.Windows.Forms.Panel pnlLogoSection;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblSubLogo;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label TotalRevenue;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblActiveCards;
        private System.Windows.Forms.Label lblTodayPlays;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Timer timerDashboardRefresh;
    }
}