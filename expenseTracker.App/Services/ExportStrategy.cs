using expenseTracker.App.Extensions;
using expenseTracker.App.Interfaces;
using expenseTracker.CLI.Interfaces;
using expenseTracker.DataAccess.Enums;
using expenseTracker.DataAccess.Factories;
using expenseTracker.DataAccess.Services;

namespace expenseTracker.App.Services;

public class ExportStrategy : IArgumentStrategy
{

    public void Execute(string[] args, IUserInteraction userInteraction, IExpensesRepository expensesRepository)
    {
        var expenses = expensesRepository.ReadExpensesFromFile();
        var input = args.Skip(1).FirstOrDefault(); // Get the first option after the command or null if not provided
        var parsedInput = Enum.TryParse(input?.Substring(2), true, out FileExtension fileExtension) ? (FileExtension?)fileExtension : null;

        if (parsedInput == null && !string.IsNullOrEmpty(input))
        {
            userInteraction.ShowError("Format is not supported, please provide a valid format to export the expenses.");
            return;
        }

        var format = parsedInput != null ? fileExtension : FileExtension.csv; // Default to CSV if no format is provided

        var fileMetadata = new FileMetadata("expenses", format);
        var fileService = new FileServiceFactory().Create(fileMetadata);

        string currentDirectory = Directory.GetCurrentDirectory();
        string fullPath = Path.Combine(currentDirectory, fileMetadata.GetFullPath());

        fileService.SaveToFile(expenses);
        userInteraction.ShowMessage($"Expenses have been exported to {fullPath}");
    }
}