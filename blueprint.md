# Blueprint: Student Data Entry Application

## 1. Overview

This application is a desktop utility built with Avalonia UI for entering and saving student data. The primary function is to capture detailed student information through a multi-tab form and persist it in a **PostgreSQL database**.

## 2. Core Features & Design

### 2.1. Data Model (`StudentData.cs`)

A dedicated class `StudentData` encapsulates all student-related information, providing a clean separation between data and presentation. It serves as the data transfer object between the UI and the database service.

### 2.2. User Interface (`MainWindow.axaml`)

*   **Window:** A fixed-size window (`800x700`) for data entry.
*   **Tabbed Layout:** A `TabControl` organizes the extensive data fields into five logical sections: "Учеба", "Личные данные", "Адрес", "Контакты/Семья", and "Документы/Статус".
*   **Controls:** The form utilizes appropriate controls for each data type (`TextBox`, `DatePicker`, `CheckBox`).
*   **Action Button:** A button at the bottom triggers the save operation. (Note: The button label is currently "Сохранить в CSV" and should be updated).

### 2.3. Database Service (`Services/DatabaseService.cs`)

*   **Responsibility:** This class encapsulates all database-related logic, separating it from the UI layer.
*   **Connection:** It uses the `Npgsql` library to connect to a PostgreSQL database. The connection string is hardcoded for simplicity.
*   **`SaveStudent` Method:** This public method accepts a `StudentData` object and performs the following:
    1.  Opens a connection to the database.
    2.  Constructs an `INSERT INTO students (...) VALUES (...)` SQL command.
    3.  Uses parameterized queries to safely insert a subset of student data (Identifikator, Nazwisko, Imie1, etc.) into the `students` table.

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

**Request:** Migrate data persistence from CSV to a PostgreSQL database.

**Steps:**
1.  [x] **Add Dependency:** Add the `Npgsql` NuGet package to the project.
2.  [x] **Create Database Service:** Create a new `Services/DatabaseService.cs` class to handle database connections and `INSERT` operations.
3.  [x] **Update UI Logic:** Modify `Views/MainWindow.axaml.cs` to remove the CSV-saving logic.
4.  [x] **Integrate Service:** In `MainWindow.axaml.cs`, instantiate and use the new `DatabaseService` to save the student data.
5.  [x] **Implement Error Handling:** Add a `try-catch` block to manage database exceptions and provide feedback to the user via the window title.
