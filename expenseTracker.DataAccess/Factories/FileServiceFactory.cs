using expenseTracker.DataAccess.Services;
using expenseTracker.DataAccess.Enums;
using expenseTracker.DataAccess.Interfaces;

namespace expenseTracker.DataAccess.Factories;

public class FileServiceFactory : IFileServiceFactory
{
    public IFileService Create(FileMetadata filemetadata)
    {
        return filemetadata.Extension switch
        {
            FileExtension.txt => new TxtFileService(filemetadata),
            FileExtension.csv => new CsvFileService(filemetadata),
            FileExtension.json => new JsonFileService(filemetadata),
            _ => throw new NotImplementedException(nameof(filemetadata.Extension))
        };
    }

}
