using System.ComponentModel.DataAnnotations.Schema;

[Table("Cliente")]
public class Cliente
{
    public int ClienteId { get; set; }
    public required string Rut { get; set; }
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string? Fono { get; set; }
    public required string? Direccion { get; set; }
    public required string? Email { get; set; }
    public required DateTime FechaIngreso { get; set; }

    
    public int? ColaboradorId { get; set; } 
    
   
    public Colaborador? Colaborador { get; set; }  
}
