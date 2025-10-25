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

        public void LoadRoomInfo(string tenPhong)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Query thông tin phòng
                string queryPhong = @"
                    SELECT ten_phong, suc_chua, dia_diem, loai_phong
                    FROM Phong
                    WHERE ten_phong = @tenPhong";

                using (SqlCommand cmd = new SqlCommand(queryPhong, conn))
                {
                    cmd.Parameters.AddWithValue("@tenPhong", tenPhong);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblTenPhong.Text = reader["ten_phong"].ToString();
                            lblDiaChi.Text = $"• Thư viện Phạm Văn Đồng, {reader["dia_diem"]}";
                            lblSucChua.Text = $"Sức chứa: {reader["suc_chua"]}";
                            lblLoaiPhong.Text = reader["loai_phong"].ToString();
                        }
                    }
                }

                // ✅ Query tiện ích
                string queryTienIch = @"
                    SELECT t.ten_tien_ich, tp.so_luong
                    FROM TienIchPhong tp
                    JOIN TienIch t ON tp.ma_tien_ich = t.ma_tien_ich
                    JOIN Phong p ON tp.ma_phong = p.ma_phong
                    WHERE p.ten_phong = @tenPhong";

                flpTienIch.Controls.Clear(); // Clear FlowLayoutPanel

                using (SqlCommand cmd = new SqlCommand(queryTienIch, conn))
                {
                    cmd.Parameters.AddWithValue("@tenPhong", tenPhong);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            // Không có tiện ích
                            var lblEmpty = new Label
                            {
                                Text = "Không có tiện ích",
                                AutoSize = true,
                                Font = new Font("Segoe UI", 10F),
                                ForeColor = Color.Gray
                            };
                            flpTienIch.Controls.Add(lblEmpty);
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                string tenTienIch = reader["ten_tien_ich"].ToString();
                                string soLuong = reader["so_luong"].ToString(); 

                                // ✅ Tạo Label cho từng tiện ích
                                var lbl = new Label
                                {
                                    Text = $"• {tenTienIch}: {soLuong}",
                                    AutoSize = true,
                                    Font = new Font("Segoe UI", 10F),
                                    Margin = new Padding(0, 0, 0, 7)
                                };
                                flpTienIch.Controls.Add(lbl);
                            }
                        }
                    }
                }
            }
        }

        private void frmThongTinPhong_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
