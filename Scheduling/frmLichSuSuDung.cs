using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Scheduling
{
    public partial class frmLichSuSuDung : Form
    {
        private string connectionString = DBConfig.ConnectionString;
        string currentUserRole = UserSession.UserRole;
        string currentUserId = UserSession.UserId;
        private string currentTab = "Tất cả";

        public frmLichSuSuDung()
        {
            InitializeComponent();
            InitializeTabs();
            UpdateTabCounts();
        }

        private void frmLichSuSuDung_Load(object sender, EventArgs e)
        {
            LoadDataAndUpdateUI();
            HighlightTab(btnTabTatCa);

            //Sua mau btn
            btnCheckIn.BackColor = Color.FromArgb(255, 157, 0); // Vàng cam
        }

        // ========== KHỞI TẠO TAB THEO ROLE ==========
        private void InitializeTabs()
        {
            if (currentUserRole == "docgia")
            {
                btnTabChoCheckIn.Visible = false;
            }
            else
            {
                btnTabChoCheckIn.Visible = true;
            }
        }


        // ========== ĐẾM SỐ LƯỢNG ==========
        private string CountByStatus(string status)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query;

                if (status == "Tất cả")
                {
                    query = @"
                        SELECT COUNT(*) 
                        FROM Lich_su_su_dung lsd
                        JOIN Dat_phong dp ON lsd.ma_dat_phong = dp.ma_dat_phong
                        WHERE (@Role IN ('thuthu', 'admin') OR dp.ma_doc_gia = @UserId)";
                }
                else
                {
                    query = @"
                        SELECT COUNT(*) 
                        FROM Lich_su_su_dung lsd
                        JOIN Dat_phong dp ON lsd.ma_dat_phong = dp.ma_dat_phong
                        WHERE lsd.trang_thai_su_dung = @Status
                        AND (@Role IN ('thuthu', 'admin') OR dp.ma_doc_gia = @UserId)";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // ✅ THÊM PARAMETER @Status (nếu không phải "Tất cả")
                    if (status != "Tất cả")
                        cmd.Parameters.AddWithValue("@Status", status);

                    // ✅ THÊM PARAMETER @Role
                    cmd.Parameters.AddWithValue("@Role", currentUserRole);

                    // ✅ THÊM PARAMETER @UserId
                    if (currentUserRole == "docgia")
                        cmd.Parameters.AddWithValue("@UserId", currentUserId);
                    else
                        cmd.Parameters.AddWithValue("@UserId", DBNull.Value);

                    conn.Open();
                    return cmd.ExecuteScalar().ToString();
                }
            }
        }

        private void UpdateTabCounts()
        {
            btnTabTatCa.Text = $"Tất cả ({CountByStatus("Tất cả")})";
            btnTabChoCheckIn.Text = $"Chờ check in ({CountByStatus("Chờ check in")})";
            btnTabDangSuDung.Text = $"Đang sử dụng ({CountByStatus("Đang sử dụng")})";
            btnTabDaHoanThanh.Text = $"Đã hoàn thành ({CountByStatus("Đã hoàn thành")})";
            btnTabKhongDung.Text = $"Không dùng ({CountByStatus("Không dùng")})";
        }

        // ========== TAB BUTTON EVENTS ==========
        private void btnTabTatCa_Click(object sender, EventArgs e)
        {
            currentTab = "Tất cả";
            LoadDataAndUpdateUI();
            HighlightTab(btnTabTatCa);
        }

        private void btnTabChoCheckIn_Click(object sender, EventArgs e)
        {
            currentTab = "Chờ check in";
            LoadDataAndUpdateUI();
            HighlightTab(btnTabChoCheckIn);
        }

        private void btnTabDangSuDung_Click(object sender, EventArgs e)
        {
            currentTab = "Đang sử dụng";
            LoadDataAndUpdateUI();
            HighlightTab(btnTabDangSuDung);
        }

        private void btnTabDaHoanThanh_Click(object sender, EventArgs e)
        {
            currentTab = "Đã hoàn thành";
            LoadDataAndUpdateUI();
            HighlightTab(btnTabDaHoanThanh);
        }

        private void btnTabKhongDung_Click(object sender, EventArgs e)
        {
            currentTab = "Không dùng";
            LoadDataAndUpdateUI();
            HighlightTab(btnTabKhongDung);
        }

        // ========== LOAD DATA ==========
        private void LoadDataAndUpdateUI()
        {
            dgvLichSuSuDung.DataSource = LoadLichSuSuDung(currentTab);
            SetupButtonsByTabAndRole();
        }

        private DataTable LoadLichSuSuDung(string trangThai)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string orderByClause = GetOrderByClause(trangThai);

                string query = $@"
                    SELECT 
                        dp.ma_dat_phong,
                        CONCAT(p.dia_diem, ' - ', p.ten_phong) AS dia_diem,
                        CASE 
                            WHEN DATEPART(WEEKDAY, dp.ngay_dat) = 1 THEN N'Chủ Nhật'
                            WHEN DATEPART(WEEKDAY, dp.ngay_dat) = 2 THEN N'Thứ Hai'
                            WHEN DATEPART(WEEKDAY, dp.ngay_dat) = 3 THEN N'Thứ Ba'
                            WHEN DATEPART(WEEKDAY, dp.ngay_dat) = 4 THEN N'Thứ Tư'
                            WHEN DATEPART(WEEKDAY, dp.ngay_dat) = 5 THEN N'Thứ Năm'
                            WHEN DATEPART(WEEKDAY, dp.ngay_dat) = 6 THEN N'Thứ Sáu'
                            ELSE N'Thứ Bảy'
                        END + ', ' + FORMAT(dp.ngay_dat, 'dd/MM/yyyy') + ' ' + 
                        dp.gio_bat_dau + '-' + dp.gio_ket_thuc AS thoi_gian,
                        dg.ho_ten,
                        lsd.trang_thai_su_dung AS trang_thai,
                        lsd.thoi_gian_check_in,
                        lsd.nguoi_check_in,
                        lsd.thoi_gian_check_out,
                        lsd.nguoi_check_out
                    FROM Lich_su_su_dung lsd
                    JOIN Dat_phong dp ON lsd.ma_dat_phong = dp.ma_dat_phong
                    JOIN Phong p ON dp.ma_phong = p.ma_phong
                    JOIN Doc_gia dg ON dp.ma_doc_gia = dg.ma_doc_gia
                    WHERE (@TrangThai = N'Tất cả' OR lsd.trang_thai_su_dung = @TrangThai)
                    AND (@Role IN ('thuthu', 'admin') OR dp.ma_doc_gia = @UserId)
                    {orderByClause}";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                    cmd.Parameters.AddWithValue("@Role", currentUserRole);
                    cmd.Parameters.AddWithValue("@UserId",
                        currentUserRole == "docgia" ? (object)currentUserId : DBNull.Value);

                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }

        private string GetOrderByClause(string trangThai)
        {
            switch (trangThai)
            {
                case "Chờ check in":
                    return "ORDER BY dp.ngay_dat ASC, dp.gio_bat_dau ASC";

                case "Đang sử dụng":
                    return "ORDER BY lsd.thoi_gian_check_in DESC";

                case "Đã hoàn thành":
                    return "ORDER BY lsd.thoi_gian_check_out DESC";

                case "Không dùng":
                    return "ORDER BY dp.ngay_dat DESC, dp.gio_bat_dau DESC";

                case "Tất cả":
                default:
                    return "ORDER BY dp.ngay_dat DESC, dp.gio_bat_dau DESC";
            }
        }

        // ========== SETUP BUTTONS VÀ ẨN/HIỆN CỘT ==========
        private void SetupButtonsByTabAndRole()
        {
            // ✅ Ẩn button trước
            btnCheckIn.Visible = false;
            btnCheckOut.Visible = false;

            // ✅ Hiện button theo tab và role
            if (currentTab == "Chờ check in" && currentUserRole != "docgia")
            {
                btnCheckIn.Visible = true;
            }
            else if (currentTab == "Đang sử dụng")
            {
                btnCheckOut.Visible = true;
            }

            // ✅ ẨN/HIỆN CỘT THEO ROLE
            if (dgvLichSuSuDung.Columns.Count == 0) return;

            if (currentUserRole == "docgia")
            {
                dgvLichSuSuDung.Columns["ho_ten"].Visible = false;
                dgvLichSuSuDung.Columns["nguoi_check_in"].Visible = false;
                dgvLichSuSuDung.Columns["nguoi_check_out"].Visible = false;
                // ✅ DocGia: AutoSize Fill
                dgvLichSuSuDung.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                dgvLichSuSuDung.Columns["ho_ten"].Visible = true;
                dgvLichSuSuDung.Columns["nguoi_check_in"].Visible = true;
                dgvLichSuSuDung.Columns["nguoi_check_out"].Visible = true;
            }
        }

        private void HighlightTab(Button activeTab)
        {
            foreach (Control ctrl in flowTabTrangThai.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.White;
                    btn.ForeColor = Color.Black;
                }
            }

            // ✅ Highlight tab đang active
            activeTab.ForeColor = Color.White;

            if (activeTab == btnTabTatCa)
            {
                activeTab.BackColor = Color.FromArgb(66, 133, 244); // Màu xanh dương
            }
            else if (activeTab == btnTabChoCheckIn)
            {
                activeTab.BackColor = Color.FromArgb(255, 157, 0); // Vàng cam
            }
            else if (activeTab == btnTabDangSuDung)
            {
                activeTab.BackColor = Color.FromArgb(66, 133, 244); // Xanh dương (giống tab Tất cả)
            }
            else if (activeTab == btnTabDaHoanThanh)
            {
                activeTab.BackColor = Color.FromArgb(57, 181, 84); // Xanh lá
            }
            else if (activeTab == btnTabKhongDung)
            {
                activeTab.BackColor = Color.FromArgb(255, 31, 31); // Đỏ
            }
        }


        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (dgvLichSuSuDung.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bản ghi để check out!", "Thông báo");
                return;
            }

            int count = 0;
            foreach (DataGridViewRow row in dgvLichSuSuDung.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    string maDatPhong = row.Cells["ma_dat_phong"].Value.ToString();

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = @"
                            UPDATE Lich_su_su_dung
                            SET trang_thai_su_dung = N'Đã hoàn thành',
                                thoi_gian_check_out = GETDATE(),
                                nguoi_check_out = @NguoiCheckOut
                            WHERE ma_dat_phong = @MaDatPhong";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaDatPhong", maDatPhong);
                            cmd.Parameters.AddWithValue("@NguoiCheckOut", UserSession.UserName);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    count++;
                }
            }

            MessageBox.Show($"Đã check out thành công {count} bản ghi!", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            UpdateTabCounts();
            LoadDataAndUpdateUI();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (dgvLichSuSuDung.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bản ghi để check in!", "Thông báo");
                return;
            }

            int count = 0;
            foreach (DataGridViewRow row in dgvLichSuSuDung.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    string maDatPhong = row.Cells["ma_dat_phong"].Value.ToString();

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = @"
                            UPDATE Lich_su_su_dung
                            SET trang_thai_su_dung = N'Đang sử dụng',
                                thoi_gian_check_in = GETDATE(),
                                nguoi_check_in = @NguoiCheckIn
                            WHERE ma_dat_phong = @MaDatPhong";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaDatPhong", maDatPhong);
                            cmd.Parameters.AddWithValue("@NguoiCheckIn", UserSession.UserName);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    count++;
                }
            }

            MessageBox.Show($"Đã check in thành công {count} bản ghi!", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            UpdateTabCounts();
            LoadDataAndUpdateUI();
        }
    }
}
