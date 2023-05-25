namespace NC.WebApi.Utils;

public class ApiResponse
{
    public int StatusCode { get; }
  //  [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string Message { get; }
    public ApiResponse(int statusCode, string message = "")
    {
        StatusCode = statusCode;
        Message = message ?? GetDefaultMessageForStatusCode(statusCode);
    }
    private static string GetDefaultMessageForStatusCode(int statusCode)
    {
        switch (statusCode)
        {

            case 401:
                return "Não autorizado (não autenticado)";
            case 404:
                return "Recurso não encontrado";
            case 405:
                return "Método não permitido";
            case 500:
                return "Um erro não tratado ocorreu no request";
            default:
                return "";
        }
    }
}
