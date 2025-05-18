Aquí tienes un archivo **README.md** profesional para tu proyecto, listo para incluir en tu repositorio GitHub:

---

# 📔 Journal Program - CSE 210 Project

Una aplicación de diario en C# que ayuda a los usuarios a registrar sus pensamientos diarios mediante prompts aleatorios. ¡Incluye funciones avanzadas como exportación a PDF y auto-guardado!

## 🚀 Características Principales

- **Escritura guiada**: Recibe prompts aleatorios para inspirarte.
- **Guardado seguro**: Almacena tu diario en archivos de texto.
- **Exportación flexible**: Genera reportes en formato PDF o texto.
- **Organización inteligente**: 
  - Directorios dedicados (`SavedFiles`, `ExportedFiles`, etc.).
  - Auto-guardado al salir (`AutoSaves/autosave_journal.txt`).
- **Filtrado por fecha**: Exporta entradas específicas fácilmente.

## 📦 Requisitos Previos

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- IDE recomendado: [Visual Studio Code](https://code.visualstudio.com/) o Visual Studio

## 🔧 Instalación

1. Clona el repositorio:
   ```bash
   git clone https://github.com/tu-usuario/journalApp.git
   ```
2. Instala la dependencia para PDF (iTextSharp):
   ```bash
   cd journalApp
   dotnet add package iTextSharp
   ```

## 🖥️ Uso Básico

1. **Iniciar el programa**:
   ```bash
   dotnet run
   ```
   
2. **Menú principal**:
   ```
   Journal Menu:
   1. Write a new entry
   2. Display the journal
   3. Save the journal to a file
   4. Load the journal from a file
   5. Export journal
   6. Quit
   ```

### ✍️ Escribir una entrada
- Selecciona **Opción 1**.
- Responde al prompt mostrado.
- ¡La entrada se guarda automáticamente en memoria!

### 💾 Guardar/Cargar
- **Guardar**: Opción 3 → Ingresa nombre de archivo (se guarda en `SavedFiles/`).
- **Cargar**: Opción 4 → Selecciona archivo desde `readyToLoad/`.

### 📤 Exportar entradas
- Opción 5 → Elige entre:
  - `a) Exportar todo` o `b) Filtrar por fecha`.
  - Formatos disponibles: Texto (`.txt`) o PDF (`.pdf`).
  - Archivos generados en `ExportedFiles/`.

## 🛠️ Funciones Avanzadas (Exceso de Requisitos)
- **Auto-guardado**: Al salir (Opción 6), se guarda una copia en `AutoSaves/`.
- **Manejo de CSV**: Usa comillas para respuestas con comas (Ej: `"Hoy, fue un buen día"`).
- **Diseño modular**: Clases separadas (`Journal`, `Entry`, `Exporter`).

## 🗂️ Estructura de Archivos
```
journalApp/
├── SavedFiles/      # Diarios guardados manualmente
├── ExportedFiles/   # Exportaciones (PDF/texto)
├── AutoSaves/       # Copias de seguridad automáticas
└── readyToLoad/     # Archivos listos para cargar
```

## ⚠️ Solución de Problemas
- **Error al exportar PDF**: Asegúrate de tener permisos de escritura en `ExportedFiles/`.
- **Archivo no encontrado**: Verifica que el nombre esté escrito correctamente y sin extensión.

## 📜 Licencia
Este proyecto se distribuye bajo la licencia MIT. Ver [LICENSE](LICENSE) para más detalles.

---

**¡Feliz escritura!** ✨  
*BYU-Idaho - CSE 210: Programming with Classes* 

---

### 📌 Notas para la Entrega
1. Asegúrate de que el archivo `.csproj` incluya la referencia a iTextSharp:
   ```xml
   <PackageReference Include="iTextSharp" Version="5.5.13.3" />
   ```
2. Adjunta este README.md en la raíz de tu repositorio.
3. Verifica que todas las rutas de directorios se creen correctamente al ejecutar el programa.

Este README garantiza que cualquier evaluador o usuario pueda entender y probar todas las funcionalidades de tu proyecto de manera eficiente. 😊