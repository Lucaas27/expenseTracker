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
        throw new NotImplementedException();
    }

    public void SaveToFile<T>(T content)
    {
        throw new NotImplementedException();
    }
}