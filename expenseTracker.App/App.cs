using System.Data;
using expenseTracker.App.Interaction;
using expenseTracker.App.Models;

namespace expenseTracker.App;

public class App
{
    private readonly string[] _args;

    public App(string[] args)
    {
        _args = args;
    }

    private Dictionary<string, string> ParseArgs()
    {
        var userInputs = new Dictionary<string, string>();

        if (_args.Length == 0)
        {
            ConsoleInteraction.ShowError("No arguments provided.");
        }
        else
        {
            // Loop through the args array and create a dictionary
            for (var i = 0; i < _args.Length; i += 2)
            {
                var key = GlobalCulture.TextInfo.ToTitleCase(_args[i].Substring(2)); // Remove the "--" prefix and convert to title case
                var value = _args[i + 1];

                userInputs.Add(key, value);
            }

        }

        return userInputs;
    }

    public void Run()
    {

        var userInputs = ParseArgs();


        foreach (var pair in userInputs)
        {
            Console.WriteLine(pair.Key + " : " + pair.Value);
        }
    }

}