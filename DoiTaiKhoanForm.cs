using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class DoiTaiKhoanForm : Form
    {
        private SqlConnection connection;
        public DoiTaiKhoanForm()
        {
            InitializeComponent();
        }

        private void bntDMK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMKhientai.Text) || string.IsNullOrWhiteSpace(txtMKmoi.Text) || string.IsNullOrWhiteSpace(txtNhapLaiMK.Text))
{
    MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    return;
}
if (txtMKmoi.Text != txtNhapLaiMK.Text)
{
    MessageBox.Show("Mật khẩu mới không khớp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    return;
}
            if (!IsValidPassword(txtMKmoi.Text))
            {
                MessageBox.Show("Mật khẩu mới phải có tối thiểu 6 ký tự, bao gồm chữ số, chữ cái và ký tự đặc biệt (!$@%).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
{
    if (connection.State == ConnectionState.Closed)
    {
        connection.Open();
    }
    string checkQuery = "SELECT COUNT(1) FROM TaiKhoan WHERE TenTK=@Username AND MatKhau=@CurrentPassword";
    SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
    checkCmd.Parameters.AddWithValue("@Username", txtTenDangNhap.Text.Trim());
    checkCmd.Parameters.AddWithValue("@CurrentPassword", txtMKhientai.Text.Trim());
    int count = (int)checkCmd.ExecuteScalar();
    if (count == 1)
    {
        string updateQuery = "UPDATE TaiKhoan SET MatKhau=@NewPassword WHERE TenTK=@Username";
        SqlCommand updateCmd = new SqlCommand(updateQuery, connection);
        updateCmd.Parameters.AddWithValue("@Username", txtTenDangNhap.Text.Trim());
        updateCmd.Parameters.AddWithValue("@NewPassword", txtMKmoi.Text.Trim());
        updateCmd.ExecuteNonQuery();
        MessageBox.Show("Đổi mật khẩu thành công!");

                    
                    this.Close();
                    TaiKhoanForm TK = new TaiKhoanForm();
                    TK.Show();
    }
    else
    {
        MessageBox.Show("Mật khẩu hiện tại không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
catch (Exception ex)
{
    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
finally
{
    if (connection.State == ConnectionState.Open)
    {
        connection.Close();
    }
}

        }

        private void DoiTaiKhoanForm_Load(object sender, EventArgs e)
        {
            string connectionString = "server=Admin\\SQLEXPRESS;Database=QuanLyKhachSan;Integrated Security=True;";
            connection = new SqlConnection(connectionString);
        }
        private bool IsValidPassword(string password)
        {
            if (password.Length < 6) return false;
            bool hasLetter = false, hasDigit = false, hasSpecialChar = false;
            foreach (char c in password)
            {
                if (char.IsLetter(c)) hasLetter = true;
                else if (char.IsDigit(c)) hasDigit = true;
                else if ("!@$%".Contains(c)) hasSpecialChar = true;
            }
            return hasLetter && hasDigit && hasSpecialChar;
        }

    }

}


