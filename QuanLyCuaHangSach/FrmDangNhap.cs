using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace QuanLyCuaHangSach
{
    public partial class FrmDangNhap : Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            DAO.CloseConnetion();
            Application.Exit();
        }
              
        private void FrmDangNhap_Load(object sender, EventArgs e)
        { 
                DAO.OpenConnection();
        }
            // Hàm kiểm tra kết nối
        public DataTable checklog(string admin, string pass)
        {
            DAO.OpenConnection();
            string sql = "select * from Admin where tendangnhap = '" + admin + "' AND matkhau ='" + pass + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
            

        private void btndnn_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = checklog(this.txtdn.Text.Trim(), this.txtmk.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                this.Hide();
                FrmMain f = new FrmMain();
                f.Show();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại", "Notification");
            }
        }
    }
}
