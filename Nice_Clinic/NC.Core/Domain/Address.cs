namespace NC.Core.Domain;

public class Address
{
    public int ClientId { get; set; }
    public string UF { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Complement { get; set; } = string.Empty;
    public string Neighborhood { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public int PostalCode { get; set; }
    public string Street { get; set; } = string.Empty;
    public Client? Client { get; set; }
}