using expenseTracker.App.Models;

namespace expenseTracker.App.Interfaces;

public interface IExpensesRepository
{
    int GetNextId();
    void SaveExpenseToFile(Expense content);
    List<Expense> ReadExpensesFromFile();
}