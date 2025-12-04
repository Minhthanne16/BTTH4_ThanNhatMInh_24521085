using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string s = String.Format("Hôm nay là ngày {0:dd/MM/yyyy} - Bây giờ là {0:hh:mm:ss tt}", DateTime.Now);
            lblStatus.Text = s;

         
            
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                axWindowsMediaPlayer1.URL = openFileDialog1.FileName;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.uiMode = "full";

            // 2. Cho phép video co giãn theo khung
            axWindowsMediaPlayer1.stretchToFit = true;

            // 3. Đảm bảo control được bật
            axWindowsMediaPlayer1.Enabled = true;
        }
    }
}
