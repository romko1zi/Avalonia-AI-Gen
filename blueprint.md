# Blueprint: Student Data Entry Application

## 1. Overview

This application is a desktop utility built with Avalonia UI for entering and saving student data. The primary function is to capture detailed student information through a multi-tab form and persist it in a **local SQLite database**. This ensures the application is portable and does not require any external database server setup.

## 2. Core Features & Design

### 2.1. Data Model (`StudentData.cs`)

A dedicated class `StudentData` encapsulates all student-related information, providing a clean separation between data and presentation. It serves as the data transfer object between the UI and the database service.

### 2.2. User Interface (`MainWindow.axaml`)

*   **Window:** A fixed-size window (`800x700`) for data entry.
*   **Tabbed Layout:** A `TabControl` organizes the extensive data fields into five logical sections: "Учеба", "Личные данные", "Адрес", "Контакты/Семья", and "Документы/Статус".
*   **Controls:** The form utilizes appropriate controls for each data type (`TextBox`, `DatePicker`, `CheckBox`).
*   **Action Button:** A button at the bottom triggers the save operation.

### 2.3. Database Service (`Services/DatabaseService.cs`)

*   **Responsibility:** This class encapsulates all database-related logic, separating it from the UI layer.
*   **Connection:** It uses the `Microsoft.Data.Sqlite` library to connect to a local SQLite database. The connection string is `Data Source=students.db`, which creates the database file in the application's execution directory.
*   **Initialization:** The service's constructor calls a private `InitializeDatabase` method. This method ensures that the `students` table exists on application startup by executing a `CREATE TABLE IF NOT EXISTS` SQL command.
*   **`SaveStudent` Method:** This public method accepts a `StudentData` object and performs the following:
    1.  Opens a connection to the SQLite database.
    2.  Constructs an `INSERT INTO students (...) VALUES (...)` SQL command.
    3.  Uses parameterized queries (`SqliteCommand`) to safely insert student data into the `students` table. Dates are stored as ISO 8601 strings.

### 2.4. UI Logic (`Views/MainWindow.axaml.cs`)

*   **Code-Behind:** The logic in this file orchestrates the data flow.
*   **Service Instantiation:** It creates an instance of the `DatabaseService` upon initialization.
*   **Save Functionality:** The `SaveButton_Click` event handler performs the following actions:
    1.  **Data Collection:** It retrieves values from all input controls.
    2.  **Object Population:** It populates a `StudentData` object with the collected data.
    3.  **Service Call:** It calls the `_databaseService.SaveStudent()` method, passing the `StudentData` object.
    4.  **Error Handling & Feedback:** It wraps the database call in a `try-catch` block. On success, the window title is updated to "Сохранено в Базу Данных!". On failure, the title displays the specific error message.

## 3. Current Implementation Plan

*This section is for the current requested change.*

**Request:** Migrate the database layer from PostgreSQL (Npgsql) to SQLite (Microsoft.Data.Sqlite) to ensure application portability.

**Steps:**
1.  [x] **Update Dependencies:** Removed the `Npgsql` package and added the `Microsoft.Data.Sqlite` package in `myapp.csproj`.
2.  [x] **Rewrite DatabaseService.cs:**
    *   Replaced `using Npgsql;` with `using Microsoft.Data.Sqlite;`.
    *   Changed the connection string to `"Data Source=students.db"`.
    *   Added a constructor that calls an `InitializeDatabase` method to create the `students` table if it doesn't exist.
3.  [x] **Update SaveStudent Method:** Refactored the method to use `SqliteConnection` and `SqliteCommand` for inserting data into the SQLite database.
4.  [x] **Verify Build:** Compiled the project with `dotnet build` to ensure there were no errors after the migration.
