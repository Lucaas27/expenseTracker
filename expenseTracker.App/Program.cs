using expenseTracker.App;
using expenseTracker.App.Interaction;

var app = new App(args);


try
{
    app.Run();
}
catch (Exception ex)
{
    ConsoleInteraction.ShowError(ex.Message);
}