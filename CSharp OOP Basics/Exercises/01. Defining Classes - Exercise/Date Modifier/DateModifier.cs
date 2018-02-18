// ReSharper disable CheckNamespace

using System;
using System.Globalization;

public static class DateModifier
{
    public static long CalculateDifference(string str1, string str2)
    {
        DateTime date1 = DateTime.ParseExact(str1, "yyyy MM dd", CultureInfo.InvariantCulture);
        DateTime date2 = DateTime.ParseExact(str2, "yyyy MM dd", CultureInfo.InvariantCulture);

        return Math.Abs((date1 - date2).Days);
    }
}
