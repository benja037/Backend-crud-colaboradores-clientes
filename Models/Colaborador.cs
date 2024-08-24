using System.ComponentModel.DataAnnotations.Schema;

[Table("Colaborador")]
public class Colaborador
{
    public int ColaboradorId { get; set; }
    public required string Rut { get; set; }
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string Cargo { get; set; }

    
    public ICollection<Cliente>? Clientes { get; set; }
    

}