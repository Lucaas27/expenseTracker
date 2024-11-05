using expenseTracker.App.Factories;
using expenseTracker.App.Interfaces;
using expenseTracker.CLI.Interfaces;

namespace expenseTracker.App;

public class App
{
    private readonly string[] _args;
    private readonly IUserInteraction _userInteraction;
    private readonly IArgumentStrategyFactory _argumentStrategyFactory;
    private readonly IExpensesRepository _expensesRepository;


    public App(string[] args, IUserInteraction userInteraction, IArgumentStrategyFactory argumentStrategyFactory, IExpensesRepository expensesRepository)
    {
        _args = args ?? throw new ArgumentNullException(nameof(args));
        _userInteraction = userInteraction ?? throw new ArgumentNullException(nameof(userInteraction));
        _argumentStrategyFactory = argumentStrategyFactory ?? throw new ArgumentNullException(nameof(argumentStrategyFactory));
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

        var strategy = _argumentStrategyFactory.Create(command);

        strategy.Execute(_args, _userInteraction, _expensesRepository);

    }

}