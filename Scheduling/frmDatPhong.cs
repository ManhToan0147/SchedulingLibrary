using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling
{
    public enum FormMode
    {
        TaoMoi,
        XemChiTiet
    }
    public partial class frmDatPhong : Form
    {
        private string connectionString = DBConfig.ConnectionString;

        // Chế độ form
        private FormMode Mode { get; set; }

        public string TenPhong { get; set; }
        public DateTime NgayDat { get; set; }
        public List<string> SelectedTimeSlots { get; set; }

        // Thông tin đặt phòng (cho XEM CHI TIẾT)
        public string MaDatPhong { get; set; }

        //Phuc vụ thêm thành viên
        private List<UC_ThanhVien> danhSachThanhVien = new List<UC_ThanhVien>();
        public frmDatPhong()
        {
            InitializeComponent();
            Mode = FormMode.TaoMoi;
            SetupFlowPanel();
        }

        // Constructor XEM CHI TIẾT
        public frmDatPhong(string maDatPhong)
        {
            InitializeComponent();
            Mode = FormMode.XemChiTiet;
            MaDatPhong = maDatPhong;
            SetupFlowPanel();
        }

        private void frmDatPhong_Load(object sender, EventArgs e)
        {
            if (Mode == FormMode.TaoMoi)
            {
                SetupTaoMoi();
                LoadBookingInfo();

                //Set up trang thai khoi tao
                lblTrangThai.Text = "Thông tin đặt phòng đang được khởi tạo";
                lblTrangThai.ForeColor = Color.FromArgb(66, 133, 244); // Màu xanh dương
                picStatus.Image = Properties.Resources.icon_add_button;
            }
            else
            {
                SetupXemChiTiet();
                LoadThongTinDatPhong(MaDatPhong);
                string trangThai = LayTrangThaiPhong(MaDatPhong);
                SetTrangThai(trangThai);
            }
        }

        public string LayTrangThaiPhong(string maDatPhong)
        {
            string trangThai = "";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT trang_thai FROM Dat_phong WHERE ma_dat_phong = @MaDatPhong";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDatPhong", maDatPhong);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        trangThai = result.ToString();
                }
            }

            return trangThai;
        }

        private void SetTrangThai(string trangThai)
        {
            switch (trangThai)
            {
                case "Chờ duyệt":
                    lblTrangThai.Text = "Yêu cầu đặt phòng đang chờ duyệt";
                    lblTrangThai.ForeColor = Color.FromArgb(255, 157, 0); // Màu vàng
                    picStatus.Image = Properties.Resources.icon_waiting;
                    break;
                case "Đã hủy":
                    lblTrangThai.Text = "Yêu cầu đặt phòng đã bị hủy";
                    lblTrangThai.ForeColor = Color.FromArgb(255, 31, 31); // Màu đỏ
                    picStatus.Image = Properties.Resources.icon_cancel;
                    break;
                case "Từ chối":
                    lblTrangThai.Text = "Yêu cầu đặt phòng bị từ chối";
                    lblTrangThai.ForeColor = Color.FromArgb(255, 31, 31); // Màu đỏ
                    picStatus.Image = Properties.Resources.icon_reject;
                    break;
                case "Phê duyệt":
                    lblTrangThai.Text = "Yêu cầu đặt phòng đã được phê duyệt";
                    lblTrangThai.ForeColor = Color.FromArgb(57, 181, 84); // Màu xanh lá
                    picStatus.Image = Properties.Resources.icon_check;
                    break;
            }
        }

        private void SetupFlowPanel()
        {
            // Cấu hình FlowLayoutPanel
            flowPanelThanhVien.FlowDirection = FlowDirection.TopDown;
            flowPanelThanhVien.WrapContents = false;
            flowPanelThanhVien.AutoScroll = true;
        }

        private void SetupTaoMoi()
        {
            this.Text = "Thông tin đặt phòng";
            btnDatPhong.Visible = true;
            btnHuy.Visible = true;
            btnThemNguoi.Visible = true;

            // Hiện pnlChuPhong nếu là độc giả
            if (UserSession.UserRole == "docgia")
            {
                pnlChuPhong.Visible = true;
                lblTenDocGia.Text = UserSession.UserName;
                lblEmail.Text = UserSession.UserEmail;
            }
            else
            {
                pnlChuPhong.Visible = false;
            }

            // Set default
            rbdDatTruoc.Checked = true;
        }

        private void SetupXemChiTiet()
        {
            this.Text = "Chi tiết đặt phòng";
            btnDatPhong.Visible = false;
            btnHuy.Visible = false;
            btnThemNguoi.Visible = false;

            // Luôn hiện pnlChuPhong khi xem chi tiết
            pnlChuPhong.Visible = true;

            // Disable controls
            rbdDatTruoc.AutoCheck = false;
            rbdHop.AutoCheck = false;
            rbdHocNhom.AutoCheck = false;
        }

        private void LoadBookingInfo()
        {
            // Hiển thị thông tin phòng
            lblTenPhong.Text = TenPhong;
            string[] thuTiengViet = { "Chủ Nhật", "Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu", "Thứ Bảy" };
            string thu = thuTiengViet[(int)NgayDat.DayOfWeek];
            lblNgay.Text = thu + ", " + NgayDat.ToString("dd/MM/yyyy");

            var (startTime, endTime) = GetBookingTimeRange();
            lblThoiGian.Text = $"{startTime:hh\\:mm} - {endTime:hh\\:mm}";

            // Load tiện ích phòng
            LoadRoomEquipments(TenPhong);
        }

        // Load thông tin cho XEM CHI TIẾT
        private void LoadThongTinDatPhong(string maDatPhong)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 1. Load thông tin đặt phòng + Chủ phòng
                string query = @"
            SELECT 
                dp.ma_dat_phong,
                p.ten_phong,
                dp.muc_dich,
                dp.ngay_dat,
                dp.gio_bat_dau,
                dp.gio_ket_thuc,
                dg.ma_doc_gia AS ma_chu_phong,
                dg.ho_ten AS ten_chu_phong,
                dg.email AS email_chu_phong
            FROM Dat_phong dp
            INNER JOIN Phong p ON dp.ma_phong = p.ma_phong
            INNER JOIN Doc_gia dg ON dp.ma_doc_gia = dg.ma_doc_gia
            WHERE dp.ma_dat_phong = @MaDatPhong";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDatPhong", maDatPhong);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Thông tin phòng
                            string tenPhong = reader["ten_phong"].ToString();
                            lblTenPhong.Text = tenPhong;
                            LoadRoomEquipments(tenPhong);

                            // Mục đích
                            string mucDich = reader["muc_dich"].ToString();
                            rbdDatTruoc.Checked = (mucDich == "Đặt trước");
                            rbdHop.Checked = (mucDich == "Họp");
                            rbdHocNhom.Checked = (mucDich == "Học nhóm");

                            // Ngày giờ
                            DateTime ngayDat = Convert.ToDateTime(reader["ngay_dat"]);
                            string gioBatDau = reader["gio_bat_dau"].ToString();
                            string gioKetThuc = reader["gio_ket_thuc"].ToString();

                            string[] thuTiengViet = { "Chủ Nhật", "Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu", "Thứ Bảy" };
                            string thu = thuTiengViet[(int)ngayDat.DayOfWeek];
                            lblNgay.Text = thu + ", " + ngayDat.ToString("dd/MM/yyyy");

                            lblThoiGian.Text = $"{gioBatDau} - {gioKetThuc}";

                            // Thông tin Chủ phòng (hiển thị ở pnlChuPhong)
                            lblTenDocGia.Text = reader["ten_chu_phong"].ToString();
                            lblEmail.Text = reader["email_chu_phong"].ToString();
                        }
                    }
                }

                // 2. Load danh sách Thành viên vào FlowPanel
                string queryThanhVien = @"
            SELECT 
                dg.ma_doc_gia,
                dg.ho_ten,
                dg.email
            FROM Thanh_vien_phong tv
            INNER JOIN Doc_gia dg ON tv.ma_doc_gia = dg.ma_doc_gia
            WHERE tv.ma_dat_phong = @MaDatPhong
            ORDER BY tv.ma_thanh_vien";

                using (SqlCommand cmd = new SqlCommand(queryThanhVien, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDatPhong", maDatPhong);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ThemThanhVien(
                                reader["ma_doc_gia"].ToString(),
                                reader["ho_ten"].ToString(),
                                reader["email"].ToString()
                            );
                        }
                    }
                }

                // 3. Ẩn nút X khi xem chi tiết
                foreach (Control ctrl in flowPanelThanhVien.Controls)
                {
                    if (ctrl is UC_ThanhVien tv)
                    {
                        //An nut xoa 
                        tv.BtnXoa.Visible = false;
                    }
                }
            }
        }

        public void LoadRoomEquipments(string tenPhong)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT may_chieu, dieu_hoa, wifi, man_hinh, bang_kinh, suc_chua
                    FROM dbo.Phong 
                    WHERE ten_phong = @tenPhong";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tenPhong", tenPhong);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // ✅ Set trạng thái CheckBox
                    chkWifi.Checked = reader["wifi"] != DBNull.Value && (bool)reader["wifi"];
                    chkMayChieu.Checked = reader["may_chieu"] != DBNull.Value && (bool)reader["may_chieu"];
                    chkDieuHoa.Checked = reader["dieu_hoa"] != DBNull.Value && (bool)reader["dieu_hoa"];
                    chkManHinh.Checked = reader["man_hinh"] != DBNull.Value && (bool)reader["man_hinh"];
                    chkBangKinh.Checked = reader["bang_kinh"] != DBNull.Value && (bool)reader["bang_kinh"];

                    // ✅ Hiển thị thông tin
                    lblSucChua.Text = $"Sức chứa: {reader["suc_chua"]}";
                    lblTenPhong.Text = tenPhong; // Hiển thị tên phòng
                }
            }
        }

        private (TimeSpan startTime, TimeSpan endTime) GetBookingTimeRange()
        {
            var sortedSlots = SelectedTimeSlots.OrderBy(x => x).ToList();

            TimeSpan startTime = TimeSpan.Parse(sortedSlots.First());
            TimeSpan endTime = TimeSpan.Parse(sortedSlots.Last()).Add(TimeSpan.FromMinutes(30));

            return (startTime, endTime);
        }

        private string GetSelectedMucDich()
        {
            if (rbdDatTruoc.Checked) return "Đặt trước";
            if (rbdHop.Checked) return "Họp";
            if (rbdHocNhom.Checked) return "Học nhóm";
            return "Đặt trước";
        }

        //=======================Lưu phòng ===================================
        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            try
            {
                SaveBookingToDatabase();

                MessageBox.Show("Đặt phòng thành công!", "Thành công");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi");
            }
        }

        private void SaveBookingToDatabase()
        {
            string mucDich = GetSelectedMucDich();
            var (startTime, endTime) = GetBookingTimeRange();
            // Lấy mã Chủ phòng
            string maChuPhong = LayMaChuPhong();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string maDatPhongMoi = null;

                // 1. Gọi sp_DatPhong và lấy mã đặt phòng
                using (SqlCommand cmd = new SqlCommand("sp_DatPhong", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TenPhong", TenPhong);
                    cmd.Parameters.AddWithValue("@NgayDat", NgayDat);
                    cmd.Parameters.AddWithValue("@GioBatDau", startTime);
                    cmd.Parameters.AddWithValue("@GioKetThuc", endTime);
                    cmd.Parameters.AddWithValue("@MucDich", mucDich);
                    cmd.Parameters.AddWithValue("@MaDocGia", maChuPhong);
                    cmd.Parameters.AddWithValue("@NguoiTao", UserSession.UserName);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            maDatPhongMoi = reader["ma_dat_phong"].ToString();
                        }
                    }
                }
                if (string.IsNullOrEmpty(maDatPhongMoi))
                {
                    throw new Exception("Không tạo được đặt phòng!");
                }

                // 2. Lưu Thành viên
                LuuDanhSachThanhVien(conn, maDatPhongMoi);
            }
        }

        // Lấy mã Chủ phòng
        private string LayMaChuPhong()
        {
            if (pnlChuPhong.Visible)
            {
                return UserSession.UserId;
            }
            else
            {
                // Lấy UC đầu tiên visible
                foreach (Control ctrl in flowPanelThanhVien.Controls)
                {
                    if (ctrl is UC_ThanhVien tv && tv.Visible)
                    {
                        return tv.MaDocGia;  // Return luôn cái đầu tiên
                    }
                }
                return null;
            }
        }

        // Hàm lưu danh sách thành viên
        private void LuuDanhSachThanhVien(SqlConnection conn, string maDatPhong)
        {
            string query = @"
                INSERT INTO Thanh_vien_phong (ma_dat_phong, ma_doc_gia)
                VALUES (@MaDatPhong, @MaDocGia)";

            bool isFirst = true;  // ✅ Flag để bỏ qua người đầu tiên

            foreach (Control ctrl in flowPanelThanhVien.Controls)
            {
                if (ctrl is UC_ThanhVien tv && tv.Visible)
                {
                    // Bỏ qua Chủ phòng (người đầu tiên)
                    if (isFirst)
                    {
                        isFirst = false;
                        continue;
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDatPhong", maDatPhong);
                        cmd.Parameters.AddWithValue("@MaDocGia", tv.MaDocGia);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnThemNguoi_Click(object sender, EventArgs e)
        {
            frmTimKiem frm = new frmTimKiem();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ThemThanhVien(frm.SelectedMaDocGia, frm.SelectedTen, frm.SelectedEmail);
            }
        }

        // Thêm thành viên
        private void ThemThanhVien(string maDocGia, string ten, string email)
        {
            // Kiểm tra trùng
            foreach (var tv in danhSachThanhVien)
            {
                if (tv.Visible && tv.Email == email)
                {
                    MessageBox.Show($"Thành viên \"{ten}\" ({email}) đã được thêm vào danh sách!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }
            }

            // Tạo thẻ mới
            UC_ThanhVien thanhVien = new UC_ThanhVien(maDocGia, ten, email);
            danhSachThanhVien.Add(thanhVien);
            flowPanelThanhVien.Controls.Add(thanhVien);

            // ===== QUAN TRỌNG: Cập nhật tất cả label sau khi add =====
            CapNhatTatCaLoai();
        }

        // Method PUBLIC để cập nhật tất cả label
        public void CapNhatTatCaLoai()
        {
            bool isFirst = true;

            foreach (Control ctrl in flowPanelThanhVien.Controls)
            {
                if (ctrl is UC_ThanhVien tv && tv.Visible)
                {
                    if (isFirst)
                    {
                        tv.LblLoai.Text = "Chủ phòng:";
                        isFirst = false;
                    }
                    else
                    {
                        tv.LblLoai.Text = "Thành viên:";
                    }
                }
            }
        }

        private void flowPanelThanhVien_Layout(object sender, LayoutEventArgs e)
        {
            // Khi FlowLayout xếp lại → Update tất cả label
            CapNhatTatCaLoai();
        }
    }
}
