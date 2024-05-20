namespace pokemon_portal_blazor.DTOs;

public class ApiResponse
{
    public bool Success { get; set; }
    public string? ErrorCode { get; set; }
    public string? Message { get; set; }
    public IEnumerable<ResponseError>? Errors { get; set; }
}

public class ApiResponse<TData> : ApiResponse
{
    public TData? Data { get; set; }
}