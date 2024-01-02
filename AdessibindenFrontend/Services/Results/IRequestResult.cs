using Core.Utilities.Exceptions;

namespace AdessibindenFrontend.Services.Results
{
    public interface IRequestResult<T>
    {
        T Data { get; set; }
        ExceptionDetails Error { get; set; }
        bool Success { get; set; }

    }
}