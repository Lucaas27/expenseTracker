using expenseTracker.App.Interfaces;
using expenseTracker.App.Services;

namespace expenseTracker.App.Factories;

public class ArgumentStrategyFactory
{
    public Dictionary<string, IArgumentStrategy> Create()
    {
        return new()
        {
            { "add", new AddStrategy() },
            { "list", new ListStrategy() },
            { "update", new UpdateStrategy() },
            { "delete", new DeleteStrategy() },
            { "summary", new SummaryStrategy() },
            { "export", new ExportStrategy() },
            { "help", new HelpStrategy() },
        };

    }

}
