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
    public partial class frmSignIn : Form
    {
        private string connectionString = DBConfig.ConnectionString;
        private int loginAttempts = 0;
        private const int MAX_ATTEMPTS = 3;
        public frmSignIn()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            //Kiểm tra input trống
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập email!", "Thiếu thông tin",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thiếu thông tin",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            if (AuthenticateUser(email, matKhau))
            {
                 bool rememberMe = chkRememberMe.Checked;
                SessionManager.SaveSession(rememberMe);

                MessageBox.Show("Đăng nhập thành công!", "Thành công",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ✅ Mở Form1 và đóng form đăng nhập
                Form1 mainForm = new Form1();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                loginAttempts++;
                int remainingAttempts = MAX_ATTEMPTS - loginAttempts;

                if (remainingAttempts > 0)
                {
                    MessageBox.Show($"Email hoặc mật khẩu không đúng!\nCòn lại {remainingAttempts} lần thử.",
                                  "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // ✅ Clear password và focus lại
                    txtMatKhau.Clear();
                    txtEmail.Focus();
                }
                else
                {
                    MessageBox.Show("Bạn đã nhập sai quá 3 lần. Ứng dụng sẽ đóng!",
                                  "Hết lần thử", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                }
            }

        }

        private bool AuthenticateUser(string email, string matKhau)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT ma_doc_gia, ho_ten, quyen 
                                   FROM Doc_gia 
                                   WHERE email = @Email AND mat_khau = @MatKhau AND trang_thai = N'Hoạt động'";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@MatKhau", matKhau);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // ✅ Lưu thông tin user vào session (static class)
                                UserSession.UserId = reader["ma_doc_gia"].ToString();
                                UserSession.UserName = reader["ho_ten"].ToString();
                                UserSession.UserRole = reader["quyen"].ToString();
                                UserSession.LoginTime = DateTime.Now;
                                UserSession.UserEmail = email;
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        private void btnUnHide_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.UseSystemPasswordChar)
            {
                btnUnHide.BringToFront();
                btnUnHide.Image = Properties.Resources.eye_crossed__1_;
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                btnUnHide.BringToFront();
                btnUnHide.Image = Properties.Resources.eye__1_;
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMatKhau.Focus();
            }
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSignIn_Click(sender, e);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmSignIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
