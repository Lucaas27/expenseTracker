using expenseTracker.App.Extensions;
using expenseTracker.App.Interfaces;
using expenseTracker.App.Models;
using expenseTracker.CLI.Interfaces;

namespace expenseTracker.App.Services;

public class UpdateStrategy : IArgumentStrategy
{
    public void Execute(string[] args, IUserInteraction userInteraction, IExpensesRepository expensesRepository)
    {
        // Check if the id is provided and it's a valid integer
        var id = args.IsOptionValueProvided("--id", out string? value) && int.TryParse(value, out var idValue) ? idValue : default;

        var description = args.IsOptionValueProvided("--description", out string? descriptionValue) ? descriptionValue : default;

        var amount = args.IsOptionValueProvided("--amount", out string? amountValue) && decimal.TryParse(amountValue, out var amountValueParsed) ? amountValueParsed : default;

        if (amount == default && description == default)
        {
            userInteraction.ShowError("You must provide at least one of the options --amount or --description to update an expense. Please check the arguments and try again.");
            return;
        }

        if (id == default || id < 0)
        {
            userInteraction.ShowError("The option --id is mandatory and must be a valid positive integer. Please check the arguments and try again with a valid value.");
            return;
        }

        expensesRepository.UpdateExpense(id, amount, description!);
        userInteraction.ShowMessage($"Expense updated successfully (ID: {id})");

    }
}
