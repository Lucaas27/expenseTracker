using expenseTracker.App.Extensions;
using expenseTracker.App.Interfaces;
using expenseTracker.CLI.Interaction;
using expenseTracker.CLI.Interfaces;

namespace expenseTracker.App.Services;

public class SummaryStrategy : IArgumentStrategy
{
    public void Execute(string[] args, IUserInteraction userInteraction, IExpensesRepository expensesRepository)
    {
        var month = args.IsOptionValueProvided("--month", out var monthValue) && int.TryParse(monthValue, out int monthInt) ? monthInt : -1;
        var allExpenses = expensesRepository.ReadExpensesFromFile();

        if (allExpenses.Count == 0)
        {
            userInteraction.ShowMessage("There are no records to be displayed. Add expenses and try again.");
            return;
        }

        if (month == -1 && !args.Contains("--month"))
        {

            var total = allExpenses.Sum(e => e.Amount);

            userInteraction.ShowMessage($"Total expenses: {string.Format(GlobalCulture.CultureInfo, "{0:C}", total)}");
            return;
        }

        if (month <= 0 || month > 12)
        {
            userInteraction.ShowError("Months should be integers between 1 and 12.");
            return;
        }

        var monthName = GlobalCulture.DateTimeFormatInfo.GetMonthName(month);
        var totalForMonth = allExpenses
                                    .Where(e => e.CreatedAt.ToString("MMMM") == monthName)
                                    .Sum(e => e.Amount);

        userInteraction.ShowMessage($"Total expenses for {monthName}: {string.Format(GlobalCulture.CultureInfo, "{0:C}", totalForMonth)}");

    }
}
