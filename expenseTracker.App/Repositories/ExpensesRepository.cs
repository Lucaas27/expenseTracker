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

    public int GetNextId()
    {
        return _expenses.Count > 0 ? _expenses.Max(e => e.Id) + 1 : 1;
    }

    public void SaveExpenseToFile(Expense content)
    {
        if (content == null)
        {
            throw new ArgumentNullException(nameof(content));
        }

        if (_expenses.Find(e => e.Id == content.Id) != null)
        {
            throw new ArgumentException($"The expense with ID {content.Id} already exists.");
        }

        _expenses.Add(content);
        _fileService.SaveToFile(_expenses);

    }

    public List<Expense> ReadExpensesFromFile()
    {
        var expenses = _fileService.ReadFromFile<Expense>();

        // If there are expenses in the file, update the list
        if (expenses.Count > 0)
        {
            _expenses.Clear();
            _expenses.AddRange(expenses);
        }

        return expenses;
    }

}
