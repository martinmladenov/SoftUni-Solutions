namespace SIS.HTTP.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(this string str)
        {
            if (str.Length == 0)
            {
                return string.Empty;
            }

            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }
    }
}