using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling
{
    public partial class frmFilter : Form
    {
        private string connectionString = DBConfig.ConnectionString;
        // ✅ Biến lưu RadioButton đang được chọn
        private RadioButton _lastCheckedRadioButton = null;

        //Lưu trữ tiện ích đã chọn trước đó (nếu cần)
        private List<string> _savedTienIch = new List<string>();
        public frmFilter()
        {
            InitializeComponent();

            // ✅ Gắn sự kiện Click cho các RadioButton
            rdbTuDongDuyet.Click += RadioButton_Click;
            rdbCanDuyet.Click += RadioButton_Click;

            rdbTu5Cho.Click += RadioButton_Click;
            rdbTu10Cho.Click += RadioButton_Click;
            rdbTu15Cho.Click += RadioButton_Click;
            rdbChinhXac.Click += RadioButton_Click;
        }

        private void frmFilter_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFilter_Load(object sender, EventArgs e)
        {
            LoadTienIch();
            KhoiPhucTrangThai();
        }
        private void RadioButton_Click(object sender, EventArgs e)
        {
            RadioButton rdb = sender as RadioButton;

            // ✅ Nếu click vào RadioButton đang checked → Uncheck
            if (rdb == _lastCheckedRadioButton)
            {
                rdb.Checked = false;
                _lastCheckedRadioButton = null;
            }
            else
            {
                _lastCheckedRadioButton = rdb;
            }
        }

        // ✅ Khôi phục trạng thái đã lưu
        private void KhoiPhucTrangThai()
        {
            // Khôi phục tiện ích đã chọn
            foreach (Control ctrl in flpTienIch.Controls)
            {
                if (ctrl is CheckBox chk)
                {
                    if (_savedTienIch.Contains(chk.Tag.ToString()))
                    {
                        chk.Checked = true;
                    }
                }
            }
        }

        private void LoadTienIch()
        {
            flpTienIch.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ma_tien_ich, ten_tien_ich FROM TienIch";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string ma = reader["ma_tien_ich"].ToString();
                        string ten = reader["ten_tien_ich"].ToString();

                        var chk = new CheckBox
                        {
                            Name = $"chk_{ma}",
                            Text = ten,
                            Tag = ma,
                            AutoSize = true,
                            Font = new Font("Segoe UI", 9.5F),
                            Margin = new Padding(5, 0, 5, 23), // ✅ Spacing 23px
                            Cursor = Cursors.Hand
                        };
                        flpTienIch.Controls.Add(chk);
                    }
                }
            }
        }

        public string FilterCondition { get; private set; } = "";
        private void btnFilter_Click(object sender, EventArgs e)
        {
            var conditions = new List<string>();

            if (rdbTu5Cho.Checked) conditions.Add("p.suc_chua >= 5");
            if (rdbTu10Cho.Checked) conditions.Add("p.suc_chua >= 10");
            if (rdbTu15Cho.Checked) conditions.Add("p.suc_chua >= 15");

            if (rdbChinhXac.Checked)
            {
                int soCho;
                if (int.TryParse(txtSoCho.Text, out soCho))
                {
                    errorProvider1.SetError(txtSoCho, ""); // Xóa báo lỗi nếu hợp lệ
                    conditions.Add($"p.suc_chua = {soCho}");
                }
                else
                {
                    errorProvider1.SetError(txtSoCho, "Vui lòng nhập số chỗ hợp lệ!");
                    txtSoCho.Focus();
                    return;
                }
            }

            if (rdbCanDuyet.Checked) conditions.Add("p.loai_phong = N'Cần duyệt'");
            if (rdbTuDongDuyet.Checked) conditions.Add("p.loai_phong = N'Tự động duyệt'");

            // Lấy các tiện ích được chọn
            _savedTienIch.Clear();
            var danhSachTienIch = new List<string>();

            foreach (Control ctrl in flpTienIch.Controls)
            {
                if (ctrl is CheckBox chk && chk.Checked)
                {
                    danhSachTienIch.Add(chk.Tag.ToString());
                    _savedTienIch.Add(chk.Tag.ToString());
                }
            }

            // Nếu có tiện ích được chọn
            if (danhSachTienIch.Count > 0)
            {
                var danhSachMaPhong = LayPhongCoTienIch(danhSachTienIch);

                if (danhSachMaPhong.Count > 0)
                {
                    var maPhongStr = string.Join(",", danhSachMaPhong.Select(ma => $"'{ma}'"));
                    conditions.Add($"p.ma_phong IN ({maPhongStr})");
                }
                else
                {
                    conditions.Add("1 = 0");
                }
            }

            FilterCondition = conditions.Count > 0 ? string.Join(" AND ", conditions) : "";

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        // Lấy danh sách mã phòng có đủ các tiện ích
        private List<string> LayPhongCoTienIch(List<string> danhSachMaTienIch)
        {
            var danhSachMaPhong = new List<string>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                var maTienIchStr = string.Join(",", danhSachMaTienIch.Select(ma => $"'{ma}'"));

                string query = $@"
                    SELECT tip.ma_phong
                    FROM TienIchPhong tip
                    WHERE tip.ma_tien_ich IN ({maTienIchStr})
                      AND tip.so_luong > 0
                    GROUP BY tip.ma_phong
                    HAVING COUNT(DISTINCT tip.ma_tien_ich) = {danhSachMaTienIch.Count}";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        danhSachMaPhong.Add(reader["ma_phong"].ToString());
                    }
                }
            }

            return danhSachMaPhong;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _savedTienIch.Clear();
            rdbTu5Cho.Checked = false;
            rdbTu10Cho.Checked = false;
            rdbTu15Cho.Checked = false;
            rdbChinhXac.Checked = false;
            txtSoCho.Text = "";
            errorProvider1.SetError(txtSoCho, "");

            rdbCanDuyet.Checked = false;
            rdbTuDongDuyet.Checked = false;

            foreach (Control ctrl in flpTienIch.Controls)
            {
                if (ctrl is CheckBox chk)
                {
                    chk.Checked = false;
                }
            }
        }

        private void rdbTuDongDuyet_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbCanDuyet_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
