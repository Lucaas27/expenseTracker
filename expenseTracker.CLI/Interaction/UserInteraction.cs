using System.Reflection;
using expenseTracker.CLI.Interfaces;

namespace expenseTracker.CLI.Interaction;

public class UserInteraction : IUserInteraction
{

    /// <summary>
    /// Displays a message in cyan color on the console.
    /// </summary>
    /// <param name="message">The message to be displayed.</param>
    public void ShowMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(message);
        Console.ResetColor();

    }

    /// <summary>
    /// Displays an error message in red color on the console.
    /// </summary>
    /// <param name="message">The error message to be displayed.</param>
    public void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();

    }

    /// <summary>
    /// Displays a warning message in yellow color on the console.
    /// </summary>
    /// <param name="message">The warning message to be displayed.</param>
    public void ShowWarning(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ResetColor();
    }


    /// <summary>
    /// Displays a warning message in yellow color on the console.
    /// Formats a list of objects into a table string representation.
    /// </summary>
    /// <typeparam name="T">The type of objects in the list.</typeparam>
    /// <param name="objects">The list of objects to format as a table.</param>
    /// <returns>A string representing the table. If the list is null or empty, returns "Nothing found to be displayed."</returns>
    public string FormatAsTable<T>(List<T> objects)
    {
        if (objects == null || !objects.Any())
        {
            return "Nothing found to be displayed.";
        }

        // Get the public properties of the type
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        // Get the names of the properties to use as headers
        var headers = properties.Select(p => p.Name);

        // Loop through each object
        var rows = objects.Select(obj =>
            properties.Select(p =>
            {
                // Get the value of the property for the object
                var value = p.GetValue(obj);
                // If the value is a decimal, format it as currency else convert it to string or return an empty string if the value is null
                return value is decimal ? string.Format(GlobalCulture.CultureInfo, "{0:C}", value) : value?.ToString() ?? string.Empty;
            })
            .ToArray()
        // Finally, this will give us a collection(IEnumerable) of arrays (string[]), where each array is a row. Each element in the array is a cell.
        );

        // Get the maximum length of each column by comparing the header length and the maximum length of the values in each column
        var columnWidths = headers.Select((header, index) => Math.Max(header.Length, rows.Max(row => row[index].Length))).ToArray();

        // Create the table as a list of strings to make it easier to join them later with a new line character as separator
        var table = new List<string>();

        // Add headers to the table with the values padded to the maximum length of the column and separated by a pipe character
        var headerRow = string.Join(" | ", headers.Select((header, index) => header.PadRight(columnWidths[index])));
        table.Add(new string('-', headerRow.Length));
        table.Add(headerRow);
        table.Add(new string('-', headerRow.Length));

        // Add rows to the table with the values padded to the maximum length of the column and separated by a pipe character
        foreach (var row in rows)
        {
            var rowString = string.Join(" | ", row.Select((cell, index) => cell.PadRight(columnWidths[index])));
            table.Add(rowString);
        }

        return string.Join(Environment.NewLine, table);

    }

}
