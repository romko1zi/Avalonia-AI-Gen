# Blueprint: Student Data Entry Application

## 1. Overview

This application is a desktop utility built with Avalonia UI for entering and saving student data. The primary function is to capture detailed student information through a multi-tab form and persist it locally in a CSV file for easy access and record-keeping.

## 2. Core Features & Design

### 2.1. Data Model (`StudentData.cs`)

A dedicated class `StudentData` encapsulates all student-related information, providing a clean separation between data and presentation. The properties cover:

*   **Academic Details:** Identifier, admission date, record number, field of study, semester, start date, and start year.
*   **Personal Information:** PESEL, name, surname, gender, date and place of birth, nationality.
*   **Contact & Address:** Primary address, secondary Polish address, parental information, and contact details.
*   **Documents & Status:** Passport details, document numbers, issuance information, and status flags (e.g., `StatusUKR`).

### 2.2. User Interface (`MainWindow.axaml`)

*   **Window:** A fixed-size window (`800x700`) titled "Student Data".
*   **Tabbed Layout:** A `TabControl` organizes the extensive data fields into five logical sections, improving user experience:
    1.  **Учеба (Academics):** Fields related to the student's studies.
    2.  **Личные данные (Personal Data):** Personal identification details.
    3.  **Адрес (Address):** Residential information, including a separate section for a Polish address.
    4.  **Контакты/Семья (Contacts/Family):** Family and emergency contact details.
    5.  **Документы/Статус (Documents/Status):** Passport, visa, and other official records.
*   **Controls:** The form utilizes appropriate controls for each data type:
    *   `TextBox` for text input.
    *   `DatePicker` for dates.
    *   `CheckBox` for boolean flags.
*   **Action Button:** A prominent "Сохранить в CSV" (Save to CSV) button is placed at the bottom.

### 2.3. Application Logic (`MainWindow.axaml.cs`)

*   **Code-Behind:** The application logic is intentionally kept simple and resides directly in the `MainWindow.axaml.cs` file.
*   **Save Functionality:** The `SaveButton_Click` event handler is `async` and performs the following actions:
    1.  **Data Collection:** It retrieves the values from all input controls (`TextBox`, `DatePicker`, `CheckBox`).
    2.  **Object Population:** A new `StudentData` object is instantiated and populated with the collected data.
    3.  **CSV Formatting:** The data from the `StudentData` object is serialized into a single semicolon-delimited (`;`) string.
    4.  **File Dialog:** It opens a `SaveFileDialog`, allowing the user to choose the location and filename for the CSV file.
    5.  **File Persistence:** The generated CSV string is appended to the user-selected file path.
    6.  **User Feedback:** The window title is updated to "Сохранено!" (Saved!) on success or "Сохранение отменено." (Save cancelled.) if the dialog is closed.

## 3. Current Implementation Plan

*This section is for the current requested change.*

**Request:** Allow the user to choose the save path for the CSV file.

**Steps:**
1.  [x] **Modify Event Handler:** Change the `SaveButton_Click` method to be `async`.
2.  [x] **Implement `SaveFileDialog`:** Add code to create, configure, and show a `SaveFileDialog`.
3.  [x] **Update File Writing:** Use the path returned from the dialog to save the file using `File.AppendAllTextAsync`.
4.  [x] **Provide User Feedback:** Update the window title to reflect the outcome of the save operation (success or cancellation).
