using expenseTracker.DataAccess.Enums;

namespace expenseTracker.DataAccess.Services;

public class FileMetadata
{
    public string FileName { get; init; }
    public FileExtension Extension { get; init; }

    public FileMetadata(FileExtension extension, string fileName = "expenses")
    {
        FileName = fileName.ToLower();
        Extension = extension;
    }

    public string GetFullPath()
    {
        return $"{FileName}.{Extension}";
    }



}