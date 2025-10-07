using System.Text;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace BT3_LTMCB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private string connectionString = "Data Source=localhost;Initial Catalog=UserDB;User ID=sa;Password=csdllab1;TrustServerCertificate=True";

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        private void CheckBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = checkBoxShowPassword.Checked ? '\\0' : '*';
        }
        private bool Login(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);

                string hashedPassword = HashPassword(password);
                cmd.Parameters.AddWithValue("@Password", hashedPassword);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Username và Password!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Login(username, password))
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                INFOMATION mainForm = new INFOMATION();
                mainForm.FormClosed += (s, args) => this.Close();
                mainForm.Show();
            }

            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DK dkForm = new DK();
            dkForm.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}