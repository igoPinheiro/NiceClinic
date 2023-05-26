namespace NC.Core.Domain;

public class Phone
{
    public int ClientId { get; set; }
    public string Number { get; set; }
    public Client Client { get; set; }

}