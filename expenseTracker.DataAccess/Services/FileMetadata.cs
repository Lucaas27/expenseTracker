using expenseTracker.DataAccess.Enums;

namespace expenseTracker.DataAccess.Services;

public class FileMetadata
{
    public const string FileName = "expenses";
    public FileExtension Extension { get; init; }

    public FileMetadata(FileExtension extension)
    {
        Extension = extension;
    }

    public string GetFullPath()
    {
        return $"{FileName}.{Extension}";
    }



}