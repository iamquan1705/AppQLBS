
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QLBS
{
    public partial class phieunhap : Form
    {
        string chuoiketnoi = @"Data Source=21AK22-COM;Initial Catalog=QUANLYBANSACH;Integrated Security=True";
        SqlConnection conn;
        private int maNHANVIEN;
        private int maNHACUNGCAP;
        private int maSACH;
        public phieunhap()
        {
            InitializeComponent();
            cbTenNhaCungCap();
            cbTenNhanVien();
            Hienthi_DGView();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            connectSQL();
            string maPN = txtMaPN.Text;
            int maNV = maNHANVIEN;
            int mancc = maNHACUNGCAP;
            string date = dtNgayLap.Text;
            string them = "Insert tb_phieunhap values ('" + maNV + "','" + mancc + "','" + date + "')";
            SqlCommand cmd = new SqlCommand(them, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Thêm phiếu nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Hienthi_DGView();
        }


        private void cbTenNhanVien()
        {
            string Sql = "select tenNhanVien from tb_nhanvien";
            SqlConnection conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {   
                cbTenNV.Items.Add(DR[0]);

            }
            conn.Close();
        }
        private void cbTenNhaCungCap()
        {
            string Sql = "select tenNhaCungCap from tb_nhacungcap";
            SqlConnection conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                cbTenNCC.Items.Add(DR[0]);

            }
            conn.Close();
        }


        private void connectSQL()
        {
            conn = new SqlConnection(chuoiketnoi);
            //Mở kết nối =>open()
            conn.Open();

        }

        

        private void Hienthi_DGView()
        {
            connectSQL();
            String hienthiPN = "Select tb_phieunhap.maPhieuNhap,tb_nhanvien.tenNhanVien,tb_nhacungcap.tenNhaCungCap,tb_phieunhap.ngayNhap from tb_phieunhap,tb_nhacungcap,tb_nhanvien where tb_phieunhap.maNhanVien=tb_nhanvien.maNhanVien and tb_phieunhap.maNhaCungCap=tb_nhacungcap.maNhaCungCap";
            //tạo đối tượng data adapter =>có csdl
            SqlDataAdapter Mydata = new SqlDataAdapter(hienthiPN, conn);
            // mydata có dữ liệu=>đổ dữ liệu từ mydata vào bảng
            DataTable dt = new DataTable(); //tạo 1 bảng
            // đổ dữ liệu từ mydata vào bảng
            Mydata.Fill(dt);
            dgvPN.DataSource = dt;
            conn.Close();

        }

        private void phieunhap_Load(object sender, EventArgs e)
        {
            Hienthi_DGView();
        }
       

    /*    private void btXemCTPN_Click(object sender, EventArgs e)
        {
            string mapnxem="";
            foreach (DataGridViewRow item in dgvPN.SelectedRows)
            {
                 mapnxem = item.Cells[1].Value.ToString();
            }

            if (mapnxem == "")
            {
                MessageBox.Show("bạn chưa chọn phiếu nhập cần xem", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                chitietphieunhap ctpn = new chitietphieunhap();
                ctpn.temp = mapnxem;
                ctpn.ShowDialog();
            }
        }
        */

        private void cbTenNV_SelectedValueChanged(object sender, EventArgs e)
        {
            string tls = cbTenNV.Text.ToString();

            string Sql1 = "select maNhanVien from tb_nhanvien where tenNhanVien=N'" + tls + "'";
            SqlConnection conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            SqlCommand cmd1 = new SqlCommand(Sql1, conn);
            SqlDataReader DR2 = cmd1.ExecuteReader();
            while (DR2.Read())
            {
                maNHANVIEN = Int32.Parse(DR2[0].ToString());

            }
            conn.Close();
        }

        private void cbTenNCC_SelectedValueChanged(object sender, EventArgs e)
        {
            string tls = cbTenNCC.Text.ToString();
            string Sql1 = "select maNhaCungCap from tb_nhaCungCap where tenNhaCungCap=N'" + tls + "'";
            SqlConnection conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            SqlCommand cmd1 = new SqlCommand(Sql1, conn);
            SqlDataReader DR2 = cmd1.ExecuteReader();
            while (DR2.Read())
            {
                maNHACUNGCAP = Int32.Parse(DR2[0].ToString());

            }
            conn.Close();
        }

        private void dgvPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaPN.Text = dgvPN.CurrentRow.Cells[1].Value.ToString();
            cbTenNCC.Text = dgvPN.CurrentRow.Cells["tenNhaCungCap"].Value.ToString();
            cbTenNV.Text = dgvPN.CurrentRow.Cells["tenNhanVien"].Value.ToString();
            dtNgayLap.Text = dgvPN.CurrentRow.Cells["ngayNhap"].Value.ToString();
        }

        private void dgvPN_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < dgvPN.RowCount; i++)
            {
                dgvPN.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
         
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            connectSQL();
            string maPN = txtMaPN.Text;
            int maNV = maNHANVIEN;
            int mancc = maNHACUNGCAP;
            string date = dtNgayLap.Text;
            string them = "UPDATE tb_phieunhap set maNhanVien='"+maNV+"',maNhaCungCap='"+mancc+"',ngayNhap='"+date+"'";
            SqlCommand cmd = new SqlCommand(them, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Sửa phiếu nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Hienthi_DGView();
        }

        private void dgvPN_DoubleClick(object sender, EventArgs e)
        {
            chitietphieunhap ctpn = new chitietphieunhap(Int32.Parse(txtMaPN.Text));
            ctpn.ShowDialog();

        }

       
    }
}