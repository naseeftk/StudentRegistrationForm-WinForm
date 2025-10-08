# 🧾 Student Registration Form (WinForms)

A simple **Windows Forms (.NET Framework)** CRUD application for managing student registration details.  
This project demonstrates how to build a basic desktop form with input controls, layout management, and database operations using **ADO.NET** and **SQL Server**.

---

## 🎯 Features

✅ Add new student records  
✅ Update existing student details  
✅ Delete student records  
✅ View all students in a grid  
✅ Validate user inputs (name, gender, age, etc.)  
✅ Clean layout using **TableLayoutPanel**  
✅ Works with **SQL Server database**

---

## 🧰 Technologies Used

| Category | Technology |
|-----------|-------------|
| Framework | .NET Framework (WinForms) |
| Database | SQL Server |
| Data Access | ADO.NET (`SqlConnection`, `SqlCommand`, `SqlDataReader`) |
| UI Controls | TextBox, ComboBox, RadioButton, NumericUpDown, DataGridView, TableLayoutPanel, ErrorProvider |

---

## 🖥️ User Interface Overview

- **TextBox** → Student Name, Father Name, Address  
- **NumericUpDown** → Age input  
- **RadioButton** → Gender selection (Male / Female)  
- **ComboBox** → Course selection  
- **RichTextBox** → Address entry  
- **DataGridView** → Displays all student records with **Edit** and **Delete** buttons  
- **TableLayoutPanel** → Used for responsive and organized form design  
- **ErrorProvider** → Input validation feedback  

---

## ⚙️ CRUD Operations

| Operation | Description |
|------------|--------------|
| **Create** | Insert new student record into SQL Server |
| **Read** | Fetch all student records and display in DataGridView |
| **Update** | Edit existing record and update in database |
| **Delete** | Remove selected record from database permanently |

---

## 🗃️ Database Table

**Table Name:** `Students`

| Column | Data Type | Description |
|---------|------------|-------------|
| Id | INT (Primary Key, Identity) | Auto-generated student ID |
| Name | VARCHAR(100) | Student’s full name |
| Age | INT | Student age |
| Address | VARCHAR(100) | Residential address |
| FatherName | VARCHAR(100) | Father’s name |
| Course | VARCHAR(100) | Selected course |
| Gender | VARCHAR(100) | Male/Female |




