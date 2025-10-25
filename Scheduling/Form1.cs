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
    public partial class Form1 : Form
    {

        private string currentUserId = UserSession.UserId;
        private string currentUserName = UserSession.UserName;
        private string currentUserRole = UserSession.UserRole;

        private string connectionString = DBConfig.ConnectionString;
        public Form1()
        {
            InitializeComponent();
            LoadRoomSchedule();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            dtpNgayDatPhong.MaxDate = today.AddDays(7);
            if (UserSession.IsReader)
            {
                dtpNgayDatPhong.MinDate = today;
            }

            lblUser.Text = $"{currentUserName} - {currentUserRole}";
            LoadRoomSchedule();
        }

        private void LoadRoomSchedule(string filterCondition = "")
        {
            try
            {
                DateTime selectedDate = dtpNgayDatPhong.Value.Date;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GetRoomSchedulePivot", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NgayDat", selectedDate);
                        cmd.Parameters.AddWithValue("@FilterCondition",
                            string.IsNullOrEmpty(filterCondition) ? (object)DBNull.Value : filterCondition);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvLichDatPhong.DataSource = dt;
                        StyleDataGridView();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StyleDataGridView()
        {
            // Cấu hình DataGridView
            dgvLichDatPhong.AllowUserToAddRows = false;
            dgvLichDatPhong.AllowUserToDeleteRows = false;
            dgvLichDatPhong.ReadOnly = true;
            dgvLichDatPhong.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvLichDatPhong.MultiSelect = false;

            // ===== TÙY CHỈNH COLUMN HEADERS =====
            dgvLichDatPhong.ColumnHeadersDefaultCellStyle.Font = new Font("Sans Serif", 9, FontStyle.Bold);  // Font chữ
            dgvLichDatPhong.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;   // Màu nền
            dgvLichDatPhong.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;      // Màu chữ
            dgvLichDatPhong.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa
            dgvLichDatPhong.EnableHeadersVisualStyles = false;                          // QUAN TRỌNG: Cho phép custom style


            // Thiết lập hình vuông
            dgvLichDatPhong.RowHeadersVisible = false;
            dgvLichDatPhong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLichDatPhong.RowTemplate.Height = 80;
            dgvLichDatPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvLichDatPhong.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvLichDatPhong.GridColor = Color.Gray;

            // Tắt sorting cho các cột thời gian, chỉ cho phép sort cột tên phòng
            for (int i = 0; i < dgvLichDatPhong.Columns.Count; i++)
            {
                if (i == 0)
                {
                    dgvLichDatPhong.Columns[i].Width = 100;
                    dgvLichDatPhong.Columns[i].Frozen = true;
                    dgvLichDatPhong.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                    dgvLichDatPhong.Columns[i].DefaultCellStyle.BackColor = Color.LightBlue;
                    dgvLichDatPhong.Columns[i].DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                    dgvLichDatPhong.Columns[i].DefaultCellStyle.SelectionForeColor = Color.Black;
                    dgvLichDatPhong.Columns[i].DefaultCellStyle.Font = new Font("Sans Serif", 9, FontStyle.Bold);
                }
                else
                {
                    dgvLichDatPhong.Columns[i].Width = 80;
                    dgvLichDatPhong.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }

            // Style các cell theo trạng thái - CHỈ DỰA TRÊN VALUE

            // ✅ LOGIC MỚI: Style cells theo trạng thái + thời gian
            DateTime selectedDate = dtpNgayDatPhong.Value.Date;
            DateTime currentDateTime = DateTime.Now;

            // ✅ Check xem có phải thứ 7, CN không
            DayOfWeek dayOfWeek = selectedDate.DayOfWeek;
            bool isWeekend = (dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday);

            foreach (DataGridViewRow row in dgvLichDatPhong.Rows)
            {
                for (int i = 1; i < dgvLichDatPhong.Columns.Count; i++)
                {
                    DataGridViewCell cell = row.Cells[i];
                    string status = cell.Value?.ToString();

                    //Xu ly timeslot
                    string columnHeader = dgvLichDatPhong.Columns[i].HeaderText;
                    TimeSpan slotTime = TimeSpan.Parse(columnHeader);
                    DateTime slotDateTime = selectedDate.Add(slotTime);

                    // ✅ CASE 1: Thứ 7, CN -> Màu xám
                    if (isWeekend)
                    {
                        cell.Style.BackColor = Color.LightGray;
                        cell.Style.SelectionBackColor = Color.LightGray;
                        cell.Style.ForeColor = Color.DarkGray;
                        cell.Value = ""; // Chuỗi rỗng
                        continue;
                    }

                    // ✅ CASE 2: Giờ đã qua + Trống -> Màu xám (không cho đặt)
                    if (slotDateTime < currentDateTime && status == "Trống")
                    {
                        cell.Style.BackColor = Color.LightGray;
                        cell.Style.SelectionBackColor = Color.LightGray;
                        cell.Style.ForeColor = Color.DarkGray;
                        cell.Value = "";
                        continue;
                    }

                    /// ✅ CASE 3: Các trạng thái bình thường
                    switch (status)
                    {
                        case "Bận":
                            cell.Style.BackColor = Color.Red;
                            cell.Style.ForeColor = Color.White;
                            cell.Style.Font = new Font("Sans Serif", 9, FontStyle.Bold);
                            cell.Style.SelectionBackColor = Color.Red;
                            cell.Style.SelectionForeColor = Color.White;
                            break;

                        case "Trống":
                            cell.Style.BackColor = Color.LightGreen;
                            cell.Style.ForeColor = Color.Black;
                            cell.Style.Font = new Font("Sans Serif", 9, FontStyle.Regular);
                            cell.Style.SelectionBackColor = Color.LightGreen;
                            cell.Style.SelectionForeColor = Color.Black;
                            break;

                        case "Chọn":
                            cell.Style.BackColor = Color.Gold;
                            cell.Style.ForeColor = Color.Black;
                            cell.Style.Font = new Font("Sans Serif", 9, FontStyle.Bold);
                            cell.Style.SelectionBackColor = Color.Gold;
                            cell.Style.SelectionForeColor = Color.Black;
                            break;
                    }
                }
            }
        }

        private int lastSelectedRow = -1; // Track phòng đang chọn
        private string selectedRoomName = "";
        private void dgvLichDatPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                DataGridViewCell cell = dgvLichDatPhong[e.ColumnIndex, e.RowIndex];
                cell.Style.SelectionBackColor = Color.Yellow;
                cell.Style.SelectionForeColor = Color.Black;

                string tenPhong = cell.Value?.ToString();
                if (!string.IsNullOrEmpty(tenPhong))
                {
                    frmThongTinPhong frmTTP = new frmThongTinPhong();
                    frmTTP.LoadRoomInfo(tenPhong);
                    frmTTP.Show(this);
                }

                return;
            }

            if (e.RowIndex >= 0 && e.ColumnIndex > 0)
            {
                //Chọn phòng khác thì clear lựa chọn cũ
                if (lastSelectedRow != -1 && lastSelectedRow != e.RowIndex)
                {
                    ClearAllSelectedCells();
                }
                //Lưu lại phòng đang chọn
                selectedRoomName = dgvLichDatPhong.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
                lastSelectedRow = e.RowIndex;


                DataGridViewCell cell = dgvLichDatPhong[e.ColumnIndex, e.RowIndex];
                string currentStatus = cell.Value?.ToString();

                if (currentStatus == "Trống")
                {
                    
                    // Chuyển thành "Chọn"
                    cell.Value = "Chọn";

                    // Style ngay lập tức
                    cell.Style.BackColor = Color.Gold;
                    cell.Style.ForeColor = Color.Black;
                    cell.Style.Font = new Font("Sans Serif", 9, FontStyle.Bold);
                    cell.Style.SelectionBackColor = Color.Gold;
                    cell.Style.SelectionForeColor = Color.Black;

                    dgvLichDatPhong.InvalidateCell(cell);
                }
                else if (currentStatus == "Chọn")
                {
                    // Chuyển về "Trống"
                    cell.Value = "Trống";

                    // Style ngay lập tức
                    cell.Style.BackColor = Color.LightGreen;
                    cell.Style.ForeColor = Color.Black;
                    cell.Style.Font = new Font("Sans Serif", 9, FontStyle.Regular);
                    cell.Style.SelectionBackColor = Color.LightGreen;
                    cell.Style.SelectionForeColor = Color.Black;

                    dgvLichDatPhong.InvalidateCell(cell);
                }
                else if (currentStatus == "Bận")
                {
                    MessageBox.Show("Phòng đã được đặt!", "Thông báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ClearAllSelectedCells()
        {
            foreach (DataGridViewRow row in dgvLichDatPhong.Rows)
            {
                for (int col = 1; col < dgvLichDatPhong.Columns.Count; col++)
                {
                    if (row.Cells[col].Value?.ToString() == "Chọn")
                    {
                        row.Cells[col].Value = "Trống";
                        row.Cells[col].Style.BackColor = Color.LightGreen;
                        row.Cells[col].Style.ForeColor = Color.Black;
                        row.Cells[col].Style.Font = new Font("Sans Serif", 9, FontStyle.Regular);
                        row.Cells[col].Style.SelectionBackColor = Color.LightGreen;
                        row.Cells[col].Style.SelectionForeColor = Color.Black;
                    }
                }
            }
        }

        private void dtpNgayDatPhong_ValueChanged(object sender, EventArgs e)
        {
            LoadRoomSchedule(filterForm.FilterCondition);
        }

        //Muc dich luu trang thai da chon cua bo loc
        private frmFilter filterForm = new frmFilter();
        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (filterForm.ShowDialog() == DialogResult.OK)
            {
                LoadRoomSchedule(filterForm.FilterCondition);
            }
        }

        private void dgvLichDatPhong_Sorted(object sender, EventArgs e)
        {
            StyleDataGridView();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận đăng xuất",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                //Clear cả session trong memory và file
                UserSession.Clear();
                SessionManager.ClearSession(); // Quan trọng!

                frmSignIn SiginForm = new frmSignIn();
                SiginForm.Show();
                this.Hide();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private List<string> selectedTimeSlots
        {
            get
            {
                var slots = new List<string>();

                if (lastSelectedRow == -1) return slots;

                DataGridViewRow row = dgvLichDatPhong.Rows[lastSelectedRow];

                for (int col = 1; col < dgvLichDatPhong.Columns.Count; col++)
                {
                    if (row.Cells[col].Value?.ToString() == "Chọn")
                    {
                        string timeSlot = dgvLichDatPhong.Columns[col].HeaderText;
                        slots.Add(timeSlot);
                    }
                }

                return slots;
            }
        }
        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate
                if (selectedTimeSlots.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một khung giờ!", "Thông báo");
                    return;
                }

                if (!IsMinimum60Minutes())
                {
                    MessageBox.Show("Thời gian đặt phòng tối thiểu là 60 phút!", "Thông báo");
                    return;
                }

                if (!IsConsecutiveTimeSlots())
                {
                    MessageBox.Show("Các khung giờ phải liên tiếp nhau!", "Thông báo");
                    return;
                }

                // Mở form đặt phòng
                var frmDatPhong = new frmDatPhong();
                frmDatPhong.TenPhong = selectedRoomName;
                frmDatPhong.NgayDat = dtpNgayDatPhong.Value;
                frmDatPhong.SelectedTimeSlots = selectedTimeSlots.ToList();

                if (frmDatPhong.ShowDialog() == DialogResult.OK)
                {
                    LoadRoomSchedule(filterForm.FilterCondition);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi");
            }
        }

        private bool IsMinimum60Minutes()
        {
            return selectedTimeSlots.Count >= 2; // 2 slot = 60 phút
        }

        private bool IsConsecutiveTimeSlots()
        {
            if (selectedTimeSlots.Count <= 1) return true;

            var sortedSlots = selectedTimeSlots.OrderBy(x => x).ToList();

            for (int i = 0; i < sortedSlots.Count - 1; i++)
            {
                TimeSpan current = TimeSpan.Parse(sortedSlots[i]);
                TimeSpan next = TimeSpan.Parse(sortedSlots[i + 1]);

                if ((next - current).TotalMinutes != 30)
                {
                    return false;
                }
            }

            return true;
        }

        private void btnLichSuDat_Click(object sender, EventArgs e)
        {
            var frmLichSuDat = new frmLichSuDat();
            DialogResult result = frmLichSuDat.ShowDialog(this);

            // Chỉ refresh khi có thay đổi
            LoadRoomSchedule(filterForm.FilterCondition);
        }

        private void btnLichSuSuDung_Click(object sender, EventArgs e)
        {
            var frmLichSuSuDung = new frmLichSuSuDung();
            DialogResult result = frmLichSuSuDung.ShowDialog(this);
        }
    }
}
