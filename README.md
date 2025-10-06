# NT206 - Lập trình mạng căn bản
# Bài tập tuần 3 - Viết ứng dụng quản lý người dùng với tính năng đăng nhập, đăng ký
**Danh sách thành viên**:
	- 24521726	Lương Thị Anh Thư
	- 24521674	Lê Văn Thiết
	- 24521655	Phùng Ngọc Thi
	- 24521654	Nguyễn Thị Trang Thi
	- 22520200	Trần Ngọc Danh

## 📝 Mô tả
Ứng dụng C# Windows Forms gồm hai chức năng chính:
- **Đăng ký người dùng**: thêm thông tin vào cơ sở dữ liệu SQL Server
- **Đăng nhập**: kiểm tra thông tin đăng nhập thông qua dữ liệu đã lưu trong bảng `Users`

## 🛠️ Cơ sở dữ liệu

Ứng dụng sử dụng SQL Server. Để thuận tiện cho quá trình chấm bài, nhóm chúng em đã chuẩn bị sẵn file:

- 📁 `database.sql`  
  → File này chứa toàn bộ lệnh tạo cơ sở dữ liệu `UserDB`, tạo bảng `Users` và chèn sẵn một tài khoản mẫu (username: `admin1`, password: `123456` đã được mã hóa bằng SHA-256).

## 🔐 Thông tin kết nối mặc định

Trong code có sử dụng chuỗi kết nối:

Server=localhost,1433;Database=UserDB;User Id=sa;Password=YourStrong@Passw0rd;
