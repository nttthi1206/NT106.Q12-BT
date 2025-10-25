using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT3_LTMCB
{
    public partial class FormThongTinNguoiDung : Form
    {
        public FormThongTinNguoiDung()
        {
            InitializeComponent();
        }

        private void INFOMATION_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Xóa token nếu tồn tại
                string tokenPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\token.jwt");
                if (File.Exists(tokenPath))
                {
                    File.Delete(tokenPath);
                }

                this.Hide();
                FormDangNhap loginForm = new FormDangNhap();
                loginForm.FormClosed += (s, args) => this.Close();
                loginForm.Show();
            }
        }
    }
}
