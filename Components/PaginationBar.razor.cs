using Microsoft.AspNetCore.Components;

namespace pokemon_portal_blazor.Components;

public partial class PaginationBar : ComponentBase
{
	[Parameter]
	public int CurrentPage { get; set; } = 1;

	[Parameter]
	public int TotalPages { get; set; }

	[Parameter]
	public EventCallback<int> OnPageChanged { get; set; }


	private void OnPreviousPage()
	{
		if (CurrentPage > 1)
		{
			CurrentPage--;
			OnPageChanged.InvokeAsync(CurrentPage);
		}
	}

	private async void OnNextPage()
	{
		if (CurrentPage < TotalPages)
		{
			CurrentPage++;
            await OnPageChanged.InvokeAsync(CurrentPage);
		}
	}

	private async Task GoToPageAsync(int pageNumber)
	{
        CurrentPage = pageNumber;
		Console.WriteLine($"Current Page: {CurrentPage}");
        await OnPageChanged.InvokeAsync(CurrentPage);
    }
}