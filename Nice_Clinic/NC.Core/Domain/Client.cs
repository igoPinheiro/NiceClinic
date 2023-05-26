using System.ComponentModel.DataAnnotations;

namespace NC.Core.Domain;

public class Client
{
    public int Id { get; set; }
    [StringLength(100,MinimumLength =3,ErrorMessage ="Nome deve ter entre 3 e 100 caracteres")]
    public string? Name { get; set; }    
    public DateTime BirthDate { get; set; }
    [MaxLength(1)]
    public string? Sexo { get; set; }
    // public Sexo Sexo { get; set; }
    public ICollection<Phone> Phones { get; set; }
    [MaxLength(50)]
    public string? Document { get; set; } = null;
    public DateTime CreationDate { get; set; }
    public DateTime? LastUpdate { get; set; }
    public Address Address { get; set; }
}
