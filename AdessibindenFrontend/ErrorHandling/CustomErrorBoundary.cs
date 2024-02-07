using Microsoft.AspNetCore.Components.Web;

namespace AdessibindenFrontend.ErrorHandling;

public class CustomErrorBoundary : ErrorBoundary
{
    protected override Task OnErrorAsync(Exception exception)
    {
        return Task.CompletedTask;
    }
}
