using System.ComponentModel.DataAnnotations;

public class Ocupaciones 
{
    [Key]

    public int OcupacionID { get; set; }

    [Required(ErrorMessage="La descripcion es requerida")]

    public string? Descripcion {get; set;}

    public double Sueldo { get; set; }

    
    
}