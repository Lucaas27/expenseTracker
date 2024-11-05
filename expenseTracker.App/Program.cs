using expenseTracker.App;
using expenseTracker.DataAccess.Factories;
using expenseTracker.DataAccess.Services;
using expenseTracker.App.Factories;
using expenseTracker.DataAccess.Enums;
using expenseTracker.App.Repositories;
using expenseTracker.CLI.Interaction;

var userInteraction = new UserInteraction();
var fileMetadata = new FileMetadata(FileExtension.json);
var fileServiceFactory = new FileServiceFactory();
var expensesRepository = new ExpensesRepository(fileServiceFactory, fileMetadata);
var strategyFactory = new ArgumentStrategyFactory();
var app = new App(args, userInteraction, strategyFactory, expensesRepository);


try
{
    app.Run();
}
catch (Exception ex)
{
    userInteraction.ShowError(ex.Message);
}