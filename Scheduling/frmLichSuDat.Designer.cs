namespace Scheduling
{
    partial class frmLichSuDat
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnTabChoDuyet = new System.Windows.Forms.Button();
            this.btnTabPheDuyet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDatPhong = new System.Windows.Forms.DataGridView();
            this.ma_dat_phong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dia_diem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thoi_gian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ho_ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trang_thai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.muc_dich = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnTuChoi = new System.Windows.Forms.Button();
            this.btnPheDuyet = new System.Windows.Forms.Button();
            this.btnMoChoDuyet = new System.Windows.Forms.Button();
            this.btnTabTuChoi = new System.Windows.Forms.Button();
            this.btnTabDaHuy = new System.Windows.Forms.Button();
            this.btnTabTatCa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatPhong)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTabChoDuyet
            // 
            this.btnTabChoDuyet.BackColor = System.Drawing.Color.Black;
            this.btnTabChoDuyet.FlatAppearance.BorderSize = 0;
            this.btnTabChoDuyet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabChoDuyet.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTabChoDuyet.ForeColor = System.Drawing.Color.White;
            this.btnTabChoDuyet.Location = new System.Drawing.Point(244, 117);
            this.btnTabChoDuyet.Margin = new System.Windows.Forms.Padding(4);
            this.btnTabChoDuyet.Name = "btnTabChoDuyet";
            this.btnTabChoDuyet.Size = new System.Drawing.Size(175, 52);
            this.btnTabChoDuyet.TabIndex = 0;
            this.btnTabChoDuyet.Text = "Chờ duyệt";
            this.btnTabChoDuyet.UseVisualStyleBackColor = false;
            this.btnTabChoDuyet.Click += new System.EventHandler(this.btnTabChoDuyet_Click);
            // 
            // btnTabPheDuyet
            // 
            this.btnTabPheDuyet.BackColor = System.Drawing.Color.Black;
            this.btnTabPheDuyet.FlatAppearance.BorderSize = 0;
            this.btnTabPheDuyet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabPheDuyet.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTabPheDuyet.ForeColor = System.Drawing.Color.White;
            this.btnTabPheDuyet.Location = new System.Drawing.Point(427, 117);
            this.btnTabPheDuyet.Margin = new System.Windows.Forms.Padding(4);
            this.btnTabPheDuyet.Name = "btnTabPheDuyet";
            this.btnTabPheDuyet.Size = new System.Drawing.Size(175, 52);
            this.btnTabPheDuyet.TabIndex = 1;
            this.btnTabPheDuyet.Text = "Phê duyệt";
            this.btnTabPheDuyet.UseVisualStyleBackColor = false;
            this.btnTabPheDuyet.Click += new System.EventHandler(this.btnTabPheDuyet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(620, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "THÔNG TIN ĐĂNG KÝ ĐẶT PHÒNG THƯ VIỆN";
            // 
            // dgvDatPhong
            // 
            this.dgvDatPhong.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatPhong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatPhong.ColumnHeadersHeight = 60;
            this.dgvDatPhong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ma_dat_phong,
            this.dia_diem,
            this.thoi_gian,
            this.ho_ten,
            this.trang_thai,
            this.muc_dich});
            this.dgvDatPhong.EnableHeadersVisualStyles = false;
            this.dgvDatPhong.Location = new System.Drawing.Point(61, 203);
            this.dgvDatPhong.Name = "dgvDatPhong";
            this.dgvDatPhong.RowHeadersWidth = 62;
            this.dgvDatPhong.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDatPhong.RowTemplate.Height = 50;
            this.dgvDatPhong.Size = new System.Drawing.Size(1563, 622);
            this.dgvDatPhong.TabIndex = 3;
            this.dgvDatPhong.DoubleClick += new System.EventHandler(this.dgvDatPhong_DoubleClick);
            // 
            // ma_dat_phong
            // 
            this.ma_dat_phong.DataPropertyName = "ma_dat_phong";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ma_dat_phong.DefaultCellStyle = dataGridViewCellStyle2;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ho_ten.DefaultCellStyle = dataGridViewCellStyle3;
            this.ho_ten.FillWeight = 94.10757F;
            this.ho_ten.HeaderText = "CHỦ PHÒNG";
            this.ho_ten.MinimumWidth = 8;
            this.ho_ten.Name = "ho_ten";
            this.ho_ten.Width = 235;
            // 
            // trang_thai
            // 
            this.trang_thai.DataPropertyName = "trang_thai";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.trang_thai.DefaultCellStyle = dataGridViewCellStyle4;
            this.trang_thai.FillWeight = 67.72245F;
            this.trang_thai.HeaderText = "TRẠNG THÁI";
            this.trang_thai.MinimumWidth = 8;
            this.trang_thai.Name = "trang_thai";
            this.trang_thai.Width = 169;
            // 
            // muc_dich
            // 
            this.muc_dich.DataPropertyName = "muc_dich";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.muc_dich.DefaultCellStyle = dataGridViewCellStyle5;
            this.muc_dich.FillWeight = 72.64993F;
            this.muc_dich.HeaderText = "MỤC ĐÍCH";
            this.muc_dich.MinimumWidth = 8;
            this.muc_dich.Name = "muc_dich";
            this.muc_dich.Width = 182;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.Red;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(632, 864);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(416, 68);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "HỦY ĐẶT PHÒNG";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnTuChoi
            // 
            this.btnTuChoi.BackColor = System.Drawing.Color.Red;
            this.btnTuChoi.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTuChoi.ForeColor = System.Drawing.Color.White;
            this.btnTuChoi.Location = new System.Drawing.Point(468, 864);
            this.btnTuChoi.Name = "btnTuChoi";
            this.btnTuChoi.Size = new System.Drawing.Size(302, 68);
            this.btnTuChoi.TabIndex = 6;
            this.btnTuChoi.Text = "TỪ CHỐI";
            this.btnTuChoi.UseVisualStyleBackColor = false;
            this.btnTuChoi.Click += new System.EventHandler(this.btnTuChoi_Click);
            // 
            // btnPheDuyet
            // 
            this.btnPheDuyet.BackColor = System.Drawing.Color.LimeGreen;
            this.btnPheDuyet.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPheDuyet.ForeColor = System.Drawing.Color.White;
            this.btnPheDuyet.Location = new System.Drawing.Point(910, 864);
            this.btnPheDuyet.Name = "btnPheDuyet";
            this.btnPheDuyet.Size = new System.Drawing.Size(302, 68);
            this.btnPheDuyet.TabIndex = 7;
            this.btnPheDuyet.Text = "PHÊ DUYỆT";
            this.btnPheDuyet.UseVisualStyleBackColor = false;
            this.btnPheDuyet.Click += new System.EventHandler(this.btnPheDuyet_Click);
            // 
            // btnMoChoDuyet
            // 
            this.btnMoChoDuyet.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnMoChoDuyet.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoChoDuyet.ForeColor = System.Drawing.Color.White;
            this.btnMoChoDuyet.Location = new System.Drawing.Point(632, 654);
            this.btnMoChoDuyet.Name = "btnMoChoDuyet";
            this.btnMoChoDuyet.Size = new System.Drawing.Size(416, 68);
            this.btnMoChoDuyet.TabIndex = 8;
            this.btnMoChoDuyet.Text = "MỞ CHỜ DUYỆT";
            this.btnMoChoDuyet.UseVisualStyleBackColor = false;
            this.btnMoChoDuyet.Click += new System.EventHandler(this.btnMoChoDuyet_Click);
            // 
            // btnTabTuChoi
            // 
            this.btnTabTuChoi.BackColor = System.Drawing.Color.Black;
            this.btnTabTuChoi.FlatAppearance.BorderSize = 0;
            this.btnTabTuChoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabTuChoi.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTabTuChoi.ForeColor = System.Drawing.Color.White;
            this.btnTabTuChoi.Location = new System.Drawing.Point(610, 117);
            this.btnTabTuChoi.Margin = new System.Windows.Forms.Padding(4);
            this.btnTabTuChoi.Name = "btnTabTuChoi";
            this.btnTabTuChoi.Size = new System.Drawing.Size(175, 52);
            this.btnTabTuChoi.TabIndex = 9;
            this.btnTabTuChoi.Text = "Từ chối";
            this.btnTabTuChoi.UseVisualStyleBackColor = false;
            this.btnTabTuChoi.Click += new System.EventHandler(this.btnTabTuChoi_Click);
            // 
            // btnTabDaHuy
            // 
            this.btnTabDaHuy.BackColor = System.Drawing.Color.Black;
            this.btnTabDaHuy.FlatAppearance.BorderSize = 0;
            this.btnTabDaHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabDaHuy.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTabDaHuy.ForeColor = System.Drawing.Color.White;
            this.btnTabDaHuy.Location = new System.Drawing.Point(793, 117);
            this.btnTabDaHuy.Margin = new System.Windows.Forms.Padding(4);
            this.btnTabDaHuy.Name = "btnTabDaHuy";
            this.btnTabDaHuy.Size = new System.Drawing.Size(175, 52);
            this.btnTabDaHuy.TabIndex = 10;
            this.btnTabDaHuy.Text = "Đã hủy";
            this.btnTabDaHuy.UseVisualStyleBackColor = false;
            this.btnTabDaHuy.Click += new System.EventHandler(this.btnTabDaHuy_Click);
            // 
            // btnTabTatCa
            // 
            this.btnTabTatCa.BackColor = System.Drawing.Color.Black;
            this.btnTabTatCa.FlatAppearance.BorderSize = 0;
            this.btnTabTatCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabTatCa.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTabTatCa.ForeColor = System.Drawing.Color.White;
            this.btnTabTatCa.Location = new System.Drawing.Point(61, 117);
            this.btnTabTatCa.Margin = new System.Windows.Forms.Padding(4);
            this.btnTabTatCa.Name = "btnTabTatCa";
            this.btnTabTatCa.Size = new System.Drawing.Size(175, 52);
            this.btnTabTatCa.TabIndex = 11;
            this.btnTabTatCa.Text = "Tất cả";
            this.btnTabTatCa.UseVisualStyleBackColor = false;
            this.btnTabTatCa.Click += new System.EventHandler(this.btnTabTatCa_Click);
            // 
            // frmLichSuDat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1681, 961);
            this.Controls.Add(this.btnTabTatCa);
            this.Controls.Add(this.btnTabDaHuy);
            this.Controls.Add(this.btnTabTuChoi);
            this.Controls.Add(this.btnMoChoDuyet);
            this.Controls.Add(this.btnPheDuyet);
            this.Controls.Add(this.btnTuChoi);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.dgvDatPhong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTabPheDuyet);
            this.Controls.Add(this.btnTabChoDuyet);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLichSuDat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lịch sử đặt phòng";
            this.Load += new System.EventHandler(this.frmLichSuDat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatPhong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTabChoDuyet;
        private System.Windows.Forms.Button btnTabPheDuyet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDatPhong;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnTuChoi;
        private System.Windows.Forms.Button btnPheDuyet;
        private System.Windows.Forms.DataGridViewTextBoxColumn ma_dat_phong;
        private System.Windows.Forms.DataGridViewTextBoxColumn dia_diem;
        private System.Windows.Forms.DataGridViewTextBoxColumn thoi_gian;
        private System.Windows.Forms.DataGridViewTextBoxColumn ho_ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn trang_thai;
        private System.Windows.Forms.DataGridViewTextBoxColumn muc_dich;
        private System.Windows.Forms.Button btnMoChoDuyet;
        private System.Windows.Forms.Button btnTabTuChoi;
        private System.Windows.Forms.Button btnTabDaHuy;
        private System.Windows.Forms.Button btnTabTatCa;
    }
}