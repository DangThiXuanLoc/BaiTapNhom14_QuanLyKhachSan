using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class QuenMatKhau : Form
    {
        private SqlConnection connection;
        public QuenMatKhau()
        {
            InitializeComponent();
        }

        private void btnLayMK_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State == ConnectionState.Closed) 
                {
                    connection.Open(); 
                } 
                string email = txtEmailDK.Text.Trim();
                string query = "SELECT MatKhau FROM TaiKhoan WHERE Email = @Email"; 
                SqlCommand sqlCmd = new SqlCommand(query, connection);
                sqlCmd.Parameters.AddWithValue("@Email", email);
                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd); 
                DataTable dt = new DataTable(); sda.Fill(dt);
                if (dt.Rows.Count > 0) { string matKhau = dt.Rows[0]["MatKhau"].ToString();
                    txtKQ.Text = " " + matKhau; }
                else
                { txtKQ.Text = "Email không tồn tại."; } } catch (Exception ex)
            {
                txtKQ.Text = "Lỗi: " + ex.Message; 
            } 
            finally
            { 
                if (connection.State == ConnectionState.Open)
                { 
                    connection.Close();
                }
            }
        }
    


    private void QuenMatKhau_Load(object sender, EventArgs e)
        {
            string connectionString = "server=Admin\\SQLEXPRESS;Database=QuanLyKhachSan;Integrated Security=True;"; 
            connection = new SqlConnection(connectionString);
           
        }
        

        private void txtEmailDK_TextChanged(object sender, EventArgs e)
        {

        }

        private void bntThoat_Click(object sender, EventArgs e)
        {
            

            this.Close();
        }
    }
}


