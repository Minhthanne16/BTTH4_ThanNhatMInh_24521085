using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            // Load danh sách Font chữ hệ thống vào ComboBox
            foreach (FontFamily font in FontFamily.Families)
            {
                cmbFont.Items.Add(font.Name);
            }

            // Load danh sách Size (từ 8 đến 72 như đề bài)
            int[] sizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (int s in sizes)
            {
                cmbSize.Items.Add(s);
            }

            // Thiết lập mặc định: Tahoma, Size 14
            cmbFont.SelectedItem = "Tahoma";
            cmbSize.SelectedItem = 14;
            rtbVanBan.Font = new Font("Tahoma", 14);
        }
        // 2. CHỨC NĂNG TẠO MỚI (New)
        // Gán hàm này cho sự kiện Click của: Menu Tạo mới VÀ Button New
        private void XuLyTaoMoi(object sender, EventArgs e)
        {
            rtbVanBan.Clear(); // Xóa trắng
            duongDanHienTai = ""; // Reset đường dẫn

            // Reset về Font mặc định
            cmbFont.SelectedItem = "Tahoma";
            cmbSize.SelectedItem = 14;
            rtbVanBan.Font = new Font("Tahoma", 14);
        }

        // 3. CHỨC NĂNG MỞ FILE (Open)
        // Gán hàm này cho sự kiện Click của Menu Mở
        private void XuLyMoTapTin(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Rich Text Format (*.rtf)|*.rtf|Text Files (*.txt)|*.txt";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    duongDanHienTai = openFileDialog1.FileName;

                    // Kiểm tra đuôi file để dùng hàm đọc phù hợp
                    if (Path.GetExtension(duongDanHienTai).ToLower() == ".txt")
                    {
                        rtbVanBan.Text = File.ReadAllText(duongDanHienTai);
                    }
                    else
                    {
                        rtbVanBan.LoadFile(duongDanHienTai); // Mặc định đọc RTF
                    }
                    MessageBox.Show("Mở file thành công!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi khi đọc file!");
                }
            }
        }

        // 4. CHỨC NĂNG LƯU FILE (Save)
        // Gán hàm này cho sự kiện Click của: Menu Lưu VÀ Button Save
        private void XuLyLuu(object sender, EventArgs e)
        {
            // Nếu là file mới (chưa có đường dẫn) -> Hiện bảng chọn nơi lưu
            if (string.IsNullOrEmpty(duongDanHienTai))
            {
                saveFileDialog1.Filter = "Rich Text Format (*.rtf)|*.rtf";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    duongDanHienTai = saveFileDialog1.FileName;
                    rtbVanBan.SaveFile(duongDanHienTai);
                    MessageBox.Show("Lưu thành công!");
                }
            }
            else // Nếu file đã có sẵn -> Lưu đè luôn
            {
                rtbVanBan.SaveFile(duongDanHienTai);
                MessageBox.Show("Đã cập nhật nội dung!");
            }
        }

        // 5. CHỨC NĂNG ĐỊNH DẠNG (B, I, U)
        // Hàm dùng chung để đổi kiểu chữ
        private void DoiKieuChu(FontStyle kieuMoi)
        {
            // Kiểm tra xem có đang chọn văn bản không
            if (rtbVanBan.SelectionFont != null)
            {
                Font fontCu = rtbVanBan.SelectionFont;
                FontStyle styleMoi;

                // Nếu đang có kiểu đó rồi thì bỏ đi, chưa có thì thêm vào (Toán tử XOR)
                if (fontCu.Style.HasFlag(kieuMoi))
                    styleMoi = fontCu.Style & ~kieuMoi; // Bỏ
                else
                    styleMoi = fontCu.Style | kieuMoi;  // Thêm

                rtbVanBan.SelectionFont = new Font(fontCu.FontFamily, fontCu.Size, styleMoi);
            }
        }

        // Gán vào Button B
        private void btnBold_Click(object sender, EventArgs e) { DoiKieuChu(FontStyle.Bold); }

        // Gán vào Button I
        private void btnItalic_Click(object sender, EventArgs e) { DoiKieuChu(FontStyle.Italic); }

        // Gán vào Button U
        private void btnUnderline_Click(object sender, EventArgs e) { DoiKieuChu(FontStyle.Underline); }

        // 6. CHỨC NĂNG MENU "ĐỊNH DẠNG FONT" (Dùng FontDialog)
        private void mnuDinhDangFont_Click(object sender, EventArgs e)
        {
            // Lấy font hiện tại gán vào hộp thoại
            if (rtbVanBan.SelectionFont != null)
                fontDialog1.Font = rtbVanBan.SelectionFont;

            // Hiện hộp thoại
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                rtbVanBan.SelectionFont = fontDialog1.Font;

                // Cập nhật lại 2 cái ComboBox cho khớp
                cmbFont.Text = fontDialog1.Font.Name;
                cmbSize.Text = fontDialog1.Font.Size.ToString();
            }
        }

        // 7. CHỨC NĂNG ĐỔI FONT/SIZE TRÊN TOOLBAR
        // Gán vào sự kiện SelectedIndexChanged của cmbFont
        private void cmbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rtbVanBan.SelectionFont != null)
            {
                rtbVanBan.SelectionFont = new Font(cmbFont.Text, rtbVanBan.SelectionFont.Size, rtbVanBan.SelectionFont.Style);
            }
        }

        // Gán vào sự kiện SelectedIndexChanged của cmbSize
        private void cmbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rtbVanBan.SelectionFont != null)
            {
                float sizeMoi = float.Parse(cmbSize.Text);
                rtbVanBan.SelectionFont = new Font(rtbVanBan.SelectionFont.FontFamily, sizeMoi, rtbVanBan.SelectionFont.Style);
            }
        }

        // Menu Thoát
        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
