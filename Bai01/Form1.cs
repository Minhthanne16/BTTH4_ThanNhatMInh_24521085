using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai01
{
    public partial class Form1 : Form
    {
        private string ThongTinKeycode;
        public Form1()
        {
            InitializeComponent();
        }
        //Xử lý sự kiện MouseClick của Form
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            string ThongTinChuot = $"Bạn vừa nhấn chuột tại vị trí X: {e.X}, Y: {e.Y}";
            label3.Text = ThongTinChuot;
            MessageBox.Show(ThongTinChuot, "Thông tin chuột");
        }
        //Xử lý sự kiện KeyDown của Form
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            ThongTinKeycode = $"THÔNG TIN PHÍM: \nKeycode: {e.KeyCode}";
            
            
        }
        //Xử lý sự kiện KeyPress của Form
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string ThongTinPhim = $"\nKý tự: {e.KeyChar}\n" +
                         $"Mã ASCII: {(int)e.KeyChar}\n \n";
            string ThongTinPhimFull = ThongTinKeycode + ThongTinPhim;
            label4.Text += ThongTinPhimFull;
            MessageBox.Show(ThongTinPhimFull, "Thông tin phím");
        }
    }
}
