using expenseTracker.App.Interfaces;
using expenseTracker.CLI.Interfaces;

namespace expenseTracker.App.Services;

public class HelpStrategy : IArgumentStrategy
{
    public void Execute(string[] args, IUserInteraction userInteraction, IExpensesRepository _)
    {
        userInteraction.ShowWarning("Usage: dotnet run --project expenseTracker.App [command] [options]");
        userInteraction.ShowWarning("Commands:");
        userInteraction.ShowWarning("\tadd\t\t\tAdd a new expense");
        userInteraction.ShowWarning("\tupdate\t\t\tUpdate a new expense");
        userInteraction.ShowWarning("\tdelete\t\t\tDelete an expense");
        userInteraction.ShowWarning("\tlist\t\t\tList all expenses");
        userInteraction.ShowWarning("\tsummary\t\t\tShow a summary of all expenses");
        userInteraction.ShowWarning("\thelp\t\t\tShow help");
        userInteraction.ShowWarning("Options:");
        userInteraction.ShowWarning("\t--description\t\tDescription of the expense");
        userInteraction.ShowWarning("\t--amount\t\tAmount of the expense");
        userInteraction.ShowWarning("\t--id\t\t\tId of the expense");
        userInteraction.ShowWarning("\t--month\t\t\tMonth of the expense");
        userInteraction.ShowWarning("\t--all\t\t\t Used to delete all expenses");
        userInteraction.ShowWarning("Example:");
        userInteraction.ShowWarning("\tdotnet run --project expenseTracker.App add --description \"Coffee\" --amount 2.50");
        userInteraction.ShowWarning("\tdotnet run --project expenseTracker.App update --id 1 --description \"Water\"");
        userInteraction.ShowWarning("\tdotnet run --project expenseTracker.App update --id 1 --amount 2");
        userInteraction.ShowWarning("\tdotnet run --project expenseTracker.App delete --id 1");
        userInteraction.ShowWarning("\tdotnet run --project expenseTracker.App delete --all");
        userInteraction.ShowWarning("\tdotnet run --project expenseTracker.App summary");
        userInteraction.ShowWarning("\tdotnet run --project expenseTracker.App summary --month 1");
        userInteraction.ShowWarning("\tdotnet run --project expenseTracker.App list");
        userInteraction.ShowWarning("\tdotnet run --project expenseTracker.App help");
    }
}
