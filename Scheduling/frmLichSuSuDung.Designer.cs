namespace Scheduling
{
    partial class frmLichSuSuDung
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvLichSuSuDung = new System.Windows.Forms.DataGridView();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTabKhongDung = new System.Windows.Forms.Button();
            this.btnTabDaHoanThanh = new System.Windows.Forms.Button();
            this.btnTabDangSuDung = new System.Windows.Forms.Button();
            this.btnTabChoCheckIn = new System.Windows.Forms.Button();
            this.btnTabTatCa = new System.Windows.Forms.Button();
            this.flowTabTrangThai = new System.Windows.Forms.FlowLayoutPanel();
            this.ma_dat_phong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dia_diem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thoi_gian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ho_ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trang_thai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thoi_gian_check_in = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nguoi_check_in = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thoi_gian_check_out = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nguoi_check_out = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuSuDung)).BeginInit();
            this.flowTabTrangThai.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLichSuSuDung
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLichSuSuDung.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLichSuSuDung.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLichSuSuDung.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLichSuSuDung.ColumnHeadersHeight = 60;
            this.dgvLichSuSuDung.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ma_dat_phong,
            this.dia_diem,
            this.thoi_gian,
            this.ho_ten,
            this.trang_thai,
            this.thoi_gian_check_in,
            this.nguoi_check_in,
            this.thoi_gian_check_out,
            this.nguoi_check_out});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLichSuSuDung.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvLichSuSuDung.EnableHeadersVisualStyles = false;
            this.dgvLichSuSuDung.Location = new System.Drawing.Point(62, 197);
            this.dgvLichSuSuDung.Name = "dgvLichSuSuDung";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLichSuSuDung.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvLichSuSuDung.RowHeadersWidth = 62;
            this.dgvLichSuSuDung.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvLichSuSuDung.RowTemplate.Height = 50;
            this.dgvLichSuSuDung.Size = new System.Drawing.Size(2352, 622);
            this.dgvLichSuSuDung.TabIndex = 15;
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.BackColor = System.Drawing.Color.LimeGreen;
            this.btnCheckIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckIn.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckIn.ForeColor = System.Drawing.Color.White;
            this.btnCheckIn.Location = new System.Drawing.Point(986, 858);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(504, 68);
            this.btnCheckIn.TabIndex = 16;
            this.btnCheckIn.Text = "CHECK IN";
            this.btnCheckIn.UseVisualStyleBackColor = false;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckOut.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckOut.ForeColor = System.Drawing.Color.White;
            this.btnCheckOut.Location = new System.Drawing.Point(986, 858);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(504, 68);
            this.btnCheckOut.TabIndex = 23;
            this.btnCheckOut.Text = "CHECK OUT";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(558, 38);
            this.label1.TabIndex = 14;
            this.label1.Text = "THÔNG TIN SỬ DỤNG PHÒNG THƯ VIỆN";
            // 
            // btnTabKhongDung
            // 
            this.btnTabKhongDung.BackColor = System.Drawing.Color.Black;
            this.btnTabKhongDung.FlatAppearance.BorderSize = 0;
            this.btnTabKhongDung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabKhongDung.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTabKhongDung.ForeColor = System.Drawing.Color.White;
            this.btnTabKhongDung.Location = new System.Drawing.Point(876, 4);
            this.btnTabKhongDung.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTabKhongDung.Name = "btnTabKhongDung";
            this.btnTabKhongDung.Size = new System.Drawing.Size(210, 52);
            this.btnTabKhongDung.TabIndex = 21;
            this.btnTabKhongDung.Text = "Không dùng";
            this.btnTabKhongDung.UseVisualStyleBackColor = false;
            this.btnTabKhongDung.Click += new System.EventHandler(this.btnTabKhongDung_Click);
            // 
            // btnTabDaHoanThanh
            // 
            this.btnTabDaHoanThanh.BackColor = System.Drawing.Color.Black;
            this.btnTabDaHoanThanh.FlatAppearance.BorderSize = 0;
            this.btnTabDaHoanThanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabDaHoanThanh.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTabDaHoanThanh.ForeColor = System.Drawing.Color.White;
            this.btnTabDaHoanThanh.Location = new System.Drawing.Point(658, 4);
            this.btnTabDaHoanThanh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTabDaHoanThanh.Name = "btnTabDaHoanThanh";
            this.btnTabDaHoanThanh.Size = new System.Drawing.Size(210, 52);
            this.btnTabDaHoanThanh.TabIndex = 20;
            this.btnTabDaHoanThanh.Text = "Đã hoàn thành";
            this.btnTabDaHoanThanh.UseVisualStyleBackColor = false;
            this.btnTabDaHoanThanh.Click += new System.EventHandler(this.btnTabDaHoanThanh_Click);
            // 
            // btnTabDangSuDung
            // 
            this.btnTabDangSuDung.BackColor = System.Drawing.Color.Black;
            this.btnTabDangSuDung.FlatAppearance.BorderSize = 0;
            this.btnTabDangSuDung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabDangSuDung.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTabDangSuDung.ForeColor = System.Drawing.Color.White;
            this.btnTabDangSuDung.Location = new System.Drawing.Point(440, 4);
            this.btnTabDangSuDung.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTabDangSuDung.Name = "btnTabDangSuDung";
            this.btnTabDangSuDung.Size = new System.Drawing.Size(210, 52);
            this.btnTabDangSuDung.TabIndex = 13;
            this.btnTabDangSuDung.Text = "Đang sử dụng";
            this.btnTabDangSuDung.UseVisualStyleBackColor = false;
            this.btnTabDangSuDung.Click += new System.EventHandler(this.btnTabDangSuDung_Click);
            // 
            // btnTabChoCheckIn
            // 
            this.btnTabChoCheckIn.BackColor = System.Drawing.Color.Black;
            this.btnTabChoCheckIn.FlatAppearance.BorderSize = 0;
            this.btnTabChoCheckIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabChoCheckIn.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTabChoCheckIn.ForeColor = System.Drawing.Color.White;
            this.btnTabChoCheckIn.Location = new System.Drawing.Point(222, 4);
            this.btnTabChoCheckIn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTabChoCheckIn.Name = "btnTabChoCheckIn";
            this.btnTabChoCheckIn.Size = new System.Drawing.Size(210, 52);
            this.btnTabChoCheckIn.TabIndex = 12;
            this.btnTabChoCheckIn.Text = "Chờ check in";
            this.btnTabChoCheckIn.UseVisualStyleBackColor = false;
            this.btnTabChoCheckIn.Click += new System.EventHandler(this.btnTabChoCheckIn_Click);
            // 
            // btnTabTatCa
            // 
            this.btnTabTatCa.BackColor = System.Drawing.Color.Black;
            this.btnTabTatCa.FlatAppearance.BorderSize = 0;
            this.btnTabTatCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabTatCa.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTabTatCa.ForeColor = System.Drawing.Color.White;
            this.btnTabTatCa.Location = new System.Drawing.Point(4, 4);
            this.btnTabTatCa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTabTatCa.Name = "btnTabTatCa";
            this.btnTabTatCa.Size = new System.Drawing.Size(210, 52);
            this.btnTabTatCa.TabIndex = 22;
            this.btnTabTatCa.Text = "Tất cả";
            this.btnTabTatCa.UseVisualStyleBackColor = false;
            this.btnTabTatCa.Click += new System.EventHandler(this.btnTabTatCa_Click);
            // 
            // flowTabTrangThai
            // 
            this.flowTabTrangThai.Controls.Add(this.btnTabTatCa);
            this.flowTabTrangThai.Controls.Add(this.btnTabChoCheckIn);
            this.flowTabTrangThai.Controls.Add(this.btnTabDangSuDung);
            this.flowTabTrangThai.Controls.Add(this.btnTabDaHoanThanh);
            this.flowTabTrangThai.Controls.Add(this.btnTabKhongDung);
            this.flowTabTrangThai.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowTabTrangThai.Location = new System.Drawing.Point(62, 100);
            this.flowTabTrangThai.Margin = new System.Windows.Forms.Padding(0);
            this.flowTabTrangThai.Name = "flowTabTrangThai";
            this.flowTabTrangThai.Size = new System.Drawing.Size(1137, 61);
            this.flowTabTrangThai.TabIndex = 24;
            // 
            // ma_dat_phong
            // 
            this.ma_dat_phong.DataPropertyName = "ma_dat_phong";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ma_dat_phong.DefaultCellStyle = dataGridViewCellStyle3;
            this.ma_dat_phong.FillWeight = 80.05338F;
            this.ma_dat_phong.HeaderText = "MÃ ĐẶT PHÒNG";
            this.ma_dat_phong.MinimumWidth = 8;
            this.ma_dat_phong.Name = "ma_dat_phong";
            this.ma_dat_phong.Width = 200;
            // 
            // dia_diem
            // 
            this.dia_diem.DataPropertyName = "dia_diem";
            this.dia_diem.FillWeight = 147.0692F;
            this.dia_diem.HeaderText = "ĐỊA ĐIỂM";
            this.dia_diem.MinimumWidth = 8;
            this.dia_diem.Name = "dia_diem";
            this.dia_diem.Width = 367;
            // 
            // thoi_gian
            // 
            this.thoi_gian.DataPropertyName = "thoi_gian";
            this.thoi_gian.FillWeight = 138.3975F;
            this.thoi_gian.HeaderText = "THỜI GIAN";
            this.thoi_gian.MinimumWidth = 8;
            this.thoi_gian.Name = "thoi_gian";
            this.thoi_gian.Width = 346;
            // 
            // ho_ten
            // 
            this.ho_ten.DataPropertyName = "ho_ten";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ho_ten.DefaultCellStyle = dataGridViewCellStyle4;
            this.ho_ten.FillWeight = 94.10757F;
            this.ho_ten.HeaderText = "CHỦ PHÒNG";
            this.ho_ten.MinimumWidth = 8;
            this.ho_ten.Name = "ho_ten";
            this.ho_ten.Width = 235;
            // 
            // trang_thai
            // 
            this.trang_thai.DataPropertyName = "trang_thai";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.trang_thai.DefaultCellStyle = dataGridViewCellStyle5;
            this.trang_thai.FillWeight = 67.72245F;
            this.trang_thai.HeaderText = "TRẠNG THÁI";
            this.trang_thai.MinimumWidth = 8;
            this.trang_thai.Name = "trang_thai";
            this.trang_thai.Width = 169;
            // 
            // thoi_gian_check_in
            // 
            this.thoi_gian_check_in.DataPropertyName = "thoi_gian_check_in";
            dataGridViewCellStyle6.Format = "dd/MM/yyyy HH:mm";
            dataGridViewCellStyle6.NullValue = null;
            this.thoi_gian_check_in.DefaultCellStyle = dataGridViewCellStyle6;
            this.thoi_gian_check_in.HeaderText = "CHECK IN";
            this.thoi_gian_check_in.MinimumWidth = 8;
            this.thoi_gian_check_in.Name = "thoi_gian_check_in";
            this.thoi_gian_check_in.Width = 250;
            // 
            // nguoi_check_in
            // 
            this.nguoi_check_in.DataPropertyName = "nguoi_check_in";
            this.nguoi_check_in.HeaderText = "NGƯỜI CHECK IN";
            this.nguoi_check_in.MinimumWidth = 8;
            this.nguoi_check_in.Name = "nguoi_check_in";
            this.nguoi_check_in.Width = 235;
            // 
            // thoi_gian_check_out
            // 
            this.thoi_gian_check_out.DataPropertyName = "thoi_gian_check_out";
            dataGridViewCellStyle7.Format = "dd/MM/yyyy HH:mm";
            dataGridViewCellStyle7.NullValue = null;
            this.thoi_gian_check_out.DefaultCellStyle = dataGridViewCellStyle7;
            this.thoi_gian_check_out.HeaderText = "CHECK OUT";
            this.thoi_gian_check_out.MinimumWidth = 8;
            this.thoi_gian_check_out.Name = "thoi_gian_check_out";
            this.thoi_gian_check_out.Width = 250;
            // 
            // nguoi_check_out
            // 
            this.nguoi_check_out.DataPropertyName = "nguoi_check_out";
            this.nguoi_check_out.HeaderText = "NGƯỜI CHECK OUT";
            this.nguoi_check_out.MinimumWidth = 8;
            this.nguoi_check_out.Name = "nguoi_check_out";
            this.nguoi_check_out.Width = 235;
            // 
            // frmLichSuSuDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(2477, 961);
            this.Controls.Add(this.flowTabTrangThai);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.dgvLichSuSuDung);
            this.Controls.Add(this.label1);
            this.Name = "frmLichSuSuDung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lịch sử sử dụng phòng";
            this.Load += new System.EventHandler(this.frmLichSuSuDung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuSuDung)).EndInit();
            this.flowTabTrangThai.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvLichSuSuDung;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTabKhongDung;
        private System.Windows.Forms.Button btnTabDaHoanThanh;
        private System.Windows.Forms.Button btnTabDangSuDung;
        private System.Windows.Forms.Button btnTabChoCheckIn;
        private System.Windows.Forms.Button btnTabTatCa;
        private System.Windows.Forms.FlowLayoutPanel flowTabTrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn ma_dat_phong;
        private System.Windows.Forms.DataGridViewTextBoxColumn dia_diem;
        private System.Windows.Forms.DataGridViewTextBoxColumn thoi_gian;
        private System.Windows.Forms.DataGridViewTextBoxColumn ho_ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn trang_thai;
        private System.Windows.Forms.DataGridViewTextBoxColumn thoi_gian_check_in;
        private System.Windows.Forms.DataGridViewTextBoxColumn nguoi_check_in;
        private System.Windows.Forms.DataGridViewTextBoxColumn thoi_gian_check_out;
        private System.Windows.Forms.DataGridViewTextBoxColumn nguoi_check_out;
    }
}