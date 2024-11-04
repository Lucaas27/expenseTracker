using expenseTracker.App.Extensions;
using expenseTracker.App.Interfaces;
using expenseTracker.CLI.Interfaces;

namespace expenseTracker.App.Services;

public class ListStrategy : IArgumentStrategy
{
    public void Execute(string[] args, IUserInteraction userInteraction, IExpensesRepository expensesRepository)
    {
        var expenses = expensesRepository.ReadExpensesFromFile();
        var category = args.IsOptionValueProvided("--category", out string? categoryValue) && !string.IsNullOrWhiteSpace(categoryValue) ? categoryValue : default;

        if (category != default)
        {
            expenses = expenses.Where(e => e.Category?.ToLower() == category.ToLower()).ToList();
        }

        var expensesTable = userInteraction.FormatAsTable(expenses);
        userInteraction.ShowMessage(expensesTable);


    }
}
