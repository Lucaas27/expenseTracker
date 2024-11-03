using expenseTracker.DataAccess.Interfaces;

namespace expenseTracker.App.Interfaces;

public interface IArgumentStrategy
{
    void Execute(string[] args, IUserInteraction userInteraction, IFileService fileService);
}