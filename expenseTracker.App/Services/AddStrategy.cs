using expenseTracker.App.Extensions;
using expenseTracker.App.Interfaces;
using expenseTracker.App.Models;
using expenseTracker.CLI.Interfaces;

namespace expenseTracker.App.Services;

public class AddStrategy : IArgumentStrategy
{

    public void Execute(string[] args, IUserInteraction userInteraction, IExpensesRepository expensesRepository)
    {

        // Check if the description is provided
        var description = args.IsOptionValueProvided("--description", out string? descriptionValue) && !string.IsNullOrWhiteSpace(descriptionValue) ? descriptionValue : default;

        // Check if the description is provided
        var category = args.IsOptionValueProvided("--category", out string? categoryValue) && !string.IsNullOrWhiteSpace(categoryValue) ? categoryValue : default;

        // Check if the amount is provided
        var amount = args.IsOptionValueProvided("--amount", out string? amountValue) && decimal.TryParse(amountValue, out decimal amountValueParsed) ? amountValueParsed : default;

        if (amount < 0)
        {
            userInteraction.ShowError("Amount cannot be negative. Try again.");
            return;
        }

        if (description == default || amount == default)
        {
            userInteraction.ShowError("The options --description and --amount are mandatory. Please check the arguments and try again with valid values.");
            return;
        }

        var expense = new Expense(description!, amount, expensesRepository.GetNextId(), category);

        expensesRepository.SaveExpenseToFile(expense);

        userInteraction.ShowMessage($"Expense added successfully (ID: {expense.Id})");

    }
}