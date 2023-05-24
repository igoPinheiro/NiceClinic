namespace NC.Core.Shared.ModelViews;

public class NewClient
{
    public string? Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Sexo { get; set; }
    public string? Phone { get; set; }
    public string? Document { get; set; } = null;
}
