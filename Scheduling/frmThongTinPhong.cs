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
    
    public partial class frmThongTinPhong : Form
    {
        private string connectionString = DBConfig.ConnectionString;

        public frmThongTinPhong()
        {
            InitializeComponent();
        }

        public void LoadRoomEquipments(string tenPhong)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT may_chieu, dieu_hoa, wifi, man_hinh, bang_kinh, suc_chua, dia_diem, loai_phong
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
                    lblDiaChi.Text = $"Thư viện Phạm Văn Đồng, {reader["dia_diem"]}";
                    lblSucChua.Text = $"Sức chứa: {reader["suc_chua"]}";
                    lblLoaiPhong.Text = $"{reader["loai_phong"]}";
                    lblTenPhong.Text = tenPhong; // Hiển thị tên phòng
                }
            }
        }

        private void frmThongTinPhong_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
