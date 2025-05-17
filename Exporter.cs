using System;
using System.Collections.Generic;
using System.IO;
// Necesita instalar iTextSharp: Install-Package iTextSharp

public class Exporter
{
    public void ExportToText(List<Entry> entries, string filename)
    {
        using var writer = new StreamWriter(filename);
        foreach (var e in entries)
            writer.WriteLine(e.GetEntryText());
        Console.WriteLine($"Exported {entries.Count} entries to text file '{filename}'.");
    }

    public void ExportToPdf(List<Entry> entries, string filename)
    {
        // Ejemplo con iTextSharp
        using var fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
        var doc = new iTextSharp.text.Document();
        var writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, fs);
        doc.Open();
        foreach (var e in entries)
        {
            doc.Add(new iTextSharp.text.Paragraph($"Date: {e.Date}"));
            doc.Add(new iTextSharp.text.Paragraph($"Prompt: {e.Prompt}"));
            doc.Add(new iTextSharp.text.Paragraph($"Response: {e.Response}\n"));
        }
        doc.Close();
        Console.WriteLine($"Exported {entries.Count} entries to PDF file '{filename}'.");
    }
}
