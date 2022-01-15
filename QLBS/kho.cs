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


    public partial class kho : Form
    {
        string chuoiketnoi = @"Data Source=21AK22-COM;Initial Catalog=QUANLYBANSACH;Integrated Security=True";
        SqlConnection conn;
        public kho()
        {
            InitializeComponent();
            tongKho();
        }
        private void kho_Load(object sender, EventArgs e)
        {
            tongKho();

        }
        private khoManager mgnKho = new khoManager();
        public void tongKho()
        {   
            connectSQl();
            string sql_tongnhap = "Select tb_sach.tenSach, SUM(soLuongNhap) from tb_sach  INNER JOIN tb_ctphieunhap on tb_sach.maSach = tb_ctphieunhap.maSach GROUP BY tb_sach.tenSach ";
            SqlCommand cmd1 = new SqlCommand(sql_tongnhap, conn);
            SqlDataReader DR = cmd1.ExecuteReader();

            while (DR.Read())
            {
                mgnKho.addKho(new khosach( DR[0].ToString(),Int32.Parse( DR[1].ToString())));

            }
            conn.Close();
            connectSQl();
            string sql_tongban = "select tb_sach.tenSach , sum(soLuongBan) from tb_sach, tb_chitiethoadon where tb_sach.maSach = tb_chitiethoadon.maSach group by tb_sach.tenSach ";
            SqlCommand cmd2 = new SqlCommand(sql_tongban, conn);
            SqlDataReader DR2 = cmd2.ExecuteReader();

            while (DR2.Read())
            {
                mgnKho.editKho(new khosach(DR2[0].ToString(),0, Int32.Parse(DR2[1].ToString())) );

            }
            conn.Close();

            dgvKho.DataSource = mgnKho.listkho;
            
        }

        public void connectSQl()
        {
            conn = new SqlConnection(chuoiketnoi);
            //Mở kết nối =>open()
            conn.Open();

        }

        private void dgvKho_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < dgvKho.RowCount; i++)
            {
                dgvKho.Rows[i].Cells[0].Value = i + 1;
            }
        }

       
    }
}

