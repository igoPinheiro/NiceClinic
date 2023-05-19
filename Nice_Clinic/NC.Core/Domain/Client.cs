namespace NC.Core.Domain;

public class Client
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime BirthDate { get; set; }
   // public Sexo Sexo { get; set; }
    //public ICollection<Phone> Phones { get; set; }
    public string? Document { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? LastUpdate { get; set; }

   // public Endereco Endereco { get; set; }
}
