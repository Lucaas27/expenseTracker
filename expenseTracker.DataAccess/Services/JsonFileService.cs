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
        throw new NotImplementedException();
    }

    public void SaveToFile<T>(T content)
    {
        var path = _fileMetadata.GetFullPath();
        var json = JsonSerializer.Serialize(content);

        File.WriteAllText(path, json);
    }
}