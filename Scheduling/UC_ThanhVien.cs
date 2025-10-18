using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling
{
    public partial class UC_ThanhVien : UserControl
    {
        public string MaDocGia {  get; set; }   
        public string TenDocGia { get; set; }
        public string Email { get; set; }

        // ✅ Expose nút X ra ngoài
        public Button BtnXoa => btnXoa;

        // ✅ Expose label Loại ra ngoài
        public Label LblLoai => lblLoai;

        //Truyen thong
        //public Button BtnXoa
        //{
        //    get
        //    {
        //        return btnXoa;
        //    }
        //}

        public UC_ThanhVien(string maDocGia, string ten, string email)
        {
            InitializeComponent();
            MaDocGia = maDocGia;
            TenDocGia = ten;
            Email = email;

            lblTenDocGia.Text = ten;
            lblEmail.Text = email;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
