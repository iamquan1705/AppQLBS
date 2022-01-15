
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QLBS
{
    public partial class dangnhap : Form
    {
        SqlCommand cmd = new SqlCommand();
        string chuoiketnoi = @"Data Source=21AK22-COM;Initial Catalog=QUANLYBANSACH;Integrated Security=True";
        SqlConnection conn;
        public dangnhap()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txtuser.Text;
            string password = txtpass.Text;
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();

            string sql_kt = "Select * from tb_taikhoan where username='" + username + "'and password='" + password + "' ";

            SqlDataAdapter Mydata = new SqlDataAdapter(sql_kt, conn);
            DataTable dt = new DataTable(); //tạo 1 bảng
                                            // đổ dữ liệu từ mydata vào bảng
            Mydata.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if (Int32.Parse(dt.Rows[0][2].ToString()) == 1)
                {
                    MessageBox.Show("Chào admin!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);

                }
                else
                {
                    MessageBox.Show("Chào nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);

                }
                main f = new main(txtuser.Text,Int32.Parse(dt.Rows[0][2].ToString()), true);
                foreach (Form form in Application.OpenForms)
                {
                    form.Hide();
                }

                f.Show();
                

            }
            else
            {
                MessageBox.Show("Tên hoặc mật khâu không đúng", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
        }

        private void dangnhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
                Application.Exit();
            }
        }

    }
}