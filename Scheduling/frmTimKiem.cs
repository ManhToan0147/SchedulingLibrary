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
    public partial class frmTimKiem : Form
    {
        private Timer searchTimer;
        public string SelectedMaDocGia {  get; set; }
        public string SelectedTen { get;  set; }
        public string SelectedEmail { get;  set; }
        public frmTimKiem()
        {
            InitializeComponent();
            pnlThongTin.Visible = false;

            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.Cursor = Cursors.Hand;

            // ===== TẮT TẤT CẢ HIỆU ỨNG =====
            btnThoat.FlatAppearance.MouseOverBackColor = Color.Black; // Giữ nguyên màu đen
            btnThoat.FlatAppearance.MouseDownBackColor = Color.Black; // Giữ nguyên màu đen


            // Setup timer để tránh query liên tục khi đang gõ
            searchTimer = new Timer();
            searchTimer.Interval = 500; // Đợi 500ms sau khi user ngừng gõ
            searchTimer.Tick += SearchTimer_Tick;

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            // Reset timer mỗi khi user gõ
            searchTimer.Stop();
            searchTimer.Start();

            if (txtEmail.Text == "")
            {
                pnlSearch.BackColor = Color.White;
                txtEmail.BackColor = Color.White;
            }

        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            SearchEmail();
        }

        private void SearchEmail()
        {
            string emailSearch = txtEmail.Text.Trim();

            // Nếu rỗng, ẩn panel
            if (string.IsNullOrEmpty(emailSearch))
            {
                pnlThongTin.Visible = false;
                lblTenDocGia.Text = "";
                lblEmail.Text = "";
                return;
            }

            // Query database
            using (SqlConnection conn = new SqlConnection(DBConfig.ConnectionString))
            {
                try
                {
                    conn.Open();

                    // Chỉ lấy TOP 1 bản ghi
                    string query = @"SELECT TOP 1 ma_doc_gia, email, ho_ten 
                               FROM Doc_gia 
                               WHERE email LIKE @Email
                               ORDER BY email";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Tìm kiếm theo từng từ với LIKE
                        cmd.Parameters.AddWithValue("@Email", "%" + emailSearch + "%");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Tìm thấy -> Hiển thị thông tin
                                SelectedMaDocGia = reader["ma_doc_gia"].ToString();
                                SelectedTen = reader["ho_ten"].ToString();
                                SelectedEmail = reader["email"].ToString();

                                lblTenDocGia.Text = SelectedTen;
                                lblEmail.Text = SelectedEmail;
                                pnlThongTin.Visible = true;
                                //Cho biet la tim thay
                                pnlSearch.BackColor = Color.AliceBlue;
                                txtEmail.BackColor = Color.AliceBlue;
                            }
                            else
                            {
                                // Không tìm thấy -> Ẩn panel
                                pnlThongTin.Visible = false;
                                lblTenDocGia.Text = "";
                                lblEmail.Text = "";
                                //Cho biet la khong tim thay
                                pnlSearch.BackColor = Color.White;
                                txtEmail.BackColor = Color.White;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối database: " + ex.Message,
                                  "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pnlThongTin.Visible = false;
                }
            }

        }

        private void pnlSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtEmail.Clear();
            txtEmail.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email")
            {
                txtEmail.Clear();
                txtEmail.Focus();
            }
        }

        private void pnlThongTin_DoubleClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
