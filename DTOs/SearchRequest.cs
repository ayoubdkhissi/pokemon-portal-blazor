namespace pokemon_portal_blazor.DTOs;

public class SearchRequest
{
    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = (value < 1) ? 1 : value;
    }
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
    public string SearchTerm { get; set; } = string.Empty;

    private const int MaxPageSize = 50;
    private int _pageSize = 10;

    private int _pageNumber = 1;
}