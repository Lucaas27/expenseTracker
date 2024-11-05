using expenseTracker.App.Interfaces;
using expenseTracker.App.Services;

namespace expenseTracker.App.Factories;

public class ArgumentStrategyFactory : IArgumentStrategyFactory
{
    public IArgumentStrategy Create(string command)
    {
        return command switch
        {
            "add" => new AddStrategy(),
            "list" => new ListStrategy(),
            "update" => new UpdateStrategy(),
            "delete" => new DeleteStrategy(),
            "summary" => new SummaryStrategy(),
            "export" => new ExportStrategy(),
            "help" => new HelpStrategy(),
            _ => throw new ArgumentException("Invalid command provided. Please check and try again.", nameof(command))
        };
    }

}
