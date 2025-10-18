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
    public partial class frmLichSuDat : Form
    {
        private string connectionString = DBConfig.ConnectionString;
        string currentUserRole = UserSession.UserRole; // "ThuThu" or "DocGia"
        string currentUserId = UserSession.UserId; // MaDocGia of the logged-in user
        private string currentTab = "Tất cả";
        public frmLichSuDat()
        {
            InitializeComponent();
            UpdateTabCounts();
            btnTabTatCa_Click(btnTabChoDuyet, EventArgs.Empty);

            //Set lai mau rgb cho button (thấy mặc định hiện tại còn đẹp hơn)
            //btnPheDuyet.BackColor = Color.FromArgb(57, 181, 84);
            //btnTuChoi.BackColor = Color.FromArgb(255, 31, 31);
            //btnHuy.BackColor = Color.FromArgb(255, 31, 31);
            //btnMoChoDuyet.BackColor = Color.FromArgb(66, 133, 244);

        }

        private void frmLichSuDat_Load(object sender, EventArgs e)
        {
            // Mặc định chọn tab "Chờ duyệt"
            SetupButtonsByTabAndRole();
            dgvDatPhong.DataSource = LoadDatPhong(currentTab);
        }

        private string CountByStatus(string status)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query;

                // ✅ Nếu "Tất cả" → không filter trạng thái
                if (status == "Tất cả")
                {
                    query = @"
                        SELECT COUNT(*) 
                        FROM Dat_phong dp
                        WHERE (@Role IN ('thuthu', 'admin') OR dp.ma_doc_gia = @UserId)";
                }
                else
                {
                    query = @"
                        SELECT COUNT(*) 
                        FROM Dat_phong dp
                        WHERE dp.trang_thai = @Status
                        AND (@Role IN ('thuthu', 'admin') OR dp.ma_doc_gia = @UserId)";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // ✅ Chỉ add @Status khi KHÔNG phải "Tất cả"
                    if (status != "Tất cả")
                        cmd.Parameters.AddWithValue("@Status", status);

                    if (currentUserRole == "thuthu" || currentUserRole == "admin")
                    {
                        cmd.Parameters.AddWithValue("@Role", currentUserRole);
                        cmd.Parameters.AddWithValue("@UserId", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Role", "docgia");
                        cmd.Parameters.AddWithValue("@UserId", currentUserId);
                    }

                    conn.Open();
                    return cmd.ExecuteScalar().ToString();
                }
            }
        }

        private void UpdateTabCounts()
        {
            btnTabTatCa.Text = $"Tất cả ({CountByStatus("Tất cả")})";
            btnTabChoDuyet.Text = $"Chờ duyệt ({CountByStatus("Chờ duyệt")})";
            btnTabPheDuyet.Text = $"Phê duyệt ({CountByStatus("Phê duyệt")})";
            btnTabTuChoi.Text = $"Từ chối ({CountByStatus("Từ chối")})";
            btnTabDaHuy.Text = $"Đã hủy ({CountByStatus("Đã hủy")})";
        }

        // ========== 5 TAB BUTTON EVENTS ==========
        private void btnTabTatCa_Click(object sender, EventArgs e)
        {
            currentTab = "Tất cả";
            LoadDataAndUpdateUI();
            HighlightTab(btnTabTatCa);
        }

        private void btnTabChoDuyet_Click(object sender, EventArgs e)
        {
            currentTab = "Chờ duyệt";
            LoadDataAndUpdateUI();
            HighlightTab(btnTabChoDuyet);
        }

        private void btnTabPheDuyet_Click(object sender, EventArgs e)
        {
            currentTab = "Phê duyệt";
            LoadDataAndUpdateUI();
            HighlightTab(btnTabPheDuyet);
        }

        private void btnTabTuChoi_Click(object sender, EventArgs e)
        {
            currentTab = "Từ chối";
            LoadDataAndUpdateUI();
            HighlightTab(btnTabTuChoi);
        }

        private void btnTabDaHuy_Click(object sender, EventArgs e)
        {
            currentTab = "Đã hủy";
            LoadDataAndUpdateUI();
            HighlightTab(btnTabDaHuy);
        }

        private void LoadDataAndUpdateUI()
        {
            // Load dữ liệu
            dgvDatPhong.DataSource = LoadDatPhong(currentTab);

            // Cập nhật buttons dựa vào tab và role
            SetupButtonsByTabAndRole();
        }

        private void HighlightTab(Button activeTab)
        {
            // Reset tất cả tab về màu trắng
            Button[] allTabs = { btnTabTatCa, btnTabChoDuyet, btnTabPheDuyet, btnTabTuChoi, btnTabDaHuy };

            foreach (Button btn in allTabs)
            {
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Black;
            }

            // ✅ Highlight tab đang active
            activeTab.ForeColor = Color.White;
            if (activeTab == btnTabTatCa)
            {
                activeTab.BackColor = Color.FromArgb(66, 133, 244); // Màu xanh dương
            }
            else if (activeTab == btnTabChoDuyet)
            {
                activeTab.BackColor = Color.FromArgb(255, 157, 0); // Vàng cam
            }
            else if (activeTab == btnTabPheDuyet)
            {
                activeTab.BackColor = Color.FromArgb(57, 181, 84); // Xanh lá
            }
            else if (activeTab == btnTabTuChoi || activeTab == btnTabDaHuy)
            {
                activeTab.BackColor = Color.FromArgb(255, 31, 31); // Đỏ (cả 2 tab)
            }
        }

        private void SetupButtonsByTabAndRole()
        {
            // ✅ ẨN HIỆN CỘT "Chủ phòng" DỰA TRÊN ROLE
            if (currentUserRole == "docgia")
            {
                // DocGia: Ẩn cột chủ phòng + một số button
                dgvDatPhong.Columns["ho_ten"].Visible = false;  // ✅ Dùng thay vì Header
                dgvDatPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else // ThuThu
            {
                // ThuThu: Hiện tất cả, xem được thông tin toàn bộ
                dgvDatPhong.Columns["ho_ten"].Visible = true;   // ✅ ThuThu xem được chủ phòng
            }

            // ✅ ẨN TẤT CẢ BUTTON TRƯỚC
            btnPheDuyet.Visible = false;
            btnTuChoi.Visible = false;
            btnHuy.Visible = false;
            btnMoChoDuyet.Visible = false;

            // ✅ Sau đó mới show button cần thiết
            if (currentTab == "Chờ duyệt")
            {
                if (currentUserRole == "docgia")
                {
                    btnHuy.Visible = true;
                }
                else // admin, thuthu
                {
                    btnPheDuyet.Visible = true;
                    btnTuChoi.Visible = true;
                }
            }
            else if (currentTab == "Phê duyệt")
            {
                if (currentUserRole == "docgia")
                {
                    btnHuy.Visible = true;
                }
                else // admin, thuthu
                {
                    btnMoChoDuyet.Visible = true;
                    btnMoChoDuyet.Location = new Point(btnHuy.Location.X, btnHuy.Location.Y);
                }
            }
            else if (currentTab == "Từ chối" && currentUserRole != "docgia")
            {
                btnMoChoDuyet.Visible = true;
                btnMoChoDuyet.Location = new Point(btnHuy.Location.X, btnHuy.Location.Y);
            }
        }

        private DataTable LoadDatPhong(string trangThai)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetDatPhong", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // ✅ Truyền tham số dựa vào user role
                    if (currentUserRole == "thuthu" || currentUserRole == "admin")
                    {
                        cmd.Parameters.AddWithValue("@loai_user", currentUserRole);
                        cmd.Parameters.AddWithValue("@ma_doc_gia", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@loai_user", "DocGia");
                        cmd.Parameters.AddWithValue("@ma_doc_gia", currentUserId);
                    }

                    // ✅ Nếu "Tất cả" → truyền NULL
                    if (trangThai == "Tất cả")
                        cmd.Parameters.AddWithValue("@trang_thai", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@trang_thai", trangThai);

                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        //Phục vụ tạo mới và xóa bỏ lịch sử đặt phòng

        // ========== TẠO LỊCH SỬ SỬ DỤNG ==========
        private void TaoLichSuSuDung(string maDatPhong)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            IF NOT EXISTS (SELECT 1 FROM Lich_su_su_dung WHERE ma_dat_phong = @ma_dat_phong)
            BEGIN
                INSERT INTO Lich_su_su_dung (ma_dat_phong, trang_thai_su_dung)
                VALUES (@ma_dat_phong, N'Chờ check in')
            END";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ma_dat_phong", maDatPhong);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ========== XÓA LỊCH SỬ SỬ DỤNG ==========
        private void XoaLichSuSuDung(string maDatPhong)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Lich_su_su_dung WHERE ma_dat_phong = @ma_dat_phong";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ma_dat_phong", maDatPhong);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }



        private void btnPheDuyet_Click(object sender, EventArgs e)
        {
            if (dgvDatPhong.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một bản ghi để phê duyệt!", "Thông báo");
                return;
            }

            int count = 0;
            foreach (DataGridViewRow row in dgvDatPhong.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    string maDatPhong = row.Cells["ma_dat_phong"].Value.ToString();
                    UpdateTrangThai(maDatPhong, "Phê duyệt");

                    // Tạo lịch sử sử dụng
                    TaoLichSuSuDung(maDatPhong);

                    count++;
                }
            }

            MessageBox.Show($"Đã phê duyệt thành công {count} bản ghi!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Refresh lại DataGridView
            UpdateTabCounts();
            dgvDatPhong.DataSource = LoadDatPhong(currentTab);
        }

        private void btnTuChoi_Click(object sender, EventArgs e)
        {
            if (dgvDatPhong.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một bản ghi để từ chối!", "Thông báo");
                return;
            }

            int count = 0;
            foreach (DataGridViewRow row in dgvDatPhong.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    string maDatPhong = row.Cells["ma_dat_phong"].Value.ToString();
                    UpdateTrangThai(maDatPhong, "Từ chối");
                    count++;
                }
            }

            MessageBox.Show($"Đã từ chối thành công {count} bản ghi!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Refresh lại DataGridView
            UpdateTabCounts();
            dgvDatPhong.DataSource = LoadDatPhong(currentTab);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (dgvDatPhong.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bản ghi!", "Thông báo");
                return;
            }

            int count = 0;
            foreach (DataGridViewRow row in dgvDatPhong.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    string trangThai = row.Cells["trang_thai"].Value?.ToString();

                    if (trangThai == "Từ chối" || trangThai == "Đã hủy")
                    {
                        MessageBox.Show("Không thể hủy bỏ quyết định!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    // ✅ Chỉ hủy "Chờ duyệt" và "Phê duyệt"
                    if (trangThai == "Chờ duyệt" || trangThai == "Phê duyệt")
                    {
                        // ✅ Kiểm tra thời gian cho "Phê duyệt"
                        if (trangThai == "Phê duyệt")
                        {
                            DateTime thoiGianSuDung = GetThoiGianSuDungPhong(row);
                            double minutesLeft = (thoiGianSuDung - DateTime.Now).TotalMinutes;

                            // Phải còn ít nhất 30 phut 
                            if (minutesLeft < 30)
                                continue;
                        }

                        string maDatPhong = row.Cells["ma_dat_phong"].Value.ToString();
                        UpdateTrangThai(maDatPhong, "Đã hủy");

                        // Xóa lịch sử sử dụng nếu có
                        XoaLichSuSuDung(maDatPhong);

                        count++;
                    }
                }
            }

            if (count > 0)
            {
                MessageBox.Show($"Đã hủy {count} bản ghi!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateTabCounts();
                dgvDatPhong.DataSource = LoadDatPhong(currentTab);
            }
            else
            {
                MessageBox.Show("Xin lỗi! Để hủy đặt phòng, bạn cần thông báo trước ít nhất 30 phút so với thời gian sử dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateTrangThai(string maDatPhong, string trangThai)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE Dat_phong SET trang_thai = @trang_thai, ngay_sua = @ngay_sua, nguoi_sua = @nguoi_sua WHERE ma_dat_phong = @ma_dat_phong", conn))
                {
                    cmd.Parameters.AddWithValue("@trang_thai", trangThai);
                    cmd.Parameters.AddWithValue("@ngay_sua", DateTime.Now);
                    cmd.Parameters.AddWithValue("@nguoi_sua", UserSession.UserName);
                    cmd.Parameters.AddWithValue("@ma_dat_phong", maDatPhong);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private DateTime GetThoiGianSuDungPhong(DataGridViewRow row)
        {
            try
            {
                string maDatPhong = row.Cells["ma_dat_phong"].Value?.ToString();

                if (string.IsNullOrEmpty(maDatPhong))
                {
                    return DateTime.Now.AddDays(1);
                }

                // ✅ SQL Server connection
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT ngay_dat, gio_bat_dau 
                        FROM Dat_phong 
                        WHERE ma_dat_phong = @maDatPhong";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maDatPhong", maDatPhong);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                DateTime ngayDat = reader.GetDateTime(0);        // Cột đầu tiên
                                string gioStr = reader.GetString(1);             // Cột thứ hai
                                TimeSpan gioBatDau = TimeSpan.Parse(gioStr);

                                DateTime thoiGianSuDung = ngayDat.Add(gioBatDau);
                                return thoiGianSuDung;
                            }
                        }
                    }
                }

                return DateTime.Now.AddDays(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi GetThoiGianSuDungPhong: {ex.Message}", "Error");
                return DateTime.Now.AddDays(1);
            }
        }

        private void btnMoChoDuyet_Click(object sender, EventArgs e)
        {
            if (dgvDatPhong.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bản ghi!", "Thông báo");
                return;
            }

            int count = 0;
            foreach (DataGridViewRow row in dgvDatPhong.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    string trangThai = row.Cells["trang_thai"].Value?.ToString();

                    if (trangThai == "Đã hủy")
                    {
                        MessageBox.Show("Người đặt đã hủy, không thể hủy bỏ quyết định!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DateTime thoiGianSuDung = GetThoiGianSuDungPhong(row);

                    //Chỉ mở những phòng chưa qua thời gian sử dụng
                    if (thoiGianSuDung > DateTime.Now)
                    {
                        string maDatPhong = row.Cells["ma_dat_phong"].Value.ToString();
                        UpdateTrangThai(maDatPhong, "Chờ duyệt");

                        // Xóa lịch sử sử dụng nếu có
                        XoaLichSuSuDung(maDatPhong);

                        count++;
                    }
                }
            }

            if (count > 0)
            {
                MessageBox.Show($"Đã mở {count} bản ghi về 'Chờ duyệt'!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateTabCounts();
                dgvDatPhong.DataSource = LoadDatPhong(currentTab);
            }
            else
            {
                MessageBox.Show("Thời gian sử dụng phòng đã qua, không thể thay đổi trạng thái", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void dgvDatPhong_DoubleClick(object sender, EventArgs e)
        {
            // Kiểm tra có dòng nào được chọn không
            if (dgvDatPhong.CurrentRow == null) return;

            string maDatPhong = dgvDatPhong.CurrentRow.Cells["ma_dat_phong"].Value?.ToString();
            frmDatPhong frmChiTiet = new frmDatPhong(maDatPhong);
            frmChiTiet.ShowDialog();

        }
    }
}
