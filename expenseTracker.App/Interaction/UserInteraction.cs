using expenseTracker.App.Interfaces;

namespace expenseTracker.App.Interaction;

public class UserInteraction : IUserInteraction
{
    public void ShowMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(message);
        Console.ResetColor();

    }
    public void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();

    }
    public void ShowWarning(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ResetColor();
    }

}
