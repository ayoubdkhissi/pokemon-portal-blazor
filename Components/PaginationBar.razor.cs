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

	protected override async Task OnInitializedAsync()
	{
		TotalPages = 6;
	}

	private void OnPreviousPage()
	{
		if (CurrentPage > 1)
		{
			CurrentPage--;
			OnPageChanged.InvokeAsync(CurrentPage);
		}
	}

	private void OnNextPage()
	{
		if (CurrentPage < TotalPages)
		{
			CurrentPage++;
			OnPageChanged.InvokeAsync(CurrentPage);
		}
	}
}