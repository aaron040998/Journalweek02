// Exporter.cs
// -------------------------------------------------------
// Handles exporting journal entries to different formats.
// Provides text and PDF export capabilities as an extension
// beyond core project requirements.
//
// Extra contributions:
// - PDF export using iTextSharp library.
// - Clear logging of export results.
// - Separation of export logic from Journal core functionality.

using System;
using System.Collections.Generic;
using System.IO;
// Note: Requires the iTextSharp NuGet package for PDF export.
// Install via: dotnet add package iTextSharp

public class Exporter
{
    /// <summary>
    /// Exports a list of entries to a plain text file.
    /// </summary>
    /// <param name="entries">Entries to export.</param>
    /// <param name="filename">Full path (including directory) to write the file.</param>
    public void ExportToText(List<Entry> entries, string filename)
    {
        // Improvement: consider wrapping in try/catch to catch disk or permission errors
        using var writer = new StreamWriter(filename);
        foreach (var e in entries)
        {
            // Uses Entry.ToString() override to format each entry
            writer.WriteLine(e.ToString());
        }
        Console.WriteLine($"Exported {entries.Count} entries to text file '{filename}'.");
    }

    /// <summary>
    /// Exports a list of entries to a PDF file.
    /// </summary>
    /// <param name="entries">Entries to export.</param>
    /// <param name="filename">Full path (including directory) to create the PDF.</param>
    public void ExportToPdf(List<Entry> entries, string filename)
    {
        // Improvement: abstract PDF logic behind an interface for easier testing or swapping libraries
        using var fs = new FileStream(filename, FileMode.Create, FileAccess.Write);

        // iTextSharp document setup
        var doc = new iTextSharp.text.Document();
        var writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, fs);

        doc.Open();
        foreach (var e in entries)
        {
            // Add each entry as a separate paragraph
            doc.Add(new iTextSharp.text.Paragraph($"Date: {e.Date}"));
            doc.Add(new iTextSharp.text.Paragraph($"Prompt: {e.Prompt}"));
            doc.Add(new iTextSharp.text.Paragraph($"Response: {e.Response}\n"));
        }
        doc.Close();

        Console.WriteLine($"Exported {entries.Count} entries to PDF file '{filename}'.");
    }
}
