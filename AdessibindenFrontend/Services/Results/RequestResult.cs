
namespace AdessibindenFrontend.Services.Results
{
    public class RequestResult<T> : IRequestResult<T>
    {
        public T Data { get; set; }
        public ExceptionDetails Error { get; set; }
        public bool Success { get; set; }

    }
}
