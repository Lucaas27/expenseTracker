using expenseTracker.App.Models;

namespace expenseTracker.App.Interfaces;

public interface IExpensesRepository
{
    Expense GetExpenseById(int id);
    void DeleteExpenseFromFile(int id);
    void DeleteAllExpenses();
    int GetNextId();
    void SaveExpenseToFile(Expense content);
    List<Expense> ReadExpensesFromFile();
}