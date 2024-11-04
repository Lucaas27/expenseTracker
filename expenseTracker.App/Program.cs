using expenseTracker.App;
using expenseTracker.DataAccess.Factories;
using expenseTracker.DataAccess.Services;
using expenseTracker.App.Factories;
using expenseTracker.DataAccess.Enums;
using expenseTracker.App.Repositories;
using expenseTracker.CLI.Interaction;

var userInteraction = new UserInteraction();
var filemetadata = new FileMetadata("expenses", FileExtension.json);
var fileService = new FileServiceFactory().Create(filemetadata);
var expensesRepository = new ExpensesRepository(fileService);
var strategies = new ArgumentStrategyFactory().Create();
var app = new App(args, userInteraction, strategies, expensesRepository);


try
{
    app.Run();
}
catch (Exception ex)
{
    userInteraction.ShowError(ex.Message);
}