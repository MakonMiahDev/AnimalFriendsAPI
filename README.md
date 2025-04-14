# 🐾 AnimalFriends API

A .NET 8 Web API that manages customer registrations for pet insurance services. Built using Entity Framework Core, FluentValidation, and Swagger for easy API testing and documentation.

---

## 📦 NuGet Packages

### API Project (`AnimalFriends`)
- `FluentValidation (11.11.0)`
- `FluentValidation.AspNetCore (11.3.0)`
- `Microsoft.AspNetCore.OpenApi (8.0.0)`
- `Microsoft.EntityFrameworkCore (8.0.4)`
- `Microsoft.EntityFrameworkCore.SqlServer (8.0.4)`
- `Swashbuckle.AspNetCore (8.1.1)`

### Test Project (`AnimalFriends.Tests`)
- `FluentValidation (11.11.0)`
- `Microsoft.NET.Test.Sdk (17.13.0)`
- `MSTest.TestAdapter (3.8.3)`
- `MSTest.TestFramework (3.8.3)`

---

## 🛠️ Setup Instructions

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- SQL Server or SQL Server Express
- Visual Studio 2022+ or VS Code

### 1. Clone the Repository

```bash
git clone https://github.com/your-username/AnimalFriends.git
cd AnimalFriends/AnimalFriends
```

### 2. SQL Database Setup

Run the provided SQL script to create necessary tables:

```sql
-- File: AnimalFriendsAPI/Scripts/CustomerRegistrations.sql
```

Use SQL Server Management Studio or your preferred tool to execute the script against your database.

### 3. Configure Connection String

Update `appsettings.json` in the `AnimalFriendsAPI` project:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=AnimalFriendsDb;Trusted_Connection=True;"
}
```

### 4. Run the API

Use the following command or run from Visual Studio:

```bash
dotnet run --project AnimalFriendsAPI
```

Visit Swagger UI at:

```
https://localhost:5001/swagger
```

---

## ✅ Running Tests

Navigate to the test project and execute:

```bash
dotnet test
```

This runs all unit and validation tests using MSTest.

---

## 📁 Project Structure

```
AnimalFriendsAPI/         - Main Web API
  └── Scripts/            - SQL scripts for DB setup
AnimalFriends.Tests/      - Test project
```

---
