namespace expenseTracker.CLI.Interfaces;

public interface IUserInteraction
{
    void ShowMessage(string message);
    void ShowError(string message);
    void ShowWarning(string message);

    string FormatAsTable<T>(List<T> items);
}