using System.Text;
using expenseTracker.DataAccess.Interfaces;

namespace expenseTracker.DataAccess.Services;

public class CsvFileService : IFileService
{
    private readonly FileMetadata _fileMetadata;

    public CsvFileService(FileMetadata fileMetadata)
    {
        _fileMetadata = fileMetadata;
    }
    public List<T> ReadFromFile<T>()
    {
        var content = new List<T>();
        var properties = typeof(T).GetProperties();
        var lines = File.ReadAllLines($"{_fileMetadata.FileName}.{_fileMetadata.Extension.ToString().ToLower()}");

        // Skip header
        foreach (var line in lines.Skip(1))
        {
            var values = line.Split(',');
            var item = Activator.CreateInstance<T>();

            for (int i = 0; i < properties.Length; i++)
            {
                var property = properties[i];
                property.SetValue(item, Convert.ChangeType(values[i], property.PropertyType));
            }

            content.Add(item);
        }

        return content;
    }

    public void SaveToFile<T>(List<T> content)
    {
        var csvContent = new StringBuilder();
        var properties = typeof(T).GetProperties();

        // Write header
        csvContent.AppendLine(string.Join(",", properties.Select(p => p.Name)));

        // Write rows
        foreach (var item in content)
        {
            var values = properties
                                    .Select(p => p.GetValue(item)?.ToString() ?? string.Empty)
                                    .Select(i => DateTime.TryParse(i, out var d) ? d.ToString("dd MMMM yyy hh:mm:ss tt") : i);
            csvContent.AppendLine(string.Join(",", values));
        }

        File.WriteAllText($"{_fileMetadata.FileName}.{_fileMetadata.Extension.ToString().ToLower()}", csvContent.ToString());
    }
}