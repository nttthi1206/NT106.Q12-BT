# NT106 - Lập trình mạng căn bản
## 👥 Danh sách thành viên nhóm 10    
	- 24521726	Lương Thị Anh Thư  
	- 24521674	Lê Văn Thiết  
	- 24521655	Phùng Ngọc Thi  
	- 24521654	Nguyễn Thị Trang Thi  
	- 22520200	Trần Ngọc Danh  

**Bài tập tuần 5 - Viết ứng dụng quản lý người dùng với tính năng đăng nhập, đăng ký với TCP socket**  
  
## 📝 Mô tả

Ứng dụng gồm hai thành phần chính: **Client** và **Server**, giao tiếp với nhau thông qua giao thức **TCP socket**. Cả hai đều được xây dựng bằng C# **Windows Forms**, sử dụng thư viện `TcpClient` và `TcpListener`.

🔑 Tính năng chính:
- **Đăng ký người dùng**: tạo tài khoản với username, password, email và lưu vào SQL Server.
- **Đăng nhập**: kiểm tra thông tin người dùng và tạo token JWT.
- **Tự động đăng nhập**: nếu thiết bị đã lưu token, tự đăng nhập lại mà không cần nhập lại tài khoản.
- **Đăng xuất**: xóa file token khỏi máy, đảm bảo bảo mật.
- **Bảo mật**: sử dụng mã hóa bằng **JWT Token**, lưu token tạm trên máy người dùng.

---

💻 Công nghệ sử dụng

| Thành phần | Công nghệ | Mô tả |
|-----------|-----------|-------|
| Client    | C# Windows Forms (`TcpClient`) | Giao diện người dùng, gửi yêu cầu đăng nhập/đăng ký tới server |
| Server    | C# Windows Forms (`TcpListener`) | Lắng nghe kết nối TCP, xử lý yêu cầu từ client |
| Token     | JWT (JSON Web Token) + HMAC | Mã hóa thông tin đăng nhập, xác thực tự động login |
| Cơ sở dữ liệu | SQL Server | Lưu thông tin người dùng (`Users` table) |

---

## 🛠️ Cơ sở dữ liệu

Ứng dụng sử dụng SQL Server. Để thuận tiện cho quá trình chấm bài, nhóm chúng em đã chuẩn bị sẵn file:

- 📁 `database.sql`  
  → File này chứa toàn bộ lệnh tạo cơ sở dữ liệu `UserDB`, tạo bảng `Users`, tạo sẵn user tên myuser để phục vụ cho việc kết nối tới database.
- Cách sử dụng:  
  1. Mở SQL Server Management Studio (SSMS) hoặc Azure Data Studio và kết nối tới SQL Server instance của bạn (có thể sẽ yêu cầu đăng nhập bằng tài khoản 'sa').
  2. Mở file `database.sql` trong SSMS.
  3. Chạy toàn bộ script để tạo cơ sở dữ liệu, user và bảng cần thiết.

## 🔐 Thông tin kết nối mặc định

Trong code có sử dụng chuỗi kết nối:

Server=localhost;Database=UserDB;User Id=myuser;Password=YourStrong@Passw0rd;


