using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise3
{
    public partial class FormTCPServer : Form
    {
        public FormTCPServer()
        {
            InitializeComponent();
        }

        private TcpListener tcpListener;
        private Thread serverThread;
        public class LoginRequest
        {
            public string username { get; set; }
            public string password { get; set; }
        }

        private void buttonListen_Click(object sender, EventArgs e)
        {
            int port = 0;
            if (!int.TryParse(textBoxPortNumber.Text, out port) || port < 1 || port > 65535)
            {
                MessageBox.Show("Vui lòng nhập port hợp lệ (1–65535).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            serverThread = new Thread(() => StartServer(port));
            serverThread.IsBackground = true;
            serverThread.Start();
            AppendLog("Đang lắng nghe tại cổng " + port);
        }

        private void StartServer(int port)
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, port);
                tcpListener.Start();

                while (true)
                {
                    TcpClient client = tcpListener.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();

                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    AppendLog("Nhận từ client: " + receivedMessage);

                    try
                    {
                        // Parse JSON
                        var loginRequest = System.Text.Json.JsonSerializer.Deserialize<LoginRequest>(receivedMessage);

                        // Kiểm tra đăng nhập
                        bool isValid = ValidateLogin(loginRequest.username, loginRequest.password);
                        string response = isValid ? "success" : "fail";

                        // Gửi phản hồi
                        byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                        stream.Write(responseBytes, 0, responseBytes.Length);
                    }
                    catch (Exception ex)
                    {
                        AppendLog("Lỗi xử lý client: " + ex.Message);
                        byte[] errorBytes = Encoding.UTF8.GetBytes("error");
                        stream.Write(errorBytes, 0, errorBytes.Length);
                    }

                    client.Close();
                }
            }
            catch (Exception ex)
            {
                AppendLog("Lỗi server: " + ex.Message);
            }
        }

        private void AppendLog(string message)
        {
            if (richTextBoxMessage.InvokeRequired)
            {
                richTextBoxMessage.Invoke(new MethodInvoker(() => richTextBoxMessage.AppendText(message + Environment.NewLine)));
            }
            else
            {
                richTextBoxMessage.AppendText(message + Environment.NewLine);
            }
        }
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
        private bool ValidateLogin(string username, string password)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=UserDB;User ID=sa;Password=csdllab1;TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", HashPassword(password));
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

    }
}
