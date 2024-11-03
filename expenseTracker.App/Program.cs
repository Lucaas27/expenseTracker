﻿using expenseTracker.App;
using expenseTracker.DataAccess.Factories;
using expenseTracker.DataAccess.Services;
using expenseTracker.App.Factories;
using expenseTracker.App.Interaction;
using expenseTracker.DataAccess.Enums;
using expenseTracker.App.Repositories;

var userInteraction = new UserInteraction();
var filemetadata = new FileMetadata("expenses", FileExtension.Json);
var fileService = new FileServiceFactory().Create(filemetadata);
var expensesRepository = new ExpensesRepository(fileService);
var strategies = new ArgumentStrategyFactory().Create();
var app = new App(args, userInteraction, strategies, expensesRepository);


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