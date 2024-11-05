using expenseTracker.App.Interfaces;

namespace expenseTracker.App.Factories;

public interface IArgumentStrategyFactory
{
    IArgumentStrategy Create(string strategy);
}