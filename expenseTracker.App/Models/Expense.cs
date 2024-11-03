
using expenseTracker.App.Interaction;

namespace expenseTracker.App.Models;

public class Expense
{
    public int Id { get; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public string CreatedAt { get; init; }

    public Expense(string description, decimal amount, int id)
    {
        Id = id;
        Description = description;
        Amount = amount;
        CreatedAt = DateTime.Now.ToString("dd-MMM-yyy hh:mm:ss tt");
    }

    public override string ToString()
    {
        return $"Id: {Id} | Description: {Description} | Amount: {Amount.ToString("C", GlobalCulture.CultureInfo)} | CreatedAt: {CreatedAt}";
    }
}