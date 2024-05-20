namespace pokemon_portal_blazor.DTOs;
public class ResponseError
{
    public string Code { get; set; } = string.Empty;
    public string? ErrorDetails { get; set; }
    public Exception? Exception { get; set; }
    public bool IsExceptionError => Exception is not null;
}