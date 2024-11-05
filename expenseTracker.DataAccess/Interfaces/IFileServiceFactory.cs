using expenseTracker.DataAccess.Services;
using expenseTracker.DataAccess.Interfaces;

namespace expenseTracker.DataAccess.Factories;

public interface IFileServiceFactory
{
    IFileService Create(FileMetadata filemetadata);
}