namespace SIS.HTTP.Extensions
{
    using Enums;

    public static class HttpResponseStatusExtensions
    {
        public static string GetResponseLine(this HttpResponseStatusCode statusCode)
        {
            return $"{(int) statusCode} {statusCode}";
        }
    }
}