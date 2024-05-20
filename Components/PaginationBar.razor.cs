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
        if (pageNumber != CurrentPage && pageNumber >= 1 && pageNumber <= TotalPages)
        {
            CurrentPage = pageNumber;
            await OnPageChanged.InvokeAsync(pageNumber);
        }
    }

    private IEnumerable<int?> GetPageNumbers()
    {
        var pages = new List<int?> { 1 };
        if (CurrentPage > 4) pages.Add(null);

        for (int i = Math.Max(2, CurrentPage - 2); i <= Math.Min(TotalPages - 1, CurrentPage + 2); i++)
            pages.Add(i);

        if (CurrentPage < TotalPages - 3) pages.Add(null);

        pages.Add(TotalPages);
        return TotalPages <= 8 ? Enumerable.Range(1, TotalPages).Cast<int?>() : pages;
    }
}