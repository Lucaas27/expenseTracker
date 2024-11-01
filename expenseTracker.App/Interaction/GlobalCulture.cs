using System.Globalization;

namespace expenseTracker.App.Interaction;

public static class GlobalCulture
{
    public static readonly CultureInfo CultureInfo = new("en-GB");
    public static readonly TextInfo TextInfo = CultureInfo.TextInfo;
}