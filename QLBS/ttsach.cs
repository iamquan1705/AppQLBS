
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QLBS
{
    public partial class ttsach : Form
    {
        public ttsach()
        {
            InitializeComponent();
        }
       
        string chuoiketnoi = @"Data Source=21AK22-COM;Initial Catalog=QUANLYBANSACH;Integrated Security=True";
        SqlConnection conn;
        private int maLoaiSach;
        private int maTacGia;
        private void ttsach_Load(object sender, EventArgs e)
        {
            Hienthi_DGView();
            tacgia();
            loaisach();
            conn.Close();
        }
        private void loaisach()
        {
            string Sql1 = "select tenLoaiSach from tb_loaisach";
            SqlConnection conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            SqlCommand cmd1 = new SqlCommand(Sql1, conn);
            SqlDataReader DR = cmd1.ExecuteReader();

            while (DR.Read())
            {
                cbbloaisach.Items.Add(DR[0]);

            }
        }
        private void tacgia()
        {
            string Sql1 = "select tenTacGia from tb_tacgia";
            SqlConnection conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            SqlCommand cmd1 = new SqlCommand(Sql1, conn);
            SqlDataReader DR1 = cmd1.ExecuteReader();
            while (DR1.Read())
            {
                cbbtacgia.Items.Add(DR1[0]);

            }


        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();

            int loaisach = maLoaiSach;
            string tenSach = txtTenSach.Text;
            int tacgia = maTacGia;
            string namXuatBan = dtpNamXB.Text;
            string giaSach = txtGiaSach.Text;

            string sqlthem = "Insert into tb_sach values(N'" + loaisach + "',N'" + tenSach + "',N'" + tacgia + "',N'" + namXuatBan + "','" + giaSach + "')";
            //khai báo và khởi tạo đối tượng sql command


            SqlCommand cmd2 = new SqlCommand(sqlthem, conn);
            // thực thi truy vấn


            cmd2.ExecuteNonQuery();
            XoaDL();
            Hienthi_DGView();
            conn.Close();

        }
        private void Hienthi_DGView()
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            string sach = "Select tb_sach.maSach,tb_loaiSach.tenLoaiSach,tb_sach.tenSach,tb_tacgia.tenTacGia,tb_sach.namXuatBan,tb_sach.giaSach from tb_sach,tb_tacgia,tb_loaisach where tb_sach.maTacGia=tb_tacgia.maTacGia and tb_sach.maLoaiSach=tb_loaisach.maLoaiSach";
            //tạo đối tượng data adapter =>có csdl
            SqlDataAdapter Mydata = new SqlDataAdapter(sach, conn);
            // mydata có dữ liệu=>đổ dữ liệu từ mydata vào bảng
            DataTable dt = new DataTable(); //tạo 1 bảng
            // đổ dữ liệu từ mydata vào bảng
            Mydata.Fill(dt);
            dgvsach.DataSource = dt;
            conn.Close();

        }
        private void XoaDL()
        {
            txtMaSach.Clear();
            txtGiaSach.Clear();
            dtpNamXB.ResetText();
            txtTenSach.Clear();
           
            Hienthi_DGView();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            XoaDL();
            Hienthi_DGView();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            if (txtMaSach.Text == "")
            {
                MessageBox.Show("Chưa chọn sách cần sửa ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSach.Focus();
            }
            else
            {
                int tg = Int32.Parse( txtMaSach.Text);
                int mls = maLoaiSach;
                string tensach = txtTenSach.Text;
                int mtg = maTacGia;
                string namXuatBan = dtpNamXB.Text;
                string giaSach = txtGiaSach.Text;
             //   string soLuong = txtSoLuong.Text;
                string sql_update = "Update tb_sach set maLoaiSach=N'" + mls + "',tenSach=N'" + tensach + "',maTacGia=N'" + mtg + "',namXuatBan=N'" + namXuatBan + "',giaSach='"+giaSach+"' where maSach = N'" + tg + "' ";
                SqlCommand cmd = new SqlCommand(sql_update, conn);
                DialogResult Rsulet = MessageBox.Show("Bạn có chắc chắn muốn sửa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Rsulet == DialogResult.OK)
                {
                    cmd.ExecuteNonQuery();
                    Hienthi_DGView();
                    XoaDL();
                }
            }

            conn.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //KẾT NỐI , MỞ KẾT NỐI
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            //Chuỗi sql xóa có đk
            string maSach = txtMaSach.Text;
            if (maSach == "")
            {
                MessageBox.Show("Chưa chọn sách cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string sql_del = "Delete from tb_sach where maSach=N'" + maSach + "'";
                SqlCommand cmd = new SqlCommand(sql_del, conn);
                DialogResult Rsulet = MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Rsulet == DialogResult.OK)
                {
                    cmd.ExecuteNonQuery();
                    Hienthi_DGView();
                    XoaDL();
                }
            }
            conn.Close();
        }

        private void dgvsach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSach.Text = dgvsach.CurrentRow.Cells[1].Value.ToString();
            cbbloaisach.Text = dgvsach.CurrentRow.Cells[2].Value.ToString();
            txtTenSach.Text = dgvsach.CurrentRow.Cells[3].Value.ToString();
            cbbtacgia.Text = dgvsach.CurrentRow.Cells[4].Value.ToString();
            dtpNamXB.Value = DateTime.Parse(dgvsach.CurrentRow.Cells[5].Value.ToString());
            txtGiaSach.Text = dgvsach.CurrentRow.Cells[6].Value.ToString();
        }
        
        private void cbbloaisach_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tls = cbbloaisach.Text.ToString();
            
                string Sql1 = "select maLoaiSach from tb_loaisach where tenLoaiSach=N'"+tls+"'";
                SqlConnection conn = new SqlConnection(chuoiketnoi);
                conn.Open();
                SqlCommand cmd1 = new SqlCommand(Sql1, conn);
                SqlDataReader DR2 = cmd1.ExecuteReader();
                while (DR2.Read())
                {
                    maLoaiSach = Int32.Parse( DR2[0].ToString());

                }
            conn.Close();
        }

        private void cbbtacgia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tls = cbbtacgia.Text.ToString();

            string Sql1 = "select maTacGia from tb_tacgia where tenTacGia=N'" + tls + "'";
            SqlConnection conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            SqlCommand cmd1 = new SqlCommand(Sql1, conn);
            SqlDataReader DR3 = cmd1.ExecuteReader();
            while (DR3.Read())
            {
                maTacGia = Int32.Parse(DR3[0].ToString());

            }
            conn.Close();
        }

        private void dgvsach_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < dgvsach.RowCount; i++)
            {
                dgvsach.Rows[i].Cells[0].Value = i + 1;
            }
        }

      
    }
}