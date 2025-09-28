# Employee Management System

## Overview
**Employee Management System** is a .NET 8 based Employee Management System with both **Web API endpoints** and **MVC views**.  
It manages employees, documents, and user accounts with a layered service–repository architecture.  

---

## Features
- Employee CRUD operations
- User authentication and account handling (Login, Register)
- Document upload and management
- MVC pages + API-like controllers

---

## Project Structure
Employee-Management.sln     -> Solution file
employeeManagement/         -> Main project
├── Program.cs              -> Entry point
├── appsettings.json        -> Configurations
├── BAL/                    -> Business Logic Layer
├── Interfaces/             -> Abstractions
├── Repositories/           -> Implementations
├── Controllers/            -> MVC + API controllers
└── Models/                 -> Entity classes

---

## Tech Stack
- **.NET 8** (ASP.NET Core MVC + Web API)
- **C#**
- **Entity Framework Core** (for persistence)
- **SQL Server** (default, configurable in \`appsettings.json\`)

---

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- postgresql (or update connection string in configs)

### Run the Project
\`\`\`bash
cd employeeManagement
dotnet restore
dotnet build
dotnet run
\`\`\`

### Configuration
Set your connection string in \`appsettings.json\` or \`appsettings.Development.json\`.

---

## Controllers & Endpoints

### 🔹 AccountController
Handles user accounts and authentication.

- \`GET /Account/Login\` → Returns login view
- \`POST /Account/Login\` → Authenticates user (form post)
- \`GET /Account/Register\` → Returns registration view
- \`POST /Account/Register\` → Creates new user account
- \`GET /Account/Logout\` → Logs out user

### 🔹 EmployeeController
Handles employee management.

- \`GET /Employee/Index\` → Show list of employees
- \`GET /Employee/Details/{id}\` → Show employee details
- \`GET /Employee/Create\` → Return create employee form
- \`POST /Employee/Create\` → Create new employee
- \`GET /Employee/Edit/{id}\` → Return edit form
- \`POST /Employee/Edit/{id}\` → Update employee
- \`GET /Employee/Delete/{id}\` → Return delete confirmation
- \`POST /Employee/Delete/{id}\` → Delete employee

### 🔹 DocumentController
Handles employee-related documents.

- \`GET /Document/Index\` → List all documents
- \`GET /Document/Upload\` → Show upload form
- \`POST /Document/Upload\` → Upload new document
- \`GET /Document/Delete/{id}\` → Delete a document

### 🔹 HomeController
Default controller.

- \`GET /Home/Index\` → Home page / dashboard
- \`GET /Home/Privacy\` → Privacy page
- \`GET /\` → Redirects to Home

---

## Future Enhancements
- Convert some controllers to pure REST APIs for frontend (React/Angular)
- Add JWT authentication
- Swagger/OpenAPI for API docs
- CI/CD setup with Docker + Azure"# Employee-Management" 
