# 🎓 Student Management System (Hệ Thống Quản Lý Sinh Viên)

![C#](https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET_Framework-4.8-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity_Framework-6.5-3fa037?style=for-the-badge&logo=nuget&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

Đây là dự án ứng dụng Desktop quản lý sinh viên được xây dựng nhằm mục đích minh họa cách áp dụng **Kiến trúc 3 lớp (3-Tier Architecture)** và các tiêu chuẩn phát triển phần mềm doanh nghiệp (Enterprise Coding Standards) trên nền tảng .NET.

## 🏗️ Kiến Trúc Hệ Thống (Architecture)

Dự án được phân tách nghiêm ngặt thành 4 project độc lập (Loose Coupling) để tối ưu hóa việc bảo trì và mở rộng:

* **StudentManagement.DTO (Data Transfer Objects):** Chứa các thực thể Database (Student, ClassRoom) và các ViewModel phục vụ riêng cho việc hiển thị (ẩn giấu dữ liệu nhạy cảm).
* **StudentManagement.DAL (Data Access Layer):** Chứa StudentDbContext và StudentDal. Chịu trách nhiệm tương tác duy nhất với cơ sở dữ liệu. Sử dụng LINQ IQueryable để tối ưu hóa truy vấn.
* **StudentManagement.BLL (Business Logic Layer):** Chứa StudentBll. Trái tim của hệ thống, xử lý các quy tắc nghiệp vụ (kiểm tra trùng lặp mã, ràng buộc dữ liệu đầu vào) trước khi gọi xuống DAL.
* **StudentManagement.GUI (Presentation Layer):** Giao diện người dùng WinForms. Tầng này tuyệt đối không biết về sự tồn tại của Database và chỉ giao tiếp với hệ thống thông qua BLL.

## 🚀 Điểm Nhấn Kỹ Thuật (Technical Highlights)

Dự án áp dụng các kỹ thuật cốt lõi trong lập trình C# và Entity Framework để tối ưu hiệu năng và quản lý bộ nhớ:

* **Entity Framework Code-First:** Tự động hóa hoàn toàn việc tạo Database và nạp dữ liệu mẫu (Seed Data) thông qua DbInitializer ngay lần chạy đầu tiên.
* **Singleton Pattern:** Tầng DAL và BLL áp dụng mẫu thiết kế Singleton để quản lý luồng khởi tạo đối tượng thống nhất trong toàn hệ thống.
* **Tránh Full Table Scan & Memory Leaks:** - Sử dụng Eager Loading (.Include()) để ngăn chặn lỗi DbContext Disposed.
  - Tối ưu hóa truy vấn động (Dynamic Filtering) dưới Database thay vì kéo toàn bộ dữ liệu lên RAM.
  - Ứng dụng khối using block nghiêm ngặt để giải phóng Form và Connection ngay lập tức.
* **Safe Event/Delegate Handling:** Truyền dữ liệu liên Form mượt mà không gây rò rỉ bộ nhớ, sử dụng kỹ thuật Safe Invocation (?.Invoke / != null).
* **UX/UI Validation:** Xử lý bẫy lỗi ép kiểu an toàn với double.TryParse trên giao diện và Pre-emptive Validation (kiểm tra mã tồn tại) tại tầng nghiệp vụ.

## 🛠️ Tính Năng Chính (Key Features)

* **Xem & Quản lý danh sách:** Hiển thị danh sách sinh viên dưới dạng ViewModel sạch sẽ, thân thiện.
* **Lọc động (Dynamic Search):** Tìm kiếm tức thời theo Lớp học hoặc Từ khóa (Mã SV, Tên SV) kết hợp.
* **Sắp xếp (Sorting):** Cho phép sắp xếp dữ liệu linh hoạt theo Mã, Tên, hoặc Điểm GPA.
* **Thao tác (CRUD):** Thêm mới, Chỉnh sửa, và Xóa nhiều sinh viên cùng lúc với hộp thoại xác nhận an toàn.
* **Tự động làm mới (Auto-refresh):** Giao diện tự động focus và nạp lại dữ liệu sau khi thực hiện nghiệp vụ thành công.

## ⚙️ Hướng Dẫn Cài Đặt (Getting Started)

**1. Clone dự án về máy:**
```bash
git clone https://github.com/hoangtranduchai/studentmanagementsystem.git
```

**2. Cấu hình Cơ Sở Dữ Liệu:**
* Mở file App.config nằm trong project StudentManagement.GUI.
* Đổi giá trị data source=HAI\SQLEXPRESS thành tên SQL Server Instance trên máy tính của bạn (VD: .\SQLEXPRESS, (localdb)\MSSQLLocalDB, hoặc localhost).

**3. Khởi chạy:**
* Mở Solution bằng Visual Studio.
* Click chuột phải vào Project StudentManagement.GUI -> Chọn "Set as Startup Project".
* Nhấn F5 hoặc nút Start. Entity Framework sẽ tự động nhận diện cấu hình, khởi tạo Database, chèn dữ liệu mẫu và bật ứng dụng lên ngay lập tức!

## 📸 Hình Ảnh Minh Họa (Screenshots)

**Main Dashboard:** Hiển thị danh sách và bộ lọc tìm kiếm.
<img width="917" height="596" alt="Screenshot 2026-06-12 004634" src="https://github.com/user-attachments/assets/80b119ba-426a-4d92-925d-1878ef066606" />

**Detail Form:** Màn hình thêm mới/chỉnh sửa sinh viên với các logic kiểm duyệt đầu vào.
<img width="422" height="462" alt="Screenshot 2026-06-12 004926" src="https://github.com/user-attachments/assets/965a29fd-b82b-4d09-bb56-7c9f6f4ac3ca" />


---
*Dự án được xây dựng và hoàn thiện bởi Hoang Tran Duc Hai* 👨‍💻
