using System.ComponentModel.DataAnnotations;

namespace NC.Core.Domain;

public class Client
{
    [Required]
    public int Id { get; set; }
    [StringLength(100,MinimumLength =3,ErrorMessage ="Nome deve ter entre 3 e 100 caracteres")]
    public string? Name { get; set; }    
    public DateTime BirthDate { get; set; }
   // public Sexo Sexo { get; set; }
    //public ICollection<Phone> Phones { get; set; }
    //public string? Document { get; set; }
    //public DateTime CreationDate { get; set; }
    //public DateTime? LastUpdate { get; set; }

   // public Endereco Endereco { get; set; }
}
