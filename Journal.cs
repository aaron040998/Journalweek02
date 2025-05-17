using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Journal
{
    private readonly List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry) => _entries.Add(entry);

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }
        foreach (var entry in _entries)
            Console.WriteLine(entry.GetEntryText());
    }

    public void SaveToFile(string filename)
    {
        using var writer = new StreamWriter(filename);
        foreach (var entry in _entries)
            writer.WriteLine(entry.ToFileString());
        Console.WriteLine($"Journal saved to {filename}");
    }

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
            _entries.Add(Entry.FromFileString(line));
        Console.WriteLine($"Journal loaded from {filename}");
    }

    public List<Entry> GetEntriesByDate(string date)
    {
        return _entries.Where(e => e.Date == date).ToList();
    }
}
