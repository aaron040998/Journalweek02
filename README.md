# 📔 Journal Program - CSE 210 Project
_A simple journal app with prompts, auto-save, and PDF export._

---

## 🚀 Features
- Write entries using **random prompts**
- Save/Load journals to/from text files
- Export entries as **PDF** or **text**
- Auto-save on exit (`AutoSaves/autosave_journal.txt`)
- Organized folders: `SavedFiles`, `ExportedFiles`, `readyToLoad`

---

## 📦 Requirements
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- **iTextSharp** (for PDF export):
  ```bash
  dotnet add package iTextSharp
  ```

---

## 🛠️ Quick Start

1. Clone & Install:
   ```bash
   git clone https://github.com/your-username/journalApp.git
   cd journalApp
   dotnet restore
   ```

2. Run the program:
   ```bash
   dotnet run
   ```
"""## 🖥️ Usage

### 1. Writing an Entry
- Choose **Option 1** from the menu.
- Answer the random prompt shown.
- The entry is saved automatically in memory.

### 2. Saving/Loading Journals

**Save:**
- Choose **Option 3**.
- Enter a filename (e.g., `mydiary`).
- File saved to `SavedFiles/mydiary.txt`.

**Load:**
- Choose **Option 4**.
- Enter a filename from `readyToLoad/` (e.g., `jreadtoday`).

### 3. Exporting Entries
- Choose **Option 5**.
- Select:
  - **a:** Export all entries.
  - **b:** Filter by date (e.g., `05/25/2024`).
- Choose format:
  - `1` for text
  - `2` for PDF
- Files saved to `ExportedFiles/`.

### 4. Exiting the Program
- Choose **Option 6** to quit.
- Auto-saves to `AutoSaves/autosave_journal.txt`.
"""