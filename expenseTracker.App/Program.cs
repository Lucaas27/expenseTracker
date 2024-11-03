using expenseTracker.App;
using expenseTracker.App.Factories;
using expenseTracker.App.Interaction;

var userInteraction = new UserInteraction();
var strategies = new ArgumentStrategyFactory().Create();
var app = new App(args, userInteraction, strategies);


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