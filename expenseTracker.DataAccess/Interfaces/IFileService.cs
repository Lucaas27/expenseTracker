namespace expenseTracker.DataAccess.Interfaces;

public interface IFileService
{
    void SaveToFile<T>(List<T> content);
    List<T> ReadFromFile<T>();

}