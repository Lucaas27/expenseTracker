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

    public string SaveToFile<T>(List<T> content)
    {
        throw new NotImplementedException();
    }
}