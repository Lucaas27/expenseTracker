using expenseTracker.App;
using expenseTracker.DataAccess.Factories;
using expenseTracker.DataAccess.Services;
using expenseTracker.App.Factories;
using expenseTracker.App.Interaction;
using expenseTracker.DataAccess.Enums;

var userInteraction = new UserInteraction();
var filemetadata = new FileMetadata("expenses", FileExtension.Json);
var fileService = new FileServiceFactory().Create(filemetadata);
var strategies = new ArgumentStrategyFactory().Create();
var app = new App(args, userInteraction, strategies, fileService);


try
{
    app.Run();
}
catch (ArgumentException ex)
{
    userInteraction.ShowError("Invalid argument: " + ex.Message);
}
catch (Exception ex)
{
    userInteraction.ShowError(ex.Message);
}