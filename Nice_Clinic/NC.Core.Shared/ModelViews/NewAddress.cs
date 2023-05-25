namespace NC.Core.Shared.ModelViews;

public class NewAddress
{
    /// <summary>
    /// Cidade
    /// </summary>
    /// <example>Manaus</example>
    public string City { get; set; } = string.Empty;
    //// <summary>
    /// Complemento
    /// </summary>
    /// <example>Casa</example>
    public string Complement { get; set; } = string.Empty;
    //// <summary>
    /// Número da Casa do cliente
    /// </summary>
    /// <example>3-B</example>
    public string Number { get; set; } = string.Empty;
    //// <summary>
    /// Cep do cliente
    /// </summary>
    /// <example>69079310</example>
    public int PostalCode { get; set; }
    //// <summary>
    /// Rua do cliente
    /// </summary>
    /// <example>Rua Coronel Miranda Reis</example>
    public string Street { get; set; } = string.Empty;
    //// <summary>
    /// Unidade Federativa
    /// </summary>
    /// <example>AM</example>
    public string UF { get; set; } = string.Empty;
}