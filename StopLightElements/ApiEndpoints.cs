namespace StopLightElements;
/// <summary>
/// Api Endpoint Constants
/// </summary>
public static class ApiEndpoints
{
    private const string ApiBase = "/api";

    public static class Hello
    {
        private const string Base = $"{ApiBase}";

        /// <summary>
        /// Get Hello World from Controller
        /// </summary>
        public const string Controller = $"{Base}/controller";
        /// <summary>
        /// Get Hello World from MinimalApi
        /// </summary>
        public const string MinimalApi = $"{Base}/minimal-api";
    }
}
