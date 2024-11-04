using expenseTracker.App.Interfaces;
using expenseTracker.CLI.Interfaces;

namespace expenseTracker.App;

public class App
{
    private readonly string[] _args;
    private readonly IUserInteraction _userInteraction;
    private readonly Dictionary<string, IArgumentStrategy> _argumentStrategy;
    private readonly IExpensesRepository _expensesRepository;


    public App(string[] args, IUserInteraction userInteraction, Dictionary<string, IArgumentStrategy> argumentStrategy, IExpensesRepository expensesRepository)
    {
        _args = args ?? throw new ArgumentNullException(nameof(args));
        _userInteraction = userInteraction ?? throw new ArgumentNullException(nameof(userInteraction));
        _argumentStrategy = argumentStrategy ?? throw new ArgumentNullException(nameof(argumentStrategy));
        _expensesRepository = expensesRepository ?? throw new ArgumentNullException(nameof(expensesRepository));

    }

    public void Run()
    {
        if (_args.Length == 0)
        {
            _userInteraction.ShowError("No arguments provided, please check the arguments and try again.");
            return;
        }

        var command = _args[0].ToLower();

        if (_argumentStrategy.ContainsKey(command))
        {
            _argumentStrategy[command].Execute(_args, _userInteraction, _expensesRepository);
            return;
        }

        _userInteraction.ShowError("Invalid argument provided, please check the arguments and try again.");
    }

}