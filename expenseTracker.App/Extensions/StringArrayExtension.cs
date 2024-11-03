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

            value = array[optionIndex + 1];
            return true;
        }

    }
}