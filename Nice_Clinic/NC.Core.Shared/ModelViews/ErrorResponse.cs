namespace NC.Core.Shared.ModelViews;

public class ErrorResponse
{
    public string Id { get; set; }  = string.Empty;
    public string RequestId { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public DateTime Date { get; set; }

    public ErrorResponse(string id, string requestId)
    {
        Id = id;
        RequestId = requestId;
        Date = DateTime.Now;
        Message = "Erro Inesperado";
    }
}
