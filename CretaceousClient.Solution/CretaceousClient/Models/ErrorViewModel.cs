#nullable enable //Because we're disabling a project-wide nullable context, we'll also have to update the boilerplate Models/ErrorViewModel.cs to create a nullable context, because it uses a nullable type. 

namespace CretaceousClient.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
