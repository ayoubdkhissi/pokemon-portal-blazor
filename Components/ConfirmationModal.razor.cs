using Microsoft.AspNetCore.Components;

namespace pokemon_portal_blazor.Components;
public partial class ConfirmationModal
{
    [Parameter]
    public EventCallback<bool> OnConfirmed { get; set; }

    public bool IsVisible { get; set; }

    public void Show()
    {
        IsVisible = true;
        StateHasChanged();
    }

    public void Hide()
    {
        IsVisible = false;
        StateHasChanged();
    }

    private async Task Confirm()
    {
        IsVisible = false;
        await OnConfirmed.InvokeAsync(true);
    }

    private async Task Cancel()
    {
        IsVisible = false;
        await OnConfirmed.InvokeAsync(false);
    }
}
