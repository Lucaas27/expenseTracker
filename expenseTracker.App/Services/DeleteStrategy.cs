using expenseTracker.App.Extensions;
using expenseTracker.App.Interfaces;
using expenseTracker.CLI.Interfaces;

namespace expenseTracker.App.Services;

public class DeleteStrategy : IArgumentStrategy
{
    public void Execute(string[] args, IUserInteraction userInteraction, IExpensesRepository expensesRepository)
    {

        // Check if the id is provided and it's a valid integer
        // If the id is not provided, it will default to 0
        var id = args.IsOptionValueProvided("--id", out string? value) && int.TryParse(value, out var idValue) ? idValue : default;

        // Delete the expense by id if the --all option is not provided and the id is a valid positive integer
        if (id != default && id > 0 && !args.Contains("--all"))
        {
            expensesRepository.DeleteExpenseFromFile(id);
            userInteraction.ShowMessage($"Expense deleted successfully (ID: {id})");
            return;
        }
        // Check if the --all option is provided and no id then delete all expenses
        if (args.Contains("--all") && id == default)
        {
            expensesRepository.DeleteAllExpenses();
            userInteraction.ShowMessage("All expenses have been deleted successfully.");
            return;
        }
        // Check if the --all option is provided along with the --id option and show an error message
        if (args.Contains("--all") && id != default)
        {
            userInteraction.ShowError("The options --all and --id cannot be used together. Please check the arguments and try again.");
            return;
        }

        userInteraction.ShowError("The option --id is mandatory and must be a valid positive integer. Please check the arguments and try again with a valid value.");

    }
}
