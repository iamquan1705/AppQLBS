
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QLBS
{

   
    public partial class main : Form
    {
        string chuoiketnoi = @"Data Source=21AK22-COM;Initial Catalog=QUANLYBANSACH;Integrated Security=True";
        SqlConnection conn;
        public static string idLogin;
        public static string user;
        private string username;
        public int position;
        private bool check = false;
        public main()
        {
            InitializeComponent();
            
        }
        public main(string username, int position, bool check)
        {
            InitializeComponent();
            this.username = username;
            this.position = position;
            this.check = check;

        }


        public void phanQuyen(int po)
        {
            if (check == true)
            {
                quảnLýToolStripMenuItem.Enabled = true;
                danhMụcToolStripMenuItem.Enabled = true;
                nghiệpVụToolStripMenuItem.Enabled = true;
                tàiKhoảnToolStripMenuItem.Enabled = true;
                đăngNhậpToolStripMenuItem.Enabled = false;
                if (po == 0)
                {
                    quảnLýToolStripMenuItem.Enabled = false;
                    danhMụcToolStripMenuItem.Enabled = false;
                
                }
            }
        }


        private void mnuPhieuXuatSach_Click_1(object sender, EventArgs e)
        {

            phieunhap pn = new phieunhap();
            pn.ShowDialog();
        }

     
        private void mnuNhanVien_Click_1(object sender, EventArgs e)
        {
            nhanvien nv = new nhanvien();
            nv.Show();
        }

        private void tsbThongTinSach_Click_1(object sender, EventArgs e)
        {
            ttsach tt = new ttsach();
            tt.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            dangnhap dn = new dangnhap();
            dn.Show();
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tttaikhoan t = new tttaikhoan(username);
            t.ShowDialog();
        }

        private void mnuDMS_Click_1(object sender, EventArgs e)
        {
            ttsach t = new ttsach();
            t.ShowDialog();
        }

        private void mnuDMLS_Click_1(object sender, EventArgs e)
        {
            danhmuc d = new danhmuc();
            d.ShowDialog();
        }

        private void tácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tacgia tg = new tacgia();
           
            tg.ShowDialog();
        }

        private void thốngKêBáoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thongkedoanhthu tkdt = new thongkedoanhthu();
            tkdt.ShowDialog();
        }


        private void main_Load(object sender, EventArgs e)
        {
            phanQuyen(position);
           
        }

       

        private void nhàCungCấpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            nhacungcap ncc = new nhacungcap();
            ncc.ShowDialog();

        }

        private void kháchHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            khachhang kh = new khachhang();
            kh.ShowDialog();
        }

        private void nhânViênToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            nhanvien nv = new nhanvien();
            nv.ShowDialog();
        }


        private void phiếuNhậnSáchToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            phieunhap pn = new phieunhap();
            pn.ShowDialog();
        }

        private void phiếuXuấtSáchToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            phieuxuat pn = new phieuxuat();
            pn.ShowDialog();
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr;
            dr =MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
                Application.Exit();
            }
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dangnhap login = null;
            checkdangnhap:
            if (login == null || login.IsDisposed)
            {
                login = new dangnhap();
                login.Show();

            }
        }

        private void khoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kho k = new kho();
            k.ShowDialog();
        }
    }
}