using System.Globalization;

namespace expenseTracker.CLI.Interaction;

public static class GlobalCulture
{
    public static readonly CultureInfo CultureInfo = new("en-GB");
    public static readonly DateTimeFormatInfo DateTimeFormatInfo = new();
}