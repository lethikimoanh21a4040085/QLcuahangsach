using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Windows;
using System.Windows.Forms;



namespace QuanLyCuaHangSach
{
    public partial class FrmMatSach : Form
    {
        public FrmMatSach()
        {
            InitializeComponent();
        }

      

        private void FrmMatSach_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            LoadDataToGrivew();
            fillDataToCombo();
            DAO.CloseConnetion();
        }
        private void LoadDataToGrivew()
        {

            try
            {
                DAO.OpenConnection();
                string sql = "select * from MatSach";
                SqlDataAdapter myAdapter = new SqlDataAdapter(sql, DAO.conn);
                DataTable MatSach = new DataTable();
                myAdapter.Fill(MatSach);
                dataGridView1.DataSource = MatSach;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DAO.CloseConnetion();
            }

        }
        public void fillDataToCombo()
        {
            string sql = "Select * from MatSach";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbmasach.DataSource = table;
            cmbmasach.ValueMember = "MaSach";
            cmbmasach.DisplayMember = "TenSach";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmalanmat.Text = dataGridView1.CurrentRow.Cells["MaLanMat"].Value.ToString();
            cmbmasach.Text = dataGridView1.CurrentRow.Cells["MaSach"].Value.ToString();
            txtsoluong.Text = dataGridView1.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtngaymat.Text = dataGridView1.CurrentRow.Cells["NgayMat"].Value.ToString();
            txtsoluongmat.Text = dataGridView1.CurrentRow.Cells["SoLuongMat"].Value.ToString();
            txtmalanmat.Enabled = false;
            cmbmasach.Enabled = false;

        }
        private void btnthem(object sender, EventArgs e)
        {
            txtmalanmat.Text = "";
            txtsoluong.Text = "";
            cmbmasach.SelectedIndex = -1;
            txtngaymat.Text = "";
            txtsoluongmat.Text = "";
        }

        private void btnluu(object sender, EventArgs e)
        {
            if (txtmalanmat.Text == "")
            {
                MessageBox.Show("Bạn không được để trống mã lần mất");
                txtmalanmat.Focus();
                return;
            }
            
            if (cmbmasach.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn mã sách");
                return;
            }
            if (txtsoluong.Text == "")
            {
                MessageBox.Show("Bạn không được để trống số lượng");
                txtsoluong.Focus();
                return;
            }
            if (txtngaymat.Text == "")
            {
                MessageBox.Show("Bạn không được để trống ngày mất");
                txtngaymat.Focus();
                return;
            }
            if (txtsoluongmat.Text == "")
            {
                MessageBox.Show("Bạn không được để trống số lượng mất");
                txtsoluongmat.Focus();
                return;
            }
            
            // - Mã lần mất ko được trùng
            string sql = "select * from MatSach where MaLanMat = '" +
            txtmalanmat.Text.Trim() + "'";
            DAO.OpenConnection();
            if (DAO.checkKeyExit(sql))
            {
                MessageBox.Show("mã lần mất đã tồn tại");
                txtmalanmat.Focus();
                DAO.CloseConnetion();
                return;
            }
            else
            {
                sql = "insert into  MatSach (MaLanMat, MaSach,  " +
                    "SoLuong, SoLuongMat)" +
                    " values ('" + txtmalanmat.Text.Trim() + "',N'"
                    + cmbmasach.SelectedValue.ToString() + "', " + txtsoluong.Text + "," +
                    txtngaymat.Text.Trim() + "," + txtsoluongmat.Text.Trim() + ",)";
                   
                SqlCommand cmd = new SqlCommand(sql, DAO.conn);

                MessageBox.Show(sql);

                cmd.ExecuteNonQuery();
                LoadDataToGrivew();
                fillDataToCombo();
                DAO.CloseConnetion();

            }
        }

        private void btnsua(object sender, EventArgs e)
        {
            string Sql = "Update MatSach set MaLanMat, MaSach,SoLuong, NgayMat, SoLuongMat = N'" +txtmalanmat.Text.Trim() +"', N'" +cmbmasach.Text.Trim()+"',N'"+txtsoluong.Text.Trim()+"',N'"+txtngaymat.Text.Trim()+ "',N'" + txtsoluongmat.Text.Trim() + 
                      "' where MaLanMat = '" + txtmalanmat.Text + "'";
            DAO.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = Sql;
            cmd.Connection = DAO.conn;
            cmd.ExecuteNonQuery();
            DAO.CloseConnetion();
            LoadDataToGrivew();
        }

        private void btnxoa(object sender, EventArgs e)
        {
            string sql = "delete from MatSach where MaLanMat = '" + txtmalanmat.Text + "'";
            SqlCommand cmd = new SqlCommand();
            DAO.OpenConnection();
            cmd.CommandText = sql;
            cmd.Connection = DAO.conn;
            cmd.ExecuteNonQuery();
            DAO.CloseConnetion();
            LoadDataToGrivew();
        }

        private void btntimkiem(object sender, EventArgs e)
        {
            if (cmbmasach.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã sách để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbmasach.Focus();
                return;
            }
            txtmalanmat.Text = cmbmasach.Text;           
            LoadDataToGrivew();
            btnlu.Enabled = true;
            btnsuaa.Enabled = true;
            btnxoaa.Enabled = true;
            cmbmasach.SelectedIndex = -1;
        }

        private void btnthoat(object sender, EventArgs e)
        {
            this.Close();

        }
    }
    
}
