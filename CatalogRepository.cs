using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace katalog;

public sealed class CatalogRepository
{
    public string FilePath { get; }

    public CatalogRepository()
    {
        var workingDirectoryPath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "dane",
            "pozycje.txt");
        FilePath = File.Exists(workingDirectoryPath)
            ? workingDirectoryPath
            : Path.Combine(AppContext.BaseDirectory, "dane", "pozycje.txt");
    }

    public List<CatalogItem> LoadAll()
    {
        var lines = File.ReadAllLines(FilePath, Encoding.UTF8);
        var items = new List<CatalogItem>();

        for (var index = 0; index < lines.Length; index++)
        {
            if (string.IsNullOrWhiteSpace(lines[index]))
            {
                continue;
            }

            var fields = lines[index].Split(';');
            if (fields.Length != 3 ||
                string.IsNullOrWhiteSpace(fields[0]) ||
                !int.TryParse(fields[1], out var year) ||
                !int.TryParse(fields[2], out var rating))
            {
                throw new FormatException(
                    $"Nieprawidłowy format w wierszu {index + 1} pliku pozycje.txt.");
            }

            items.Add(new CatalogItem(fields[0].Trim(), year, rating));
        }

        return items;
    }

    public int CountLines()
    {
        return File.ReadAllLines(FilePath, Encoding.UTF8).Length;
    }

    public void Add(CatalogItem item)
    {
        if (string.IsNullOrWhiteSpace(item.Title) || item.Title.Contains(';'))
        {
            throw new ArgumentException("Tytuł jest wymagany i nie może zawierać średnika.");
        }

        if (item.Year < 1)
        {
            throw new ArgumentException("Rok musi być większy od zera.");
        }

        if (item.Rating is < 1 or > 10)
        {
            throw new ArgumentException("Ocena musi być liczbą od 1 do 10.");
        }

        File.AppendAllText(
            FilePath,
            $"{item.Title.Trim()};{item.Year};{item.Rating}{Environment.NewLine}",
            new UTF8Encoding(false));
    }
}
