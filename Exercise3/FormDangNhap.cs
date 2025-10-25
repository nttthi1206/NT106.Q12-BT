using Microsoft.Data.SqlClient;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BT3_LTMCB
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            this.Load += FormDangNhap_Load;
        }
        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            string tokenPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\token.jwt");

            if (File.Exists(tokenPath))
            {
                string token = File.ReadAllText(tokenPath);

                Task.Run(() =>
                {
                    try
                    {
                        string response = SendAutoLoginRequest(token);

                        this.Invoke((MethodInvoker)(() =>
                        {
                            if (response == "autologin_success")
                            {
                                MessageBox.Show("Tự động đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                FormThongTinNguoiDung mainForm = new FormThongTinNguoiDung();
                                mainForm.FormClosed += (s, args) => this.Close();
                                mainForm.Show();
                            }
                            else
                            {
                                File.Delete(tokenPath); // Token sai/hết hạn → xoá đi
                            }
                        }));
                    }
                    catch (Exception ex)
                    {
                        // Không cần show lỗi lớn nếu token fail
                        this.Invoke((MethodInvoker)(() =>
                        {
                            MessageBox.Show("Tự đăng nhập thất bại: " + ex.Message);
                        }));
                    }
                });
            }
        }

        private void CheckBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = checkBoxShowPassword.Checked ? '\0' : '*';
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

            // Chạy trong thread nền
            Task.Run(() =>
            {
                try
                {
                    string response = SendLoginRequest(username, password);

                    this.Invoke((MethodInvoker)delegate
                    {
                        if (response == "success")
                        {
                            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            FormThongTinNguoiDung mainForm = new FormThongTinNguoiDung();
                            mainForm.FormClosed += (s, args) => this.Close();
                            mainForm.Show();
                        }
                        else if (response == "fail")
                        {
                            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox1.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi phản hồi từ server: " + response, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    });
                }
                catch (TimeoutException)
                {
                    this.Invoke((MethodInvoker)(() =>
                    {
                        MessageBox.Show("Timeout khi chờ phản hồi từ server.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
                catch (Exception ex)
                {
                    this.Invoke((MethodInvoker)(() =>
                    {
                        MessageBox.Show("Lỗi kết nối đến server: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormDangKi dkForm = new FormDangKi();
            dkForm.Show();
            this.Hide();
        }

        private string SendLoginRequest(string username, string password)
        {
            var loginData = new
            {
                type = "login",
                data = new
                {
                    username = username,
                    password = password
                }
            };

            string json = System.Text.Json.JsonSerializer.Serialize(loginData);
            byte[] sendBytes = Encoding.UTF8.GetBytes(json);

            using (TcpClient client = new TcpClient())
            {
                client.ReceiveTimeout = 3000;   // Timeout 3 giây
                client.SendTimeout = 3000;

                client.Connect("127.0.0.1", 1010);
                using NetworkStream stream = client.GetStream();

                stream.Write(sendBytes, 0, sendBytes.Length);
                stream.Flush();

                byte[] buffer = new byte[2048];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string responseJson = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

                // Parse JSON
                using var doc = System.Text.Json.JsonDocument.Parse(responseJson);
                var root = doc.RootElement;

                string status = root.GetProperty("status").GetString();

                if (status == "success")
                {
                    string token = root.GetProperty("token").GetString();
                    string projectRootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\");
                    string tokenFilePath = Path.Combine(projectRootPath, "token.jwt");
                    File.WriteAllText(tokenFilePath, token);
                    return "success";
                }
                else
                {
                    return "fail";
                }
            }
        }
        private string SendAutoLoginRequest(string token)
        {
            var request = new
            {
                type = "autologin",
                token = token
            };

            string json = System.Text.Json.JsonSerializer.Serialize(request);
            byte[] sendBytes = Encoding.UTF8.GetBytes(json);

            using (TcpClient client = new TcpClient())
            {
                client.ReceiveTimeout = 3000;
                client.SendTimeout = 3000;
                client.Connect("127.0.0.1", 1010);

                using NetworkStream stream = client.GetStream();
                stream.Write(sendBytes, 0, sendBytes.Length);
                stream.Flush();

                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                return Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}