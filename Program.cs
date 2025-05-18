using System;
using System.Collections.Generic;
using System.IO;

// Program.cs
// -------------------------------------------------------
// Main program for the Journal Program application.
// Manages the user menu, integrates Journal, PromptGenerator,
// and Exporter classes, and organizes directories for saving,
// loading, auto-saving, and exporting entries.
//
// Extra contributions:
// - Auto-save on exit in the AutoSaves folder.
// - Export to both text and PDF formats using iTextSharp. .
// - Filtering export by date or exporting all entries.
// - Organized file structure with dedicated folders.
// - Automatic creation of required directories.

class Program
{
    static void Main(string[] args)
    {
        // Define directory paths for different I/O responsibilities
        string saveDir     = "SavedFiles";
        string autoSaveDir = "AutoSaves";
        string exportDir   = "ExportedFiles";
        string loadDir     = "readyToLoad";

        // Ensure all directories exist to prevent path errors
        Directory.CreateDirectory(saveDir);
        Directory.CreateDirectory(autoSaveDir);
        Directory.CreateDirectory(exportDir);
        Directory.CreateDirectory(loadDir);

        var journal   = new Journal();           // Manages journal entries
        var promptGen = new PromptGenerator();   // Generates random prompts
        var exporter  = new Exporter();          // Handles export logic

        bool running = true;
        while (running)
        {
            // Display the main menu options
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
                    // Create a new entry: show prompt and capture user response
                    var prompt  = promptGen.GetRandomPrompt();
                    Console.WriteLine($"\n{prompt}");
                    Console.Write("> ");
                    var response = Console.ReadLine();
                    // Date formatted using current culture; consider ISO (yyyy-MM-dd)
                    var date     = DateTime.Now.ToShortDateString();
                    journal.AddEntry(new Entry(date, prompt, response));
                    break;

                case "2":
                    // Display all journal entries via overridden ToString()
                    journal.DisplayEntries();
                    break;

                case "3":
                    // Save the journal to a text file
                    Console.Write("Enter filename to save (without extension): ");
                    var saveName = Console.ReadLine();
                    // Automatically append .txt extension
                    var savePath = Path.Combine(saveDir, saveName + ".txt");
                    journal.SaveToFile(savePath);
                    break;

                case "4":
                    // Load the journal from a text file
                    Console.Write("Enter filename to load (without extension): ");
                    var loadName = Console.ReadLine();
                    // Automatically append .txt extension
                    var loadPath = Path.Combine(loadDir, loadName + ".txt");
                    journal.LoadFromFile(loadPath);
                    break;

                case "5":
                    // Export entries: either all entries or filter by date
                    Console.WriteLine("Export options:");
                    Console.WriteLine("  a) Export all entries");
                    Console.WriteLine("  b) Export entries by date");
                    Console.Write("Choose (a/b): ");
                    var opt = Console.ReadLine()?.ToLower();
                    List<Entry> toExport = (opt == "b")
                        ? journal.GetEntriesByDate(PromptForDate())
                        : journal.GetAllEntries();

                    // Choose export format with validation loop
                    string fmt;
                    do
                    {
                        Console.Write("Choose format (1=text, 2=pdf): ");
                        fmt = Console.ReadLine();
                    } while (fmt != "1" && fmt != "2");

                    // Ask for base filename without extension
                    Console.Write("Enter export filename (without extension): ");
                    var fnameBase = Console.ReadLine();

                    // Automatically append appropriate extension
                    string extension = (fmt == "1") ? ".txt" : ".pdf";
                    var fullExportPath = Path.Combine(exportDir, fnameBase + extension);

                    // Dispatch to exporter with exception handling
                    try
                    {
                        if (fmt == "1")
                            exporter.ExportToText(toExport, fullExportPath);
                        else
                            exporter.ExportToPdf(toExport, fullExportPath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Export failed: {ex.Message}");
                    }
                    break;

                case "6":
                    // Exit the program with an auto-save
                    running = false;
                    var autoPath = Path.Combine(autoSaveDir, "autosave_journal.txt");
                    journal.SaveToFile(autoPath);
                    Console.WriteLine($"Auto-saved to '{autoPath}'. Goodbye!");
                    break;

                default:
                    // Handle invalid menu selections
                    Console.WriteLine("Invalid choice. Please enter a number 1-6.");
                    break;
            }
        }
    }

    /// <summary>
    /// Prompts the user for a date string in MM/DD/YYYY format.
    /// </summary>
    private static string PromptForDate()
    {
        Console.Write("Enter date (MM/DD/YYYY): ");
        return Console.ReadLine();
    }
}
