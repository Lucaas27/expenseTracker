namespace expenseTracker.DataAccess.Interfaces;

public interface IFileService
{
    string SaveToFile<T>(List<T> content);
    List<T> ReadFromFile<T>();

}