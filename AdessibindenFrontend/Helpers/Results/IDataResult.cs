namespace AdessibindenFrontend.Helpers.Results
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
