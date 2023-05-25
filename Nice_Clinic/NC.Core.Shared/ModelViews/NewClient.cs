namespace NC.Core.Shared.ModelViews;

/// <summary>
/// Objeto Utilizado para inserção de um novo cliente
/// </summary>
public class NewClient
{    
    /// <summary>
    /// Nome do cliente
    /// </summary>
    /// <example>João Ferreira da Silva</example>
    public string? Name { get; set; }
    /// <summary>
    /// Data do nascimento do cliente
    /// </summary>
    /// <example>1995-01-01</example>
    public DateTime BirthDate { get; set; }
    /// <summary>
    /// Sexo do Cliente - M para masculino , F para Feminino
    /// </summary>
    /// <example>M</example>
    public string? Sexo { get; set; }
    /// <summary>
    /// Telefone do Cliente
    /// </summary>
    /// <example>92981384657</example>
    public string? Phone { get; set; }
    /// <summary>
    /// Documento do cliente: CNH, CPF ,RG
    /// </summary>
    /// <example>12342234244</example>
    public string? Document { get; set; } = null;

    public NewAddress? Address { get; set; }
}
