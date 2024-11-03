using expenseTracker.App.Interfaces;

namespace expenseTracker.App;

public class App
{
    private readonly string[] _args;
    private readonly IUserInteraction _userInteraction;

    private readonly Dictionary<string, IArgumentStrategy> _argumentStrategy;

    public App(string[] args, IUserInteraction userInteraction, Dictionary<string, IArgumentStrategy> argumentStrategy)
    {
        _args = args ?? throw new ArgumentNullException(nameof(args));
        _userInteraction = userInteraction ?? throw new ArgumentNullException(nameof(userInteraction));
        _argumentStrategy = argumentStrategy ?? throw new ArgumentNullException(nameof(argumentStrategy));
    }




    public void Run()
    {
        if (_args.Length == 0)
        {
            _userInteraction.ShowError("No arguments provided, please check the arguments and try again.");
            return;
        }

        var arg = _args[0].ToLower();

        if (_argumentStrategy.ContainsKey(arg))
        {
            _argumentStrategy[arg].Execute(_args, _userInteraction);
            return;
        }

        _userInteraction.ShowError("Invalid argument provided, please check the arguments and try again.");
    }

}