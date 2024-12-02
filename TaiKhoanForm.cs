using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using WindowsForm;

namespace WindowsForm
{
    public partial class TaiKhoanForm : Form
    {
        private SqlConnection connection;
        public TaiKhoanForm()
        {
            InitializeComponent();
        }
        public void ResetFields()
        {
            txtTenDangNhap.Text = string.Empty;
            txtPass.Text = string.Empty;
        }

        private void TaiKhoanForm_Load(object sender, EventArgs e)
        {
            string connectionString = "server=Admin\\SQLEXPRESS;Database=QuanLyKhachSan;Integrated Security=True;";
            connection = new SqlConnection(connectionString);



        }

        private void p2_Click(object sender, EventArgs e)
        {
            if (txtPass.PasswordChar == '*')
            {
                p1.BringToFront();
                txtPass.PasswordChar = '\0';
            }



        }

        private void p1_Click(object sender, EventArgs e)
        {
            if (txtPass.PasswordChar == '\0')
            {
                p2.BringToFront();
                txtPass.PasswordChar = '*';
            }

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                string query = "SELECT a.TenTK, b.ViTriLV FROM TaiKhoan a JOIN NhanVien b ON a.IDNhanVien = b.IDNhanVien WHERE a.TenTK=@Username AND a.MatKhau=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, connection);
                sqlCmd.Parameters.AddWithValue("@Username", txtTenDangNhap.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Password", txtPass.Text.Trim());
                SqlDataReader reader = sqlCmd.ExecuteReader();

                if (reader.Read())
                {
                    string viTriLV = reader["ViTriLV"].ToString();
                    bool isManager = viTriLV != "Nhân viên"; 

                    MessageBox.Show("Đăng nhập thành công!");
                    MainForm mainForm = new MainForm(txtTenDangNhap.Text.Trim(), isManager);
                    mainForm.ShowDialog(); 
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }
        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            QuenMatKhau quenmatkhau = new QuenMatKhau();
            this.Hide();
            quenmatkhau.ShowDialog();
            this.Show();


        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


