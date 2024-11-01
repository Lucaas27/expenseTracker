using expenseTracker.App.Interaction;
using expenseTracker.App.Models;

namespace expenseTracker.App;

public class App
{

    public void Run(string[] args)
    {

        // foreach (var item in args)
        // {
        //     Console.WriteLine(item);
        // }

        var headers = args
                        .Where(arg => arg.StartsWith("--"))
                        .Select(arg => arg.Substring(2))
                        .Select(arg => GlobalCulture.TextInfo.ToTitleCase(arg.ToLower()));

        foreach (var item in headers)
        {
            Console.WriteLine(item);
        }

        if (args.Length > 0)
        {
            var expense = new Expense("test description", 10.22m);
            ConsoleInteraction.ShowMessage(expense.ToString());
            return;
        }

        ConsoleInteraction.ShowError("Nothing to display. No arguments.");
    }

}