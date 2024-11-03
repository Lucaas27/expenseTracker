using expenseTracker.App.Interfaces;
using expenseTracker.App.Repositories;

namespace expenseTracker.App.Services;

public class UpdateStrategy : IArgumentStrategy
{
    public void Execute(string[] args, IUserInteraction userInteraction, IExpensesRepository expensesRepository)
    {
        Console.WriteLine("NotImplementedException");
    }
}
