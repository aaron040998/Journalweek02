// Entry.cs
// -------------------------------------------------------
// Models a single journal entry with date, prompt, and response.
// Includes methods for serialization/deserialization and display.

using System;

public class Entry
{
    // Entry date (ideally stored as DateTime internally)
    public string Date { get; set; }

    // The prompt associated with this entry
    public string Prompt { get; set; }

    // The user's response text
    public string Response { get; set; }

    // Primary constructor
    public Entry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    // Override of ToString() for console display
    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }

    // Serialize entry for file storage
    public string ToFileString()
    {
        return $"{Date}|~|{Prompt}|~|{Response}";
    }

    // Deserialize a file line into an Entry instance
    public static Entry FromFileString(string line)
    {
        var parts = line.Split(new[] { "|~|" }, StringSplitOptions.None);
        // Improvement suggestion: validate parts.Length == 3 and handle errors
        return new Entry(parts[0], parts[1], parts[2]);
    }
}
