using expenseTracker.App;
using expenseTracker.App.Interaction;

var app = new App();


try
{
    app.Run(args);
}
catch (Exception ex)
{
    ConsoleInteraction.ShowError(ex.Message);
}