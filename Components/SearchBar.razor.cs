using Microsoft.AspNetCore.Components;

namespace pokemon_portal_blazor.Components;
public partial class SearchBar
{
    private string SearchTerm { get; set; } = string.Empty;
    private Timer? DebounceTimer;
    private const int DEBOUNCE_TIME = 500;

    [Parameter]
    public EventCallback<string> OnSearch { get; set; }

    private void OnInputChanged(ChangeEventArgs e)
    {
        if (DebounceTimer != null)
        {
            DebounceTimer.Dispose();
        }
        SearchTerm = e?.Value?.ToString() ?? string.Empty;
        DebounceTimer = new Timer(DebounceEnded, null, DEBOUNCE_TIME, Timeout.Infinite);
    }

    private void DebounceEnded(object? state)
    {
        InvokeAsync(async () =>
        {
            await OnSearch.InvokeAsync(SearchTerm);
        });
    }
}

