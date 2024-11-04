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

    public void SaveToFile<T>(List<T> content)
    {
        var fullPath = _fileMetadata.GetFullPath();
        using var sw = new StreamWriter(fullPath);
        foreach (var item in content)
        {
            sw.WriteLine(item?.ToString());
        }
    }
}
