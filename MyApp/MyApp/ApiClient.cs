using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MyApp.Models;
using MyApp.Service;
using Newtonsoft.Json;

namespace MyApp
{
    public class ApiClient
    {
        public readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result<T>> Get<T>(CancellationToken token, string route)
        {
            var result = new Result<T>();
            try
            {
                _httpClient.Timeout = new TimeSpan(0, 0, 120);

                var response = await _httpClient.GetAsync(AppConstants.ApiUrl + route, token);
                token.ThrowIfCancellationRequested();
                string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (response.IsSuccessStatusCode) 
                {
                    result.Data = JsonConvert.DeserializeObject<T>(content);
                }
                else 
                {
                    Error error = new Error();
                    error.error_description = content;
                    error.Code = (int)response.StatusCode;
                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        error.Code = (int)System.Net.HttpStatusCode.Unauthorized;
                    }
                    result.error = error;
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                Error error = new Error();
                if (message.Contains("Software caused connection abort") || message.Contains("Unable to resolve host"))
                {
                    error.error = "No Internet Connection";
                    error.error_description = "Please try again";
                }
                else
                {
                    //Other Error
                    error.error = ex.Message;
                    error.error_description = ex.Message;
                }
                result.error = error;
            }
            return result;
        }
    }
}
