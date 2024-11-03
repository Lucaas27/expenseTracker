using expenseTracker.App.Interfaces;
using expenseTracker.CLI.Interfaces;

namespace expenseTracker.App.Services;

public class ListStrategy : IArgumentStrategy
{
    public void Execute(string[] args, IUserInteraction userInteraction, IExpensesRepository expensesRepository)
    {
        var expenses = expensesRepository.ReadExpensesFromFile();

        var expensesTable = userInteraction.FormatAsTable(expenses);
        userInteraction.ShowMessage(expensesTable);


    }
}
