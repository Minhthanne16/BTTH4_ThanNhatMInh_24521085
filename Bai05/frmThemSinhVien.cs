using System;
using System.Windows.Forms;

namespace Bai05
{
    public delegate void SendData(Student sv);

    public partial class frmThemSinhVien : Form
    {
        public SendData Sender;

        public frmThemSinhVien()
        {
            InitializeComponent();
            if (cmbKhoa.Items.Count > 0)
            {
                cmbKhoa.SelectedIndex = 0;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMSSV.Text) || string.IsNullOrEmpty(txtTenSV.Text) || string.IsNullOrEmpty(txtDiemTB.Text))
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin!");
                }

                float diemTB;
                bool isNumeric = float.TryParse(txtDiemTB.Text, out diemTB);

                if (!isNumeric)
                {
                    throw new Exception("Điểm trung bình phải là một số hợp lệ!");
                }

                if (diemTB < 0 || diemTB > 10)
                {
                    throw new Exception("Điểm trung bình phải nằm trong khoảng từ 0 đến 10!");
                }

                Student sv = new Student();
                sv.MSSV = txtMSSV.Text;
                sv.TenSinhVien = txtTenSV.Text;
                sv.Khoa = cmbKhoa.Text;
                sv.DiemTB = diemTB;

                if (Sender != null)
                {
                    Sender(sv);
                }

                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtMSSV.Clear();
                txtTenSV.Clear();
                txtDiemTB.Clear();
                txtMSSV.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}