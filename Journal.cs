// Journal.cs
// -------------------------------------------------------
// Manages a collection of Entry objects: add, display,
// filter by date, save to file, and load from file.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Journal
{
    // Internal list of entries (_underscoreCamelCase convention)
    private readonly List<Entry> _entries = new List<Entry>();

    // Add a new entry to the journal
    public void AddEntry(Entry entry) => _entries.Add(entry);

    // Retrieve all entries (needed for “export all entries”)
    public List<Entry> GetAllEntries() => new List<Entry>(_entries);

    // Display each entry in the console
    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }
        foreach (var entry in _entries)
            Console.WriteLine(entry);
    }

    // Save entries to a file using the custom delimiter
    public void SaveToFile(string filename)
    {
        // Improvement: wrap in try/catch to handle I/O exceptions gracefully
        using var writer = new StreamWriter(filename);
        foreach (var entry in _entries)
            writer.WriteLine(entry.ToFileString());
        Console.WriteLine($"Journal saved to {filename}");
    }

    // Load entries from a file, replacing existing entries
    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"File '{filename}' not found.");
            return;
        }
        _entries.Clear();
        var lines = File.ReadAllLines(filename);
        foreach (var line in lines)
        {
            _entries.Add(Entry.FromFileString(line));
        }
        Console.WriteLine($"Journal loaded from {filename}");
    }

    // Return entries that match the exact date string
    public List<Entry> GetEntriesByDate(string date)
    {
        return _entries.Where(e => e.Date == date).ToList();
    }
}
