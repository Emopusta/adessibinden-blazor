using Core.Utilities.Exceptions;

namespace AdessibindenFrontend.Services
{
    public interface IRequestResult<T>
    {
        T Data { get; set; }
        ExceptionDetails Error { get; set; }
        bool Success { get; set; }
        string Message { get; set; }

    }
}