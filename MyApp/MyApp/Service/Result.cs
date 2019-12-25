using MyApp.Models;

namespace MyApp.Service
{
    public class Result<T>
    {
        public T Data { get; set; }
        public Error error { get; set; }
    }
}