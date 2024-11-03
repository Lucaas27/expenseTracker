namespace expenseTracker.DataAccess.Interfaces;

public interface IFileService
{
    void SaveToFile<T>(T content);
    List<T> ReadFromFile<T>();

}