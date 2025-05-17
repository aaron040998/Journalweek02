# Journal Program

### Description
Journal Program is a C# console application that helps users keep a journal by providing random prompts and allowing writing, displaying, saving, loading, and exporting entries.

### Features
- Write a new entry
- Display the journal
- Save the journal to a file
- Load the journal from a file
- Export the journal (text and PDF)
- Auto-save on quit
- File organization in separate folders: SavedFiles, AutoSaves, ExportedFiles, readyToLoad

### Requirements
- .NET SDK (6.0 or higher)
- iTextSharp library for PDF exporting (`dotnet add package iTextSharp`)
- `readyToLoad` folder containing `.txt` files to load

### Installation
1. Clone this repository or download the files.
2. Open the project folder in VS Code or Visual Studio.
3. Run in the terminal:
   ```bash
   dotnet add package iTextSharp
   dotnet build
   ```

### Usage
1. Run the application:
   ```bash
   dotnet run --project JournalApp
   ```
2. Interact with the menu:
   ```
   Journal Menu:
   1. Write a new entry
   2. Display the journal
   3. Save the journal to a file
   4. Load the journal from a file
   5. Export journal
   6. Quit
   Choose an option (1-6):
   ```
3. **Write a new entry**:  
   - Option `1` → Respond to the random prompt.  
4. **Display the journal**:  
   - Option `2` → Shows all entries on screen.  
5. **Save the journal**:  
   - Option `3` → Enter the filename.  
   - Saved in `SavedFiles/<filename>.txt`.  
6. **Load the journal**:  
   - Option `4` → Enter the filename.  
   - The program looks in the `readyToLoad` folder.  
7. **Export the journal**:  
   - Option `5` → Submenu:  
     - `a) Export all entries`  
     - `b) Export entries by date`  
   - Then choose format: `1=text`, `2=pdf`.  
   - Saved in `ExportedFiles/<filename>`.  
8. **Quit and auto-save**:  
   - Option `6` → Saved in `AutoSaves/autosave_journal.txt`.  

---

## Español

### Descripción
Journal Program es una aplicación de consola en C# que ayuda a los usuarios a mantener un diario mediante preguntas aleatorias, permitiendo escribir, mostrar, guardar, cargar y exportar entradas.

### Funcionalidades
- Escribir una nueva entrada
- Mostrar el diario
- Guardar el diario a archivo
- Cargar el diario desde archivo
- Exportar el diario (texto y PDF)
- Auto-guardado al salir
- Organización de archivos en carpetas separadas: SavedFiles, AutoSaves, ExportedFiles, readyToLoad

### Requisitos
- .NET SDK (6.0 o superior)
- Librería iTextSharp para exportación a PDF (`dotnet add package iTextSharp`)
- Carpeta `readyToLoad` con archivos `.txt` para cargar

### Instalación
1. Clona este repositorio o descarga los archivos.
2. Abre la carpeta del proyecto en VS Code o Visual Studio.
3. Ejecuta en la terminal:
   ```bash
   dotnet add package iTextSharp
   dotnet build
   ```

### Uso
1. Ejecuta la aplicación:
   ```bash
   dotnet run --project JournalApp
   ```
2. Interactúa con el menú:
   ```
   Journal Menu:
   1. Write a new entry
   2. Display the journal
   3. Save the journal to a file
   4. Load the journal from a file
   5. Export journal
   6. Quit
   Choose an option (1-6):
   ```
3. **Escribir una nueva entrada**:  
   - Opción `1` → Responde al prompt aleatorio.  
4. **Mostrar el diario**:  
   - Opción `2` → Muestra todas las entradas en pantalla.  
5. **Guardar el diario**:  
   - Opción `3` → Ingresa el nombre del archivo.  
   - Se guarda en `SavedFiles/<filename>.txt`.  
6. **Cargar el diario**:  
   - Opción `4` → Ingresa el nombre del archivo.  
   - El programa busca en la carpeta `readyToLoad`.  
7. **Exportar el diario**:  
   - Opción `5` → Submenú:  
     - `a) Exportar todo`  
     - `b) Exportar por fecha`  
   - Luego elige formato: `1=text`, `2=pdf`.  
   - Se guarda en `ExportedFiles/<filename>`.  
8. **Salir y auto-guardar**:  
   - Opción `6` → Se guarda en `AutoSaves/autosave_journal.txt`.


