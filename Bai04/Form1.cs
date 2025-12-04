using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Bai04
{
    public partial class Form1 : Form
    {
        private string duongDanHienTai = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (FontFamily font in FontFamily.Families)
            {
                cmbFont.Items.Add(font.Name);
            }

            int[] sizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (int s in sizes)
            {
                cmbSize.Items.Add(s);
            }

            cmbFont.SelectedItem = "Tahoma";
            cmbSize.SelectedItem = 14;
            rtbVanBan.Font = new Font("Tahoma", 14);
        }

        private void XuLyTaoMoi(object sender, EventArgs e)
        {
            rtbVanBan.Clear();
            duongDanHienTai = "";
            cmbFont.SelectedItem = "Tahoma";
            cmbSize.SelectedItem = 14;
            rtbVanBan.Font = new Font("Tahoma", 14);
        }

        private void XuLyMoTapTin(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Rich Text Format (*.rtf)|*.rtf|Text Files (*.txt)|*.txt";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    duongDanHienTai = openFileDialog1.FileName;
                    if (Path.GetExtension(duongDanHienTai).ToLower() == ".txt")
                    {
                        rtbVanBan.Text = File.ReadAllText(duongDanHienTai);
                    }
                    else
                    {
                        rtbVanBan.LoadFile(duongDanHienTai);
                    }
                    MessageBox.Show("Mở file thành công!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi khi đọc file!");
                }
            }
        }

        private void XuLyLuu(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(duongDanHienTai))
            {
                saveFileDialog1.Filter = "Rich Text Format (*.rtf)|*.rtf";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    duongDanHienTai = saveFileDialog1.FileName;
                    rtbVanBan.SaveFile(duongDanHienTai);
                    MessageBox.Show("Lưu file thành công!");
                }
            }
            else
            {
                rtbVanBan.SaveFile(duongDanHienTai);
                MessageBox.Show("Đã cập nhật nội dung!");
            }
        }

        private void DoiKieuChu(FontStyle kieuMoi)
        {
            if (rtbVanBan.SelectionFont != null)
            {
                Font fontCu = rtbVanBan.SelectionFont;
                FontStyle styleMoi;

                if (fontCu.Style.HasFlag(kieuMoi))
                    styleMoi = fontCu.Style & ~kieuMoi;
                else
                    styleMoi = fontCu.Style | kieuMoi;

                rtbVanBan.SelectionFont = new Font(fontCu.FontFamily, fontCu.Size, styleMoi);
            }
        }

        private void btnBold_Click(object sender, EventArgs e) { DoiKieuChu(FontStyle.Bold); }

        private void btnItalic_Click(object sender, EventArgs e) { DoiKieuChu(FontStyle.Italic); }

        private void btnUnderline_Click(object sender, EventArgs e) { DoiKieuChu(FontStyle.Underline); }

        private void mnuDinhDangFont_Click(object sender, EventArgs e)
        {
            if (rtbVanBan.SelectionFont != null)
                fontDialog1.Font = rtbVanBan.SelectionFont;

            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                rtbVanBan.SelectionFont = fontDialog1.Font;

                cmbFont.Text = fontDialog1.Font.Name;
                cmbSize.Text = fontDialog1.Font.Size.ToString();
            }
        }

        private void cmbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rtbVanBan.SelectionFont != null)
                {
                    string tenFont = cmbFont.Text;

                    if (!cmbFont.Items.Contains(tenFont))
                    {
                        MessageBox.Show("Font chữ này không tồn tại trong hệ thống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbFont.Text = rtbVanBan.SelectionFont.Name;
                        return;
                    }
                    rtbVanBan.SelectionFont = new Font(tenFont, rtbVanBan.SelectionFont.Size, rtbVanBan.SelectionFont.Style);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi định dạng Font: " + ex.Message);
            }
        }

        private void cmbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rtbVanBan.SelectionFont != null)
                {
                    float sizeMoi;
                    bool laSo = float.TryParse(cmbSize.Text, out sizeMoi);

                    if (laSo == false)
                    {
                        MessageBox.Show("Vui lòng nhập kích cỡ là số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbSize.Text = rtbVanBan.SelectionFont.Size.ToString();
                        return;
                    }

                    if (sizeMoi <= 0)
                    {
                        MessageBox.Show("Kích cỡ chữ phải lớn hơn 0!", "Cảnh báo");
                        cmbSize.Text = rtbVanBan.SelectionFont.Size.ToString();
                        return;
                    }
                    rtbVanBan.SelectionFont = new Font(rtbVanBan.SelectionFont.FontFamily, sizeMoi, rtbVanBan.SelectionFont.Style);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đổi kích cỡ: " + ex.Message);
            }
        }

        private void cmbFont_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                string tenFont = cmbFont.Text;
                if (!cmbFont.Items.Contains(tenFont))
                {
                    MessageBox.Show("Font này không tồn tại!", "Thông báo");
                    if (rtbVanBan.SelectionFont != null)
                        cmbFont.Text = rtbVanBan.SelectionFont.Name;
                    return;
                }

                if (rtbVanBan.SelectionFont != null)
                {
                    Font currentFont = rtbVanBan.SelectionFont;
                    rtbVanBan.SelectionFont = new Font(tenFont, currentFont.Size, currentFont.Style);
                    rtbVanBan.Focus();
                }
            }
        }

        private void cmbSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                float sizeMoi;
                bool laSo = float.TryParse(cmbSize.Text, out sizeMoi);

                if (laSo == false || sizeMoi <= 0)
                {
                    MessageBox.Show("Cỡ chữ không hợp lệ!", "Thông báo");
                    if (rtbVanBan.SelectionFont != null)
                        cmbSize.Text = rtbVanBan.SelectionFont.Size.ToString();
                    return;
                }

                if (rtbVanBan.SelectionFont != null)
                {
                    Font currentFont = rtbVanBan.SelectionFont;
                    rtbVanBan.SelectionFont = new Font(currentFont.FontFamily, sizeMoi, currentFont.Style);
                    rtbVanBan.Focus();
                }
            }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (rtbVanBan.TextLength > 0)
            {
                DialogResult ketQua = MessageBox.Show(
                    "Văn bản chưa được lưu. Bạn có muốn lưu lại trước khi thoát không?",
                    "Thông báo",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);

                if (ketQua == DialogResult.Yes)
                {
                    XuLyLuu(sender, e);
                }
                else if (ketQua == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}