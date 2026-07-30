# 🎓 Student Management System

![C#](https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET_Framework-4.8-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity_Framework-6.5-3fa037?style=for-the-badge&logo=nuget&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

This is a desktop student management application built to demonstrate how to apply a **3-Tier Architecture** and enterprise software development standards on the .NET platform.

## 🏗️ System Architecture

The solution is strictly separated into 4 independent projects (loose coupling) to optimize maintainability and scalability:

* **StudentManagement.DTO (Data Transfer Objects):** Contains database entities (Student, ClassRoom) and view models for presentation (to hide sensitive data).
* **StudentManagement.DAL (Data Access Layer):** Contains `StudentDbContext` and `StudentDal`. Responsible for all database interactions. Uses LINQ `IQueryable` to optimize queries.
* **StudentManagement.BLL (Business Logic Layer):** Contains `StudentBll`. The core of the system, where business rules are handled (duplicate ID checks, input constraints) before calling DAL.
* **StudentManagement.GUI (Presentation Layer):** WinForms user interface. This layer does not interact directly with the database and communicates only through BLL.

## 🚀 Technical Highlights

The project applies core C# and Entity Framework techniques to optimize performance and memory management:

* **Entity Framework Code-First:** Fully automates database creation and seed data initialization through `DbInitializer` on first run.
* **Singleton Pattern:** DAL and BLL apply the Singleton design pattern to manage a consistent object initialization flow across the system.
* **Avoid Full Table Scans & Memory Leaks:**
  - Uses Eager Loading (`.Include()`) to prevent `DbContext` disposed issues.
  - Applies dynamic filtering at the database level instead of loading full datasets into RAM.
  - Uses strict `using` blocks to release forms and connections immediately.
* **Safe Event/Delegate Handling:** Supports smooth data transfer between forms without memory leaks using safe invocation (`?.Invoke` / `!= null`).
* **UX/UI Validation:** Prevents type-casting errors with `double.TryParse` in the UI and pre-emptive validation (existing ID checks) in the business layer.

## 🛠️ Key Features

* **List Viewing & Management:** Displays student data using clean and user-friendly view models.
* **Dynamic Search:** Instant filtering by class or combined keywords (Student ID, Student Name).
* **Sorting:** Flexible sorting by ID, Name, or GPA.
* **CRUD Operations:** Add, edit, and delete multiple students at once with safe confirmation dialogs.
* **Auto-Refresh:** Automatically refocuses and reloads data after successful operations.

## ⚙️ Getting Started

**1. Clone the project:**
```bash
git clone https://github.com/hoangtranduchai/studentmanagementsystem.git
```

**2. Configure the database:**
* Open the `App.config` file in the `StudentManagement.GUI` project.
* Change `data source=HAI\SQLEXPRESS` to your local SQL Server instance (for example: `.\SQLEXPRESS`, `(localdb)\MSSQLLocalDB`, or `localhost`).

**3. Run the application:**
* Open the solution in Visual Studio.
* Right-click `StudentManagement.GUI` and choose **Set as Startup Project**.
* Press `F5` or click **Start**. Entity Framework will detect the configuration, create the database, seed sample data, and launch the application automatically.

## 📸 Screenshots

**Main Dashboard:** Displays the student list and search filters.
<img width="917" height="596" alt="Screenshot 2026-06-12 004634" src="https://github.com/user-attachments/assets/80b119ba-426a-4d92-925d-1878ef066606" />

**Detail Form:** Add/edit student screen with input validation logic.
<img width="422" height="462" alt="Screenshot 2026-06-12 004926" src="https://github.com/user-attachments/assets/965a29fd-b82b-4d09-bb56-7c9f6f4ac3ca" />


---
*Project built and completed by Hoang Tran Duc Hai* 👨‍💻
