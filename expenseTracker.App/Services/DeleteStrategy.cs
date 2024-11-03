using expenseTracker.App.Extensions;
using expenseTracker.App.Interfaces;
using expenseTracker.CLI.Interfaces;

namespace expenseTracker.App.Services;

public class DeleteStrategy : IArgumentStrategy
{
    public void Execute(string[] args, IUserInteraction userInteraction, IExpensesRepository expensesRepository)
    {

        if (args.Contains("--all") && args.Contains("--id"))
        {
            userInteraction.ShowError("The options --all and --id cannot be used together. Please check the arguments and try again.");
            return;
        }

        if (args.Contains("--all") && !args.Contains("--id"))
        {
            expensesRepository.DeleteAllExpenses();
            userInteraction.ShowMessage("All expenses have been deleted successfully.");
            return;
        }

        // Check if the id is provided and it's a valid integer
        var id = args.IsOptionValueProvided("--id", out string? value) && int.TryParse(value, out var idValue) ? idValue : default;

        if (id == default || id < 0)
        {
            userInteraction.ShowError("The option --id is mandatory and must be a valid positive integer. Please check the arguments and try again with a valid value.");
            return;
        }

        expensesRepository.DeleteExpenseFromFile(id);

        userInteraction.ShowMessage($"Expense deleted successfully (ID: {id})");



    }
}
