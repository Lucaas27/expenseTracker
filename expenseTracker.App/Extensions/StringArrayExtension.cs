using System.Text;

namespace expenseTracker.App.Extensions
{
    public static class StringArrayExtension
    {
        public static bool IsOptionValueProvided(this string[] array, string option, out string? value)
        {
            var optionIndex = Array.IndexOf(array, option);
            // If the option is not found or the option is the last argument then set the value to null and return false
            if (optionIndex == -1 || optionIndex == array.Length - 1)
            {
                value = null;
                return false;
            }

            // If the next argument is another option then set the value to null and return false
            // Otherwise, build the value from the next arguments until the next option is found
            // If the value is already set then append a space before adding the next argument to the value
            var valueBuilder = new StringBuilder();
            for (int i = optionIndex + 1; i < array.Length; i++)
            {
                if (array[i].StartsWith("--"))
                {
                    break;
                }
                if (valueBuilder.Length > 0)
                {
                    valueBuilder.Append(' ');
                }
                valueBuilder.Append(array[i]);
            }

            value = valueBuilder.ToString();
            return true;
        }

    }
}