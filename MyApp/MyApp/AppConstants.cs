using System;
using System.Net.Http;

namespace MyApp
{
    public static class AppConstants
    {
        public static string ApiUrl = "https://jsonplaceholder.typicode.com";

        public static HttpClient HttpClientInstance { get; set; } = new HttpClient { BaseAddress = new Uri(ApiUrl) };
    }
}
