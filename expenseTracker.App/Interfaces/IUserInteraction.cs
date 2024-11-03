namespace expenseTracker.App.Interfaces;

public interface IUserInteraction
{
    void ShowMessage(string message);
    void ShowError(string message);
    void ShowWarning(string message);
}