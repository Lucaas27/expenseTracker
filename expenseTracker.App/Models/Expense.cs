
using expenseTracker.CLI.Interaction;

namespace expenseTracker.App.Models;

public class Expense
{
    public int Id { get; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; set; }

    public Expense(string description, decimal amount, int id)
    {
        Id = id;
        Description = description;
        Amount = amount;
        CreatedAt = DateTime.Now;
        UpdatedAt = CreatedAt;
    }

    public override string ToString()
    {
        return $"Id: {Id}| Description: {Description} | Amount: {Amount.ToString("C", GlobalCulture.CultureInfo)} | CreatedAt: {CreatedAt.ToString("dd MMMM yyy hh:mm:ss tt")} | UpdatedAt: {UpdatedAt.ToString("dd MMMM yyy hh:mm:ss tt")}";
    }
}