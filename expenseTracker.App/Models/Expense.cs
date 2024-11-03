
using expenseTracker.CLI.Interaction;

namespace expenseTracker.App.Models;

public class Expense
{
    public int Id { get; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public string CreatedAt { get; init; }
    public string UpdatedAt { get; set; }

    public Expense(string description, decimal amount, int id)
    {
        Id = id;
        Description = description;
        Amount = amount;
        CreatedAt = DateTime.Now.ToString("dd-MMM-yyy hh:mm:ss tt");
        UpdatedAt = CreatedAt;
    }

    public override string ToString()
    {
        return $"Id: {Id}\t\tDescription: {Description}\t\tAmount: {Amount.ToString("C", GlobalCulture.CultureInfo)}\t\tCreatedAt: {CreatedAt}\t\tUpdatedAt: {UpdatedAt}\t\t";
    }
}