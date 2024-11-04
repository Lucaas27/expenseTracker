using expenseTracker.App.Interfaces;
using expenseTracker.App.Models;
using expenseTracker.DataAccess.Interfaces;

namespace expenseTracker.App.Repositories;

public class ExpensesRepository : IExpensesRepository
{
    private readonly IFileService _fileService;
    private readonly List<Expense> _expenses;

    public ExpensesRepository(IFileService fileService)
    {
        _fileService = fileService;
        _expenses = _fileService.ReadFromFile<Expense>();
    }

    public Expense GetExpenseById(int id)
    {
        return _expenses.Find(e => e.Id == id) ?? throw new InvalidOperationException($"No expense found with the ID: {id}");
    }

    public void UpdateExpense(int id, decimal amount, string description)
    {
        ArgumentNullException.ThrowIfNull(id);

        var expense = GetExpenseById(id);

        if (amount != default)
        {
            expense.Amount = amount;
            expense.UpdatedAt = DateTime.Now;
        }

        if (description != default)
        {
            expense.Description = description;
            expense.UpdatedAt = DateTime.Now;
        }

        _fileService.SaveToFile(_expenses);
    }


    public void DeleteExpenseFromFile(int id)
    {
        ArgumentNullException.ThrowIfNull(id);
        var expense = _expenses.Find(e => e.Id == id) ?? throw new InvalidOperationException($"The expense with ID {id} does not exist.");

        _expenses.Remove(expense);
        _fileService.SaveToFile(_expenses);
    }

    public void DeleteAllExpenses()
    {
        _expenses.Clear();
        _fileService.SaveToFile(_expenses);
    }

    public int GetNextId()
    {
        return _expenses.Count > 0 ? _expenses.Max(e => e.Id) + 1 : 1;
    }

    public void SaveExpenseToFile(Expense content)
    {
        ArgumentNullException.ThrowIfNull(content);

        if (_expenses.Find(e => e.Id == content.Id) != null)
        {
            throw new ArgumentException($"The expense with ID {content.Id} already exists.");
        }

        _expenses.Add(content);
        _fileService.SaveToFile(_expenses);

    }

    public List<Expense> ReadExpensesFromFile()
    {
        return _expenses;
    }

}
