using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QLBS
{
    public partial class thongkedoanhthu : Form
    {
        public int maHoaDon;
        string chuoiketnoi = @"Data Source=21AK22-COM;Initial Catalog=QUANLYBANSACH;Integrated Security=True";
        SqlConnection conn;
        public thongkedoanhthu()
        {
            InitializeComponent();
        }

        public void Hienthi_DGView()
        {
            conn = new SqlConnection(chuoiketnoi);
            //Mở kết nối =>open()
            conn.Open();
            DateTime ngaydau = dtpNgayDau.Value;
            DateTime ngaycuoi = dtpNgayCuoi.Value;
            String xemhoadon = "select * from v_xemthongke where ngayxuat BETWEEN '" + ngaydau + "' and '" + ngaycuoi + "'";
            SqlDataAdapter Mydata1 = new SqlDataAdapter(xemhoadon, conn);
            DataTable dt = new DataTable(); //tạo 1 bảng           
            Mydata1.Fill(dt);
            dgvThongKe.DataSource = dt;
            conn.Close();
        }

            private void btnXem_Click(object sender, EventArgs e)
        {
            Hienthi_DGView();
        }

        private void dgvThongKe_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

            for (int i = 0; i < dgvThongKe.RowCount; i++)
            {
                dgvThongKe.Rows[i].Cells[0].Value = i + 1;
            }
        }
    }
}
