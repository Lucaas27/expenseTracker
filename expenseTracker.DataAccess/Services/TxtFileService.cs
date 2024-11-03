using expenseTracker.DataAccess.Interfaces;

namespace expenseTracker.DataAccess.Services;

public class TxtFileService : IFileService
{

    private readonly FileMetadata _fileMetadata;

    public TxtFileService(FileMetadata fileMetadata)
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
