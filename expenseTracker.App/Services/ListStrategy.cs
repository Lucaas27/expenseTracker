using expenseTracker.App.Interfaces;
using expenseTracker.DataAccess.Interfaces;

namespace expenseTracker.App.Services;

public class ListStrategy : IArgumentStrategy
{
    public void Execute(string[] args, IUserInteraction userInteraction, IFileService fileService)
    {
        Console.WriteLine("NotImplementedException");
    }
}
