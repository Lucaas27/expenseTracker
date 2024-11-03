using expenseTracker.DataAccess.Services;
using expenseTracker.DataAccess.Enums;
using expenseTracker.DataAccess.Interfaces;

namespace expenseTracker.DataAccess.Factories;

public class FileServiceFactory
{
    public IFileService Create(FileMetadata filemetadata)
    {
        return filemetadata.Extension switch
        {
            FileExtension.Txt => new TxtFileService(filemetadata),
            FileExtension.Csv => new CsvFileService(filemetadata),
            FileExtension.Json => new JsonFileService(filemetadata),
            _ => throw new NotImplementedException(nameof(filemetadata.Extension))
        };
    }

}
