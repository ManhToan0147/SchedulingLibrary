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
    public partial class frmFilter : Form
    {
        public frmFilter()
        {
            InitializeComponent();
        }

        private void frmFilter_Deactivate(object sender, EventArgs e)
        {
            this.Close();
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

            if (chkWifi.Checked) conditions.Add("p.wifi = 1");
            if (chkMayChieu.Checked) conditions.Add("p.may_chieu = 1");
            if (chkDieuHoa.Checked) conditions.Add("p.dieu_hoa = 1");
            if (chkManHinh.Checked) conditions.Add("p.man_hinh = 1");
            if (chkBangKinh.Checked) conditions.Add("p.bang_kinh = 1");
            if (rdbCanDuyet.Checked) conditions.Add("p.loai_phong = N'Cần duyệt'");
            if (rdbTuDongDuyet.Checked) conditions.Add("p.loai_phong = N'Tự động duyệt'");

            FilterCondition = conditions.Count > 0 ? string.Join(" AND ", conditions) : "";

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            rdbTu5Cho.Checked = false;
            rdbTu10Cho.Checked = false;
            rdbTu15Cho.Checked = false;
            rdbChinhXac.Checked = false;
            txtSoCho.Text = "";
            chkWifi.Checked = false;
            chkMayChieu.Checked = false;
            chkDieuHoa.Checked = false;
            chkManHinh.Checked = false;
            chkBangKinh.Checked = false;
            rdbCanDuyet.Checked = false;
            rdbTuDongDuyet.Checked = false;

        }

        private void frmFilter_Load(object sender, EventArgs e)
        {

        }
    }
}
