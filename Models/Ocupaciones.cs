using System.ComponentModel.DataAnnotations;

public class Ocupaciones 
{
    [Key]
    public int OcupacionId { get; set; }

    [Required(ErrorMessage="La descripcion es requerida")]

    public string? Descripcion {get; set;}

    [Required]

    public double Sueldo { get; set; }

    
    
}