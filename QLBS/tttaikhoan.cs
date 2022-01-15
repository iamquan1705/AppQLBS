
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QLBS
{
    public partial class tttaikhoan : Form
    {
        private string username;
        SqlCommand cmd = new SqlCommand();
        string chuoiketnoi = @"Data Source=21AK22-COM;Initial Catalog=QUANLYBANSACH;Integrated Security=True";
        SqlConnection conn;
        public tttaikhoan()
        {
            InitializeComponent();
        }
        public tttaikhoan(string username)
        {
            InitializeComponent();
            this.username = username;
            txtTenDangNhap.Text = username;
        }

        private void bntExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            string mkcu = txtMatKhauCu.Text;
            string mkmoi = txtMatKhauMoi.Text;
            string mkmoilai = txtNhapLaiMK.Text;
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();

            string sql_kt = "Select * from tb_taikhoan where username='" + username + "'";

            SqlDataAdapter Mydata = new SqlDataAdapter(sql_kt, conn);
            DataTable dt = new DataTable(); //tạo 1 bảng
                                            // đổ dữ liệu từ mydata vào bảng
            Mydata.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][1].ToString() == mkcu)
                {
                    if (mkmoi == mkmoilai)
                    {
                       
                        string sqlsua = "Update tb_taikhoan set password=N'" + mkmoi + "'  where username = N'" + username + "'";
                        SqlCommand cmd1 = new SqlCommand(sqlsua, conn);
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        conn.Close();
                    }
                    else
                    {
                        MessageBox.Show("Nhập lại mật khẩu mới không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Nhập mật khẩu cũ không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }
    }
}