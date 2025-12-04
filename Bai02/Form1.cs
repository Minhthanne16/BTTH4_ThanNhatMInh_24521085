using System;
using System.Windows.Forms;

namespace Bai02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void ShowTime()
        {
            DateTime now = DateTime.Now;

            lblTime.Text = now.ToString("dddd, MMMM dd, yyyy hh:mm:ss tt");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ShowTime();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowTime();
        }
    }
}
