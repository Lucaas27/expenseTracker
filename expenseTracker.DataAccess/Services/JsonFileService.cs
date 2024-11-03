using System.Text.Json;
using expenseTracker.DataAccess.Interfaces;

namespace expenseTracker.DataAccess.Services;

public class JsonFileService : IFileService
{
    private readonly FileMetadata _fileMetadata;

    public JsonFileService(FileMetadata fileMetadata)
    {
        _fileMetadata = fileMetadata;
    }

    public List<T> ReadFromFile<T>()
    {
        var path = _fileMetadata.GetFullPath();

        if ((path == null) || !File.Exists(path))
        {
            return new List<T>();
        }

        var json = File.ReadAllText(path);

        try
        {
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();

        }
        catch (Exception)
        {
            return new List<T>();
        }

    }

    public void SaveToFile<T>(List<T> content)
    {
        var path = _fileMetadata.GetFullPath();
        var json = JsonSerializer.Serialize(content);

        File.WriteAllText(path, json);
    }
}