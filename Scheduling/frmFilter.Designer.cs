namespace Scheduling
{
    partial class frmFilter
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkBangKinh = new System.Windows.Forms.CheckBox();
            this.line = new System.Windows.Forms.Panel();
            this.chkManHinh = new System.Windows.Forms.CheckBox();
            this.chkDieuHoa = new System.Windows.Forms.CheckBox();
            this.chkMayChieu = new System.Windows.Forms.CheckBox();
            this.chkWifi = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.rdbTuDongDuyet = new System.Windows.Forms.RadioButton();
            this.rdbCanDuyet = new System.Windows.Forms.RadioButton();
            this.rdbTu5Cho = new System.Windows.Forms.RadioButton();
            this.rdbTu10Cho = new System.Windows.Forms.RadioButton();
            this.rdbTu15Cho = new System.Windows.Forms.RadioButton();
            this.rdbChinhXac = new System.Windows.Forms.RadioButton();
            this.txtSoCho = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtSoCho);
            this.panel1.Controls.Add(this.rdbChinhXac);
            this.panel1.Controls.Add(this.rdbTu15Cho);
            this.panel1.Controls.Add(this.rdbTu10Cho);
            this.panel1.Controls.Add(this.rdbTu5Cho);
            this.panel1.Controls.Add(this.rdbCanDuyet);
            this.panel1.Controls.Add(this.rdbTuDongDuyet);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(379, 517);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(122, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sức chứa";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkBangKinh);
            this.panel2.Controls.Add(this.line);
            this.panel2.Controls.Add(this.chkManHinh);
            this.panel2.Controls.Add(this.chkDieuHoa);
            this.panel2.Controls.Add(this.chkMayChieu);
            this.panel2.Controls.Add(this.chkWifi);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(379, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(386, 517);
            this.panel2.TabIndex = 1;
            // 
            // chkBangKinh
            // 
            this.chkBangKinh.AutoSize = true;
            this.chkBangKinh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBangKinh.Location = new System.Drawing.Point(137, 319);
            this.chkBangKinh.Name = "chkBangKinh";
            this.chkBangKinh.Size = new System.Drawing.Size(116, 29);
            this.chkBangKinh.TabIndex = 8;
            this.chkBangKinh.Text = "Bảng kính";
            this.chkBangKinh.UseVisualStyleBackColor = true;
            // 
            // line
            // 
            this.line.BackColor = System.Drawing.Color.Silver;
            this.line.Location = new System.Drawing.Point(-7, 29);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(10, 427);
            this.line.TabIndex = 9;
            // 
            // chkManHinh
            // 
            this.chkManHinh.AutoSize = true;
            this.chkManHinh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkManHinh.Location = new System.Drawing.Point(137, 267);
            this.chkManHinh.Name = "chkManHinh";
            this.chkManHinh.Size = new System.Drawing.Size(112, 29);
            this.chkManHinh.TabIndex = 7;
            this.chkManHinh.Text = "Màn hình";
            this.chkManHinh.UseVisualStyleBackColor = true;
            // 
            // chkDieuHoa
            // 
            this.chkDieuHoa.AutoSize = true;
            this.chkDieuHoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDieuHoa.Location = new System.Drawing.Point(137, 215);
            this.chkDieuHoa.Name = "chkDieuHoa";
            this.chkDieuHoa.Size = new System.Drawing.Size(109, 29);
            this.chkDieuHoa.TabIndex = 6;
            this.chkDieuHoa.Text = "Điều hòa";
            this.chkDieuHoa.UseVisualStyleBackColor = true;
            // 
            // chkMayChieu
            // 
            this.chkMayChieu.AutoSize = true;
            this.chkMayChieu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMayChieu.Location = new System.Drawing.Point(137, 163);
            this.chkMayChieu.Name = "chkMayChieu";
            this.chkMayChieu.Size = new System.Drawing.Size(118, 29);
            this.chkMayChieu.TabIndex = 5;
            this.chkMayChieu.Text = "Máy chiếu";
            this.chkMayChieu.UseVisualStyleBackColor = true;
            // 
            // chkWifi
            // 
            this.chkWifi.AutoSize = true;
            this.chkWifi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWifi.Location = new System.Drawing.Point(137, 111);
            this.chkWifi.Name = "chkWifi";
            this.chkWifi.Size = new System.Drawing.Size(69, 29);
            this.chkWifi.TabIndex = 4;
            this.chkWifi.Text = "Wifi";
            this.chkWifi.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(132, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tiện ích";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnFilter);
            this.panel3.Controls.Add(this.btnReset);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 517);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(765, 98);
            this.panel3.TabIndex = 1;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(413, 9);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(149, 62);
            this.btnFilter.TabIndex = 1;
            this.btnFilter.Text = "Lọc";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(202, 9);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(149, 62);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Đặt lại";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(122, 319);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "Loại phòng";
            // 
            // rdbTuDongDuyet
            // 
            this.rdbTuDongDuyet.AutoSize = true;
            this.rdbTuDongDuyet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbTuDongDuyet.Location = new System.Drawing.Point(127, 371);
            this.rdbTuDongDuyet.Name = "rdbTuDongDuyet";
            this.rdbTuDongDuyet.Size = new System.Drawing.Size(155, 29);
            this.rdbTuDongDuyet.TabIndex = 7;
            this.rdbTuDongDuyet.TabStop = true;
            this.rdbTuDongDuyet.Text = "Tự động duyệt";
            this.rdbTuDongDuyet.UseVisualStyleBackColor = true;
            // 
            // rdbCanDuyet
            // 
            this.rdbCanDuyet.AutoSize = true;
            this.rdbCanDuyet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbCanDuyet.Location = new System.Drawing.Point(127, 420);
            this.rdbCanDuyet.Name = "rdbCanDuyet";
            this.rdbCanDuyet.Size = new System.Drawing.Size(117, 29);
            this.rdbCanDuyet.TabIndex = 8;
            this.rdbCanDuyet.TabStop = true;
            this.rdbCanDuyet.Text = "Cần duyệt";
            this.rdbCanDuyet.UseVisualStyleBackColor = true;
            // 
            // rdbTu5Cho
            // 
            this.rdbTu5Cho.AutoSize = true;
            this.rdbTu5Cho.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbTu5Cho.Location = new System.Drawing.Point(127, 111);
            this.rdbTu5Cho.Name = "rdbTu5Cho";
            this.rdbTu5Cho.Size = new System.Drawing.Size(98, 29);
            this.rdbTu5Cho.TabIndex = 9;
            this.rdbTu5Cho.TabStop = true;
            this.rdbTu5Cho.Text = "≥ 5 chỗ";
            this.rdbTu5Cho.UseVisualStyleBackColor = true;
            // 
            // rdbTu10Cho
            // 
            this.rdbTu10Cho.AutoSize = true;
            this.rdbTu10Cho.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbTu10Cho.Location = new System.Drawing.Point(127, 163);
            this.rdbTu10Cho.Name = "rdbTu10Cho";
            this.rdbTu10Cho.Size = new System.Drawing.Size(108, 29);
            this.rdbTu10Cho.TabIndex = 10;
            this.rdbTu10Cho.TabStop = true;
            this.rdbTu10Cho.Text = "≥ 10 chỗ";
            this.rdbTu10Cho.UseVisualStyleBackColor = true;
            // 
            // rdbTu15Cho
            // 
            this.rdbTu15Cho.AutoSize = true;
            this.rdbTu15Cho.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbTu15Cho.Location = new System.Drawing.Point(127, 215);
            this.rdbTu15Cho.Name = "rdbTu15Cho";
            this.rdbTu15Cho.Size = new System.Drawing.Size(108, 29);
            this.rdbTu15Cho.TabIndex = 11;
            this.rdbTu15Cho.TabStop = true;
            this.rdbTu15Cho.Text = "≥ 15 chỗ";
            this.rdbTu15Cho.UseVisualStyleBackColor = true;
            // 
            // rdbChinhXac
            // 
            this.rdbChinhXac.AutoSize = true;
            this.rdbChinhXac.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbChinhXac.Location = new System.Drawing.Point(127, 266);
            this.rdbChinhXac.Name = "rdbChinhXac";
            this.rdbChinhXac.Size = new System.Drawing.Size(49, 29);
            this.rdbChinhXac.TabIndex = 12;
            this.rdbChinhXac.TabStop = true;
            this.rdbChinhXac.Text = "=";
            this.rdbChinhXac.UseVisualStyleBackColor = true;
            // 
            // txtSoCho
            // 
            this.txtSoCho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSoCho.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoCho.Location = new System.Drawing.Point(174, 267);
            this.txtSoCho.Name = "txtSoCho";
            this.txtSoCho.Size = new System.Drawing.Size(43, 31);
            this.txtSoCho.TabIndex = 13;
            this.txtSoCho.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(222, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "chỗ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(765, 615);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "frmFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bộ lọc";
            this.Deactivate += new System.EventHandler(this.frmFilter_Deactivate);
            this.Load += new System.EventHandler(this.frmFilter_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkBangKinh;
        private System.Windows.Forms.CheckBox chkManHinh;
        private System.Windows.Forms.CheckBox chkDieuHoa;
        private System.Windows.Forms.CheckBox chkMayChieu;
        private System.Windows.Forms.CheckBox chkWifi;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Panel line;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdbCanDuyet;
        private System.Windows.Forms.RadioButton rdbTuDongDuyet;
        private System.Windows.Forms.RadioButton rdbTu15Cho;
        private System.Windows.Forms.RadioButton rdbTu10Cho;
        private System.Windows.Forms.RadioButton rdbTu5Cho;
        private System.Windows.Forms.RadioButton rdbChinhXac;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSoCho;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}