using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Bai06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pbTienDo.Value = 0;
            lblStatus.Text = "Sẵn sàng.";
        }

        private void btnChonNguon_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Chọn thư mục chứa các tập tin cần chép";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtNguon.Text = dlg.SelectedPath;
                }
            }
        }

        private void btnChonDich_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Chọn thư mục lưu trữ";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtDich.Text = dlg.SelectedPath;
                }
            }
        }

        private void btnSaoChep_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNguon.Text) || string.IsNullOrEmpty(txtDich.Text))
            {
                MessageBox.Show("Vui lòng chọn đủ nguồn và đích!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!bgWorker.IsBusy)
            {
                pbTienDo.Value = 0;
                btnSaoChep.Enabled = false;
                lblStatus.Text = "Đang tính toán dữ liệu...";
                bgWorker.RunWorkerAsync();
            }
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string sourceDir = txtNguon.Text;
            string destDir = txtDich.Text;

            string[] files = Directory.GetFiles(sourceDir, "*.*", SearchOption.AllDirectories);

            if (files.Length == 0)
            {
                throw new Exception("Thư mục nguồn trống rỗng hoặc không chứa file nào!");
            }

            long totalBytesAllFiles = 0;
            foreach (string file in files)
            {
                totalBytesAllFiles += new FileInfo(file).Length;
            }

            long totalBytesCopied = 0;
            byte[] buffer = new byte[1024 * 1024];

            foreach (string file in files)
            {
                string relativePath = file.Substring(sourceDir.Length + 1);
                string destFile = Path.Combine(destDir, relativePath);

                Directory.CreateDirectory(Path.GetDirectoryName(destFile));

                bgWorker.ReportProgress((int)((double)totalBytesCopied / totalBytesAllFiles * 100), Path.GetFileName(file));

                using (FileStream fsSource = new FileStream(file, FileMode.Open, FileAccess.Read))
                using (FileStream fsDest = new FileStream(destFile, FileMode.Create, FileAccess.Write))
                {
                    int readBytes;
                    while ((readBytes = fsSource.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fsDest.Write(buffer, 0, readBytes);
                        totalBytesCopied += readBytes;

                        if (totalBytesAllFiles > 0)
                        {
                            int percentage = (int)((double)totalBytesCopied / totalBytesAllFiles * 100);
                            bgWorker.ReportProgress(percentage, Path.GetFileName(file));
                        }
                    }
                }
            }
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbTienDo.Value = e.ProgressPercentage;

            string currentFileName = e.UserState as string;
            if (!string.IsNullOrEmpty(currentFileName))
            {
                lblStatus.Text = "Đang sao chép: " + currentFileName;
            }
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSaoChep.Enabled = true;

            if (e.Error != null)
            {
                lblStatus.Text = "Lỗi: " + e.Error.Message;
                MessageBox.Show("Lỗi: " + e.Error.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                pbTienDo.Value = 100;
                lblStatus.Text = "Hoàn tất.";
                MessageBox.Show("Đã sao chép toàn bộ thư mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}