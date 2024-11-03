using expenseTracker.App.Extensions;
using expenseTracker.App.Interfaces;
using expenseTracker.App.Models;
using expenseTracker.App.Repositories;

namespace expenseTracker.App.Services;

public class AddStrategy : IArgumentStrategy
{

    public void Execute(string[] args, IUserInteraction userInteraction, IExpensesRepository expensesRepository)
    {
        decimal amountValue = default;

        // Check if the description is provided
        var isDescriptionValid = args.IsOptionValueProvided("--description", out string? description) && !string.IsNullOrWhiteSpace(description);

        // Check if the amount is provided
        var isAmountValid = args.IsOptionValueProvided("--amount", out string? amount) && decimal.TryParse(amount, out amountValue);

        if (!isDescriptionValid || !isAmountValid)
        {
            userInteraction.ShowError("The options --description and --amount are mandatory. Please check the arguments and try again with valid values.");
            return;
        }

        var expense = new Expense(description!, amountValue, expensesRepository.GetNextId());

        expensesRepository.SaveExpenseToFile(expense);

        userInteraction.ShowMessage($"Expense added successfully (ID: {expense.Id})");

    }
}