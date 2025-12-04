using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Bai05
{
    public partial class Form1 : Form
    {
        private List<Student> listStudent = new List<Student>();

        public Form1()
        {
            InitializeComponent();
        }

        private void NhanDuLieu(Student sv)
        {
            listStudent.Add(sv);
            BindGrid(listStudent);
        }

        private void BindGrid(List<Student> list)
        {
            dgvStudent.Rows.Clear();
            foreach (var item in list)
            {
                int index = dgvStudent.Rows.Add();
                dgvStudent.Rows[index].Cells[0].Value = index + 1;
                dgvStudent.Rows[index].Cells[1].Value = item.MSSV;
                dgvStudent.Rows[index].Cells[2].Value = item.TenSinhVien;
                dgvStudent.Rows[index].Cells[3].Value = item.Khoa;
                dgvStudent.Rows[index].Cells[4].Value = item.DiemTB;
            }

            if (dgvStudent.Rows.Count > 0)
            {
                dgvStudent.Rows[0].Selected = true;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string tuKhoa = txtTimKiem.Text.Trim().ToLower();

                if (string.IsNullOrEmpty(tuKhoa))
                {
                    BindGrid(listStudent);
                }
                else
                {
                    var danhSachLoc = listStudent.Where(s => s.TenSinhVien.ToLower().Contains(tuKhoa)).ToList();
                    BindGrid(danhSachLoc);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemSinhVien f = new frmThemSinhVien();
            f.Sender = new SendData(NhanDuLieu);
            f.ShowDialog();
        }
    }
}