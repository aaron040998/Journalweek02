using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Definición de carpetas
        string saveDir     = "SavedFiles";
        string autoSaveDir = "AutoSaves";
        string exportDir   = "ExportedFiles";
        string loadDir     = "readyToLoad";

        // Crear carpetas si no existen
        Directory.CreateDirectory(saveDir);
        Directory.CreateDirectory(autoSaveDir);
        Directory.CreateDirectory(exportDir);
        // loadDir debe existir y contener los archivos a cargar

        var journal   = new Journal();
        var promptGen = new PromptGenerator();
        var exporter  = new Exporter();

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Export journal");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option (1-6): ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var prompt  = promptGen.GetRandomPrompt();
                    Console.WriteLine($"\n{prompt}");
                    Console.Write("> ");
                    var response = Console.ReadLine();
                    var date     = DateTime.Now.ToShortDateString();
                    journal.AddEntry(new Entry(date, prompt, response));
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    Console.Write("Enter filename to save (.txt): ");
                    var saveName = Console.ReadLine();
                    // Guarda dentro de SavedFiles
                    journal.SaveToFile(Path.Combine(saveDir, saveName));
                    break;

                case "4":
                    Console.Write("Enter filename to load from readyToLoad (.txt): ");
                    var loadName = Console.ReadLine();
                    // Carga desde readyToLoad
                    journal.LoadFromFile(Path.Combine(loadDir, loadName));
                    break;

                case "5":
                    Console.WriteLine("Export options:");
                    Console.WriteLine("  a) Export all entries");
                    Console.WriteLine("  b) Export entries by date");
                    Console.Write("Choose (a/b): ");
                    var opt = Console.ReadLine()?.ToLower();
                    List<Entry> toExport = new List<Entry>();

                    if (opt == "b")
                    {
                        Console.Write("Enter date (MM/DD/YYYY): ");
                        var d = Console.ReadLine();
                        toExport = journal.GetEntriesByDate(d);
                    }
                    else
                    {
                        toExport = journal.GetEntriesByDate(DateTime.Now.ToShortDateString());
                    }

                    Console.Write("Choose format (1=text, 2=pdf): ");
                    var fmt = Console.ReadLine();
                    Console.Write("Enter export filename (without path): ");
                    var fname = Console.ReadLine();

                    // Exporta dentro de ExportedFiles
                    var fullExportPath = Path.Combine(exportDir, fname);
                    if (fmt == "1")
                        exporter.ExportToText(toExport, fullExportPath);
                    else if (fmt == "2")
                        exporter.ExportToPdf(toExport, fullExportPath);
                    else
                        Console.WriteLine("Formato inválido.");
                    break;

                case "6":
                    running = false;
                    // Auto‐guardar en AutoSaves
                    var autoPath = Path.Combine(autoSaveDir, "autosave_journal.txt");
                    journal.SaveToFile(autoPath);
                    Console.WriteLine($"Auto-guardado en '{autoPath}'. ¡Hasta luego!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number 1-6.");
                    break;
            }
        }
    }
}
