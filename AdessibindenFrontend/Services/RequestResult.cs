namespace AdessibindenFrontend.Services
{
    public class RequestResult<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

    }
}
