namespace Scheduling
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.dtpNgayDatPhong = new System.Windows.Forms.DateTimePicker();
            this.Top = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Schedule = new System.Windows.Forms.Panel();
            this.dgvLichDatPhong = new System.Windows.Forms.DataGridView();
            this.Bottom = new System.Windows.Forms.Panel();
            this.btnLichSuDat = new System.Windows.Forms.Button();
            this.btnDatPhong = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.User = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnLichSuSuDung = new System.Windows.Forms.Button();
            this.Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Schedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichDatPhong)).BeginInit();
            this.Bottom.SuspendLayout();
            this.User.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(926, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Đang chọn";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(776, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Đang trống";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(626, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Phòng bận";
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnFilter.Location = new System.Drawing.Point(1417, 27);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(113, 42);
            this.btnFilter.TabIndex = 10;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // dtpNgayDatPhong
            // 
            this.dtpNgayDatPhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dtpNgayDatPhong.CustomFormat = "dddd, dd/MM/yyyy";
            this.dtpNgayDatPhong.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayDatPhong.Location = new System.Drawing.Point(43, 35);
            this.dtpNgayDatPhong.Name = "dtpNgayDatPhong";
            this.dtpNgayDatPhong.Size = new System.Drawing.Size(283, 26);
            this.dtpNgayDatPhong.TabIndex = 9;
            this.dtpNgayDatPhong.ValueChanged += new System.EventHandler(this.dtpNgayDatPhong_ValueChanged);
            // 
            // Top
            // 
            this.Top.Controls.Add(this.btnFilter);
            this.Top.Controls.Add(this.dtpNgayDatPhong);
            this.Top.Controls.Add(this.pictureBox3);
            this.Top.Controls.Add(this.label3);
            this.Top.Controls.Add(this.pictureBox2);
            this.Top.Controls.Add(this.label1);
            this.Top.Controls.Add(this.pictureBox1);
            this.Top.Controls.Add(this.label2);
            this.Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.Top.Location = new System.Drawing.Point(0, 71);
            this.Top.Name = "Top";
            this.Top.Size = new System.Drawing.Size(1573, 96);
            this.Top.TabIndex = 17;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pictureBox3.Image = global::Scheduling.Properties.Resources.yellow;
            this.pictureBox3.Location = new System.Drawing.Point(890, 33);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 16;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pictureBox2.Image = global::Scheduling.Properties.Resources.greeen;
            this.pictureBox2.Location = new System.Drawing.Point(740, 33);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pictureBox1.Image = global::Scheduling.Properties.Resources.red;
            this.pictureBox1.Location = new System.Drawing.Point(590, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // Schedule
            // 
            this.Schedule.Controls.Add(this.dgvLichDatPhong);
            this.Schedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Schedule.Location = new System.Drawing.Point(43, 167);
            this.Schedule.Name = "Schedule";
            this.Schedule.Size = new System.Drawing.Size(1487, 678);
            this.Schedule.TabIndex = 18;
            // 
            // dgvLichDatPhong
            // 
            this.dgvLichDatPhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dgvLichDatPhong.ColumnHeadersHeight = 60;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLichDatPhong.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLichDatPhong.Location = new System.Drawing.Point(0, 0);
            this.dgvLichDatPhong.Name = "dgvLichDatPhong";
            this.dgvLichDatPhong.RowHeadersWidth = 62;
            this.dgvLichDatPhong.RowTemplate.Height = 40;
            this.dgvLichDatPhong.Size = new System.Drawing.Size(1487, 678);
            this.dgvLichDatPhong.TabIndex = 0;
            this.dgvLichDatPhong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLichDatPhong_CellClick);
            this.dgvLichDatPhong.Sorted += new System.EventHandler(this.dgvLichDatPhong_Sorted);
            // 
            // Bottom
            // 
            this.Bottom.Controls.Add(this.btnLichSuSuDung);
            this.Bottom.Controls.Add(this.btnLichSuDat);
            this.Bottom.Controls.Add(this.btnDatPhong);
            this.Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Bottom.Location = new System.Drawing.Point(0, 845);
            this.Bottom.Name = "Bottom";
            this.Bottom.Size = new System.Drawing.Size(1573, 96);
            this.Bottom.TabIndex = 19;
            // 
            // btnLichSuDat
            // 
            this.btnLichSuDat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnLichSuDat.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLichSuDat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLichSuDat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLichSuDat.Location = new System.Drawing.Point(607, 15);
            this.btnLichSuDat.Margin = new System.Windows.Forms.Padding(0);
            this.btnLichSuDat.Name = "btnLichSuDat";
            this.btnLichSuDat.Size = new System.Drawing.Size(362, 66);
            this.btnLichSuDat.TabIndex = 11;
            this.btnLichSuDat.Text = "LỊCH SỬ ĐẶT";
            this.btnLichSuDat.UseVisualStyleBackColor = false;
            this.btnLichSuDat.Click += new System.EventHandler(this.btnLichSuDat_Click);
            // 
            // btnDatPhong
            // 
            this.btnDatPhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnDatPhong.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnDatPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatPhong.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDatPhong.Location = new System.Drawing.Point(188, 15);
            this.btnDatPhong.Margin = new System.Windows.Forms.Padding(0);
            this.btnDatPhong.Name = "btnDatPhong";
            this.btnDatPhong.Size = new System.Drawing.Size(362, 66);
            this.btnDatPhong.TabIndex = 10;
            this.btnDatPhong.Text = "ĐẶT PHÒNG";
            this.btnDatPhong.UseVisualStyleBackColor = false;
            this.btnDatPhong.Click += new System.EventHandler(this.btnDatPhong_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 167);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(43, 678);
            this.panel1.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1530, 167);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(43, 678);
            this.panel2.TabIndex = 21;
            // 
            // User
            // 
            this.User.BackColor = System.Drawing.Color.AliceBlue;
            this.User.Controls.Add(this.btnLogout);
            this.User.Controls.Add(this.lblUser);
            this.User.Controls.Add(this.lblWelcome);
            this.User.Dock = System.Windows.Forms.DockStyle.Top;
            this.User.Location = new System.Drawing.Point(0, 0);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(1573, 71);
            this.User.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnLogout.Location = new System.Drawing.Point(1417, 13);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(113, 44);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Log out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblUser
            // 
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblUser.Location = new System.Drawing.Point(128, 25);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(57, 20);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "label4";
            // 
            // lblWelcome
            // 
            this.lblWelcome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(39, 25);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(82, 20);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome";
            // 
            // btnLichSuSuDung
            // 
            this.btnLichSuSuDung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnLichSuSuDung.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLichSuSuDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLichSuSuDung.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLichSuSuDung.Location = new System.Drawing.Point(1022, 15);
            this.btnLichSuSuDung.Margin = new System.Windows.Forms.Padding(0);
            this.btnLichSuSuDung.Name = "btnLichSuSuDung";
            this.btnLichSuSuDung.Size = new System.Drawing.Size(362, 66);
            this.btnLichSuSuDung.TabIndex = 12;
            this.btnLichSuSuDung.Text = "SỬ DỤNG PHÒNG";
            this.btnLichSuSuDung.UseVisualStyleBackColor = false;
            this.btnLichSuSuDung.Click += new System.EventHandler(this.btnLichSuSuDung_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1573, 941);
            this.Controls.Add(this.Schedule);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Bottom);
            this.Controls.Add(this.Top);
            this.Controls.Add(this.User);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Top.ResumeLayout(false);
            this.Top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Schedule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichDatPhong)).EndInit();
            this.Bottom.ResumeLayout(false);
            this.User.ResumeLayout(false);
            this.User.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DateTimePicker dtpNgayDatPhong;
        private System.Windows.Forms.Panel Top;
        private System.Windows.Forms.Panel Schedule;
        private System.Windows.Forms.Panel Bottom;
        private System.Windows.Forms.Button btnDatPhong;
        private System.Windows.Forms.DataGridView dgvLichDatPhong;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel User;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnLichSuDat;
        private System.Windows.Forms.Button btnLichSuSuDung;
    }
}

