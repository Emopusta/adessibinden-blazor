namespace AdessibindenFrontend.Core.Application.Responses;

public class ListResponse<T>
{
    public IList<T> Data
    {
        get => _data ??= new List<T>();
        set => _data = value;
    }

    private IList<T>? _data;
}
